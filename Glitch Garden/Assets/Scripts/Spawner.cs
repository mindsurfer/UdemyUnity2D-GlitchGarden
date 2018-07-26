using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
  //public GameObject FoxPrefab;
  //public GameObject LizardPrefab;
  public GameObject[] AttackerPrefabs;

  //private float _foxSpawnTime;
  //private float _lizardSpawnTime;

  //private float _currentFoxTimer;
  //private float _currentLizardTimer;

  // Use this for initialization
  void Start () 
  {
    //_foxSpawnTime = FoxPrefab.GetComponent<Attacker>().SpawnTime;
    //_lizardSpawnTime = LizardPrefab.GetComponent<Attacker>().SpawnTime;
    //_currentFoxTimer = 0f;
    //_currentLizardTimer = 0f;
  }

  // Update is called once per frame
  void Update () 
  {
    //_currentFoxTimer += Time.deltaTime;
    //_currentLizardTimer += Time.deltaTime;

    //if (_currentFoxTimer >= _foxSpawnTime)
    //{
    //  var fox = Instantiate(FoxPrefab, transform.position, Quaternion.identity);
    //  fox.transform.parent = transform;
    //  _currentFoxTimer = 0f;
    //}

    //if (_currentLizardTimer >= _lizardSpawnTime)
    //{
    //  var lizard = Instantiate(LizardPrefab, transform.position, Quaternion.identity);
    //  lizard.transform.parent = transform;
    //  _currentLizardTimer = 0f;
    //}

    foreach (var attackerObject in AttackerPrefabs)
    {
      if (IsTimeToSpawn(attackerObject))
        Spawn(attackerObject);
    }
  }

  private bool IsTimeToSpawn(GameObject attackerGameObject)
  {
    var attacker = attackerGameObject.GetComponent<Attacker>();

    var meanSpawnDelay = attacker.SpawnTime;
    float spawnsPerSecond = 1 / meanSpawnDelay; // If spawn time is 10 seconds, then per second is 0.1 (1/10) ie after 10 checks, it's spawn time.

    if (Time.deltaTime > meanSpawnDelay)
    {
      Debug.LogWarning("Spawn rate capped by frame rate");
    }

    var threshold = spawnsPerSecond * Time.deltaTime / 5; // 5 spawn lanes

    return Random.value < threshold;
  }

  public void Spawn(GameObject attackerObject)
  {
    var attacker = Instantiate(attackerObject, transform.position, Quaternion.identity);
    attacker.transform.parent = transform;
  }
}
