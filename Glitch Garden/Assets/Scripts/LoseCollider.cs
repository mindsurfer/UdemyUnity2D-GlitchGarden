using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour 
{
  private LevelManager _levelManager;

  // Use this for initialization
  void Start () 
  {
    _levelManager = GameObject.FindObjectOfType<LevelManager>();  
  }
  
  // Update is called once per frame
  void Update () 
  {
    
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    _levelManager.LoadLevel("03b Lose");
  }
}
