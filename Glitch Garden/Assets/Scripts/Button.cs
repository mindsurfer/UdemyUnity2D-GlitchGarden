using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour 
{
  public GameObject Defender;

  private ButtonsManager _buttonsManager;
  private Text _costText;

  // Use this for initialization
  void Start () 
  {
    _buttonsManager = GetComponentInParent<ButtonsManager>();
    _costText = GetComponentInChildren<Text>();
    if (_costText)
      _costText.text = Defender.GetComponent<Defender>().StarCost.ToString();
    else
      Debug.LogWarning("Cost text object not found.");
  }
  
  // Update is called once per frame
  void Update () 
  {
    
  }

  void OnMouseDown()
  {
    _buttonsManager.ButtonSelected(this);
  }
}
