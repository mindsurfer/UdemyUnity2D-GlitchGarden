using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour 
{
  public string JumpTriggerName;

  private Attacker _attacker;
  private Animator _animator;

  // Use this for initialization
  void Start () 
  {
    _attacker = gameObject.GetComponent<Attacker>();
    _animator = gameObject.GetComponent<Animator>();
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    //Debug.Log(name + " trigger enter by " + collider);

    if (collider.gameObject.GetComponent<GraveStone>())
      _animator.SetTrigger(JumpTriggerName);
    else if (collider.gameObject.GetComponent<Defender>())
      _attacker.Attack(collider.gameObject);
  }
}
