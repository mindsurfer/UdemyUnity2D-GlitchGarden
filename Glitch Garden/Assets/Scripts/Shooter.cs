using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
  public GameObject Projectile;

  private GameObject _projectileParent;
  private Animator _animator;
  private Defender _defender;
  private Spawner _laneSpawner;
  private const string _projectileParentName = "Projectiles";

  void Start()
  {
    // Create the parent object that all projectiles will be nested under in code.
    _projectileParent = GameObject.Find(_projectileParentName);
    if (!_projectileParent)
    {
      _projectileParent = new GameObject(_projectileParentName);
      _projectileParent.transform.position = Vector3.zero;
    }

    _animator = GetComponent<Animator>();
    _defender = GetComponent<Defender>();
    SetLaneSpawner();
  }

  void Update()
  {
    if (AttackerInLane())
      _animator.SetBool(_defender.AttackParamName, true);
    else
      _animator.SetBool(_defender.AttackParamName, false);
  }

  private void SetLaneSpawner()
  {
    var spawners = GameObject.FindObjectsOfType<Spawner>();
    foreach (var spawner in spawners)
    {
      if (spawner.transform.position.y == transform.position.y)
      {
        _laneSpawner = spawner;
        return;
      }
    }

    Debug.LogError(name + " can't find lane spawner.");
  }

  private bool AttackerInLane()
  {
    if (!_laneSpawner) return false;
    if (_laneSpawner.transform.childCount <= 0) return false;

    foreach (Transform spawnEnemy in _laneSpawner.transform)
    {
      if (spawnEnemy.position.x >= transform.position.x)
        return true;
    }

    return false; //_laneSpawner.transform.childCount > 0;
  }

  private void Fire()
  {
    var projectile = Instantiate(Projectile);
    projectile.transform.parent = _projectileParent.transform;

    var gunTransform = gameObject.transform.Find("Gun");
    projectile.transform.position = gunTransform.position;
  }
}
