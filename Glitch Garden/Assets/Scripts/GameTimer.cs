using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour 
{
  public float LevelDuration = 100f;

  private Slider _slider;
  private AudioSource _audioSource;
  private LevelManager _levelManager;
  private GameObject _winLabel;
  private Spawner _spawner;
  private bool _isLevelEnded;

  // Use this for initialization
  void Start () 
  {
    _slider = GetComponent<Slider>();
    _audioSource = GetComponent<AudioSource>();
    _levelManager = FindObjectOfType<LevelManager>();
    _winLabel = GameObject.Find("Win Text");
    _spawner = FindObjectOfType<Spawner>();

    _winLabel.SetActive(false);
    _audioSource.volume = PlayerPrefsManager.GetMasterVolume();
  }
  
  // Update is called once per frame
  void Update () 
  {
    _slider.value = Time.timeSinceLevelLoad / LevelDuration;

    if (Time.timeSinceLevelLoad >= LevelDuration && !_isLevelEnded)
    {
      HandleWinCondition();
    }
  }

  private void HandleWinCondition()
  {
    DestroyAllTaggedObjects();
    _isLevelEnded = true;
    _winLabel.SetActive(true);
    _audioSource.Play();
    Invoke("LoadNextLevel", _audioSource.clip.length);
  }

  private void DestroyAllTaggedObjects()
  {
    var objectsToDestroy = GameObject.FindGameObjectsWithTag("DestroyOnWin");
    foreach (var objectToDestroy in objectsToDestroy)
      Destroy(objectToDestroy);
  }

  private void LoadNextLevel()
  {
    _levelManager.LoadNextLevel();
  }
}
