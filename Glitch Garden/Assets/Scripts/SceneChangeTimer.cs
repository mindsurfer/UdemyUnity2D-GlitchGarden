using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTimer : MonoBehaviour 
{
  public float TimerDuration = 5f;
  public string NextScene = "";

  private float _currentTimer;
  private bool _stopTimer;

  void Awake()
  {
    _currentTimer = 0f;
    _stopTimer = false;
  }
  
  // Update is called once per frame
  void Update () 
  {
    if (!_stopTimer)
      _currentTimer += Time.deltaTime;

    if (_currentTimer >= TimerDuration)
    {
      var levelManager = GameObject.FindObjectOfType<LevelManager>();
      levelManager.LoadLevel(NextScene);
      _stopTimer = true;
    }
  }
}
