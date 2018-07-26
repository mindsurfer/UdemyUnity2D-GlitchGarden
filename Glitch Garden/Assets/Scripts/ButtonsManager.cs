using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour 
{
  public Button[] Buttons;

  public static GameObject SelectedDefender;

  public void ButtonSelected(Button button)
  {
    var spriteRenderer = button.gameObject.GetComponent<SpriteRenderer>();
    if (spriteRenderer)
    {
      spriteRenderer.color = Color.white;
      SelectedDefender = button.Defender;

      foreach (var otherButton in Buttons)
      {
        if (otherButton.name != button.name)
        {
          var otherSpriteRenderer = otherButton.gameObject.GetComponent<SpriteRenderer>();
          otherSpriteRenderer.color = Color.black;
        }
      }
    }
  }
}
