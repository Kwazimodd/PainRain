using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
   [SerializeField] private float _speedChanger;
   private Collider2D _collider2D;

   private void Awake()
   {
      _collider2D = GetComponent<Collider2D>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.TryGetComponent(typeof(Player), out Component component))
      {
         Debug.Log("123");
         component.GetComponent<Player>().ChangeMoveSpeed(_speedChanger);
      }   
   }
   
   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.TryGetComponent(typeof(Player), out Component component))
      {
         Debug.Log("456");
         component.GetComponent<Player>().ChangeMoveSpeed(1/_speedChanger);
      }   
   }
}
