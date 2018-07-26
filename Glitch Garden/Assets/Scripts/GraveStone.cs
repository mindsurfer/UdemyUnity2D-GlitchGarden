using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Defender))]
public class GraveStone : MonoBehaviour 
{
  private Animator _animator;

  void Start()
  {
    _animator = GetComponent<Animator>();
  }

  void OnTriggerStay2D(Collider2D collider)
  {
    _animator.SetTrigger("underAttackTrigger");
  }
}
