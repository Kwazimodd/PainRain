using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAffecter : MonoBehaviour
{
    private Player _player;
    DoNothing nothing;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        nothing = new DoNothing();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Puddle>(out Puddle puddle))
        {
            DoDamage doDamage = new DoDamage(nothing);
            SlowDown slowDown = new SlowDown(doDamage);

            slowDown.DoAffect(_player);
            //_player.GetSlowDowned(puddle.SpeedModifier);
        }
    }
}
