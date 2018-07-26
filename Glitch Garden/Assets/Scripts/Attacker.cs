using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour 
{
  public string AttackParamName;
  [Tooltip("Time between spawns")]
  public float SpawnTime;
  public int StarReward;

  private float _currentMoveSpeed;
  private GameObject _currentTarget;
  private Animator _animator;

  // Use this for initialization
  void Start () 
  {
    _animator = gameObject.GetComponent<Animator>();
  }
  
  // Update is called once per frame
  void Update ()
  {
    transform.Translate(Vector3.left * _currentMoveSpeed * Time.deltaTime);
    CheckTargetStillAlive();
  }

  private void CheckTargetStillAlive()
  {
    if (!_currentTarget)
    {
      _animator.SetBool(AttackParamName, false);
    }
  }

  public void SetCurrentMoveSpeed(float speed)
  {
    _currentMoveSpeed = speed;
  }

  // Gets called from animation event
  public void StrikeCurrentTarget(float damage)
  {
    if (!_currentTarget)
      return;

    var hp = _currentTarget.GetComponent<Health>();
    if (!hp)
    {
      Debug.LogWarning("No health component found on " + _currentTarget.name);
      return;
    }

    hp.TakeDamage(damage);
  }

  public virtual void Attack(GameObject target)
  {
    _currentTarget = target;
    _animator.SetBool(AttackParamName, true);
  }
}
