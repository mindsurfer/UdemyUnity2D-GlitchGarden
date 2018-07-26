using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour 
{
  public int StarCost = 30;
  public string AttackParamName = "isAttacking";

  private StarDisplay _starDisplay;

  void Start()
  {
    _starDisplay = GameObject.FindObjectOfType<StarDisplay>();
  }

  private void AddStars(int amount)
  {
    _starDisplay.AddStars(amount);
  }
}
