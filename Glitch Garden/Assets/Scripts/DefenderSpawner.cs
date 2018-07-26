using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour 
{
  private Camera _camera;
  private GameObject _defenderParent;
  private StarDisplay _starDisplay;

  // Use this for initialization
  void Start () 
  {
    _camera = GameObject.FindObjectOfType<Camera>();
    _starDisplay = GameObject.FindObjectOfType<StarDisplay>();

    _defenderParent = GameObject.Find("Defenders");
    if (!_defenderParent)
    {
      _defenderParent = new GameObject("Defenders");
      _defenderParent.transform.position = Vector3.zero;
    }
  }
  
  // Update is called once per frame
  void Update () 
  {
    
  }

  void OnMouseDown()
  {
    BuildDefender();
  }

  private void BuildDefender()
  {
    // Check if enough star currency for defender
    var currentDefender = ButtonsManager.SelectedDefender.GetComponent<Defender>();
    var buildSuccess = _starDisplay.UseStars(currentDefender.StarCost);
    if (!buildSuccess)
      return;

    var defender = Instantiate(ButtonsManager.SelectedDefender, CalculateWorldPointOfMouseClick(), Quaternion.identity);
    defender.transform.parent = _defenderParent.transform;
  }

  private Vector2 CalculateWorldPointOfMouseClick()
  {
    var worldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
    return new Vector2(Mathf.Round(worldPoint.x), Mathf.Round(worldPoint.y));
  }
}
