using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour 
{
  public AudioClip[] LevelMusicChangeArray;

  private AudioSource _musicSource;
  private int _currentPlayingIndex;

  void OnEnable()
  {
    SceneManager.sceneLoaded += SceneManager_sceneLoaded;
  }

  void OnDisable()
  {
    SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
  }

  void Awake()
  {
    _currentPlayingIndex = -1;
    _musicSource = gameObject.GetComponent<AudioSource>();
    GameObject.DontDestroyOnLoad(_musicSource);
  }

  // Use this for initialization
  void Start () 
  {

  }
  
  // Update is called once per frame
  void Update () 
  {
    
  }

  public void ChangeVolume(float volume)
  {
    _musicSource.volume = volume;
  }

  public void PlayMusicForSceneIndex(int index)
  {
    if (!SceneIndexMusicValid(index))
      return;

    // Leave volume to default on splash, only set on first arrival in start scene.
    if (_currentPlayingIndex == 0 && index == 1)
      _musicSource.volume = PlayerPrefsManager.GetMasterVolume();

    _musicSource.Stop();
    _musicSource.clip = LevelMusicChangeArray[index];
    _musicSource.loop = ShouldMusicLoop(index);
    _musicSource.Play();
    _currentPlayingIndex = index;
  }

  private bool SceneIndexMusicValid(int index)
  {
    if (index > LevelMusicChangeArray.Length)
    {
      Debug.LogError("PlayMusicForSceneIndex: Invalid level index.");
      return false;
    }
    if (LevelMusicChangeArray[index] == null)
    {
      Debug.Log("PlayMusicForSceneIndex: Null audio source.");
      return false;
    }
    // This is to not reset music when navigating to a scene where the clip is currently already playing
    if (_currentPlayingIndex == index)
    {
      return false;
    }

    return true;
  }

  private bool ShouldMusicLoop(int index)
  {
    if (index == 0)
      return false;
    return true;
  }

  private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
  {
    var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    PlayMusicForSceneIndex(currentSceneIndex);
  }
}
