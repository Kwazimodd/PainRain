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
}
