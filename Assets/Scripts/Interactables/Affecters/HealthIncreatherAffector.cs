using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncreatherAffector : Affector
{
    [SerializeField] private float increaseAmount;
    protected override void Affect(Player player)
    {
        player.IncreaseMaxHealth(increaseAmount);
    }
}
