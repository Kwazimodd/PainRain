using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerAffector : Affector
{
    [SerializeField] private float healAmount;
    protected override void Affect(Player player)
    {
        player.Heal(healAmount);
    }
}
