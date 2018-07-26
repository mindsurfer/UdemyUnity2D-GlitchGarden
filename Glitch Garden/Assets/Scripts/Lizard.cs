using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour 
{
  private Attacker _attacker;

  // Use this for initialization
  void Start () 
  {
    _attacker = gameObject.GetComponent<Attacker>();
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    //Debug.Log(name + " trigger enter by " + collider);
    if (collider.gameObject.GetComponent<Defender>())
      _attacker.Attack(collider.gameObject);
  }
}
