using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour 
{
  private int _currentStarCount;
  private Text _txtStarDisplay;

  // Use this for initialization
  void Start () 
  {
    _currentStarCount = 100;
    _txtStarDisplay = GetComponent<Text>();
    UpdateDisplay();
  }

  public float GetCurrentStarAmount()
  {
    return _currentStarCount;
  }

  public void AddStars(int amountToAdd)
  {
    _currentStarCount += amountToAdd;
    UpdateDisplay();
  }

  public bool UseStars(int amountToUse)
  {
    if (amountToUse > _currentStarCount)
      return false;

    _currentStarCount -= amountToUse;
    UpdateDisplay();
    return true;
  }

  private void UpdateDisplay()
  {
    _txtStarDisplay.text = _currentStarCount.ToString();
  }
}
