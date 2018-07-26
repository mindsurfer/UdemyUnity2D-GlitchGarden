using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour 
{
  public Slider SliderVolume;
  public Slider SliderDifficulty;
  public Text LabelVolume;
  public Text LabelDifficulty;
  public LevelManager LevelManager;

  private MusicManager _musicManager;
  private float _unsavedDifficulty;

  // Use this for initialization
  void Start () 
  {
    _musicManager = GameObject.FindObjectOfType<MusicManager>();
    SliderVolume.value = PlayerPrefsManager.GetMasterVolume();
    SliderDifficulty.value = PlayerPrefsManager.GetDifficulty();
  }

  public void SetDefaults()
  {
    SliderVolume.value = 0.5f;
    SliderDifficulty.value = 2f;
  }

  public void OnSliderVolumeValueChanged()
  {
    _musicManager.ChangeVolume(SliderVolume.value);
    LabelVolume.text = string.Format("{0}%", Mathf.Round(SliderVolume.value * 100));
  }

  public void OnSliderDifficultyValueChanged()
  {
    _unsavedDifficulty = SliderDifficulty.value;

    if (SliderDifficulty.value == 1f)
      LabelDifficulty.text = "Easy";
    if (SliderDifficulty.value == 2f)
      LabelDifficulty.text = "Medium";
    if (SliderDifficulty.value == 3f)
      LabelDifficulty.text = "Hard";
  }

  public void SaveAndExit()
  {
    PlayerPrefsManager.SetMasterVolume(SliderVolume.value);
    PlayerPrefsManager.SetDifficulty(_unsavedDifficulty);
    LevelManager.LoadLevel("01a Start");
  }
}
