using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNormal : MonoBehaviour, IMovementStrategy
{
    public Vector2 Move(Vector2 targetPoint, Vector3 monsterPosition, float speed)
    {
        return new Vector2(targetPoint.x - monsterPosition.x, targetPoint.y - monsterPosition.y).normalized * speed;
    }
}
