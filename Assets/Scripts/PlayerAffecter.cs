using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAffecter : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(typeof(Puddle), out Component component))
        {
            _player.GetSlowDowned();
        }
    }
}
