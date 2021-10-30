using System;
using System.Collections;
using UnityEngine;

public class Monster: BaseEntity
{
    [SerializeField] private uint _damage;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _followCooldown;
    [SerializeReference] private float _damageCooldown;
    private float _lastCollisionTime;
    private float _lastGetDamageTime;

    private void MoveToTarget()
    {
        try
        {
            if (_lastCollisionTime >= _followCooldown && _target != null)
            {
                Vector2 targetPoint = _target.transform.position;
                Vector3 monsterPosition = _rigidbody2D.transform.position;
                Velocity =
                    new Vector2(targetPoint.x - monsterPosition.x, targetPoint.y - monsterPosition.y).normalized *
                    moveSpeed;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void Update()
    {
        UpdateCooldowns();
        MoveToTarget();
    }

    private void UpdateCooldowns()
    {
        _lastGetDamageTime += Time.deltaTime;
        _lastCollisionTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(_target))
        {
            other.gameObject.GetComponent<BaseEntity>().GetDamage(_damage);
            _rigidbody2D.AddForce(-Velocity.normalized*10, ForceMode2D.Impulse);
            _lastCollisionTime = 0;
        }

        if (_target == null)
        {
            Velocity = Vector2.zero;
        }
    }

    public override void GetDamage(uint damage)
    {
        if (_lastGetDamageTime >= _damageCooldown)
        {
            StartCoroutine(FlashLightMonster(this));
            base.GetDamage(damage);
            StartCoroutine(FlashLightMonster(this));
            _lastGetDamageTime = 0;
        }
    }
    
    private IEnumerator FlashLightMonster(Monster monster)
    {
        monster.ChangeColour(Color.red);
        yield return new WaitForSeconds(_damageCooldown);
        monster.ChangeColour(Color.white);
    }
}