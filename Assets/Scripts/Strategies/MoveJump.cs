using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJump : MonoBehaviour, IMovementStrategy
{
    float jump = 0;
    public Vector2 Move(Vector2 targetPoint, Vector3 monsterPosition, float speed)
    {
        Vector2 velocity = new Vector2();

        if (jump <= Time.time)
        {
            velocity = new Vector2(targetPoint.x - monsterPosition.x, targetPoint.y - monsterPosition.y).normalized * speed;
            jump = Time.time + 0.02f;
        }

        return velocity;
    }
}
