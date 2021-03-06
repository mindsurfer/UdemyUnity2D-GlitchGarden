﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
  public void LoadLevel(string name)
  {
    print("Level load requested for: " + name);
    SceneManager.LoadScene(name); 
  }

  public void QuitRequest()
  {
    print("Quit request sent");
    Application.Quit();
  }

  public void LoadNextLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}
