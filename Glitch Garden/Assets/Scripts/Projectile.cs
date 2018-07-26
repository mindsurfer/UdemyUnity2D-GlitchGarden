using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
  public float Damage;
  public float Speed;

  // Use this for initialization
  void Start () 
  {
    
  }
  
  // Update is called once per frame
  void Update () 
  {
    transform.Translate(Vector3.right * Speed * Time.deltaTime);
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    var attackerHp = collider.gameObject.GetComponent<Health>();
    if (attackerHp)
    {
      attackerHp.TakeDamage(Damage);
      Destroy(gameObject);
    }
  }
}
