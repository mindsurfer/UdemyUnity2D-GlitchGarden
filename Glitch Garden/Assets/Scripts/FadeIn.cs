using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour 
{
  public float FadeInDuration;

  private Image _fadePanel;
  //private Color _currentColor = Color.black;

  // Use this for initialization
  void Start () 
  {
    _fadePanel = gameObject.GetComponent<Image>();
    _fadePanel.CrossFadeAlpha(0f, FadeInDuration, false);
  }

  // Update is called once per frame
  void Update () 
  {
    // Alternate and easier approach
    //_fadePanel.CrossFadeAlpha(1f, FadeInDuration, false);

    // THIS WORKS, remember color.a is 0..1, not 0..255
    //if (Time.timeSinceLevelLoad < FadeInDuration)
    //{
    //  // Fade in
    //  var alphaChange = Time.deltaTime / FadeInDuration;
    //  _currentColor.a -= alphaChange;
    //  _fadePanel.color = _currentColor;
    //}
    //else
    //  gameObject.SetActive(false);
  }
}
