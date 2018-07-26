using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{
  public float Hitpoints;

  private StarDisplay _starDisplay;

  void Start()
  {
    _starDisplay = FindObjectOfType<StarDisplay>();
  }

  public void TakeDamage(float damage)
  {
    Hitpoints -= damage;

    if (!IsAlive())
    {
      // Optional death animation trigger point. From animator, when death animation finished, use event to call back into here to destroy the object from the scene.
      DestroyObject();
    }
  }

  public bool IsAlive()
  {
    return Hitpoints > 0;
  }

  public void DestroyObject()
  {
    // If an attacker dies, add to star currency before destroying object
    UpdateCurrency();
    Destroy(gameObject);
  }

  private void UpdateCurrency()
  {
    var attacker = GetComponent<Attacker>();
    if (attacker)
    {
      _starDisplay.AddStars(attacker.StarReward);
    }
  }
}
