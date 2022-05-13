using System;
using System.Collections;
using UnityEngine;

public class Monster: BaseEntity
{
    [SerializeField] private uint _damage;
    [SerializeField] private float _followCooldown;
    [SerializeReference] private float _damageCooldown;

    public GameObject Target;

    public Spawner Spawner;

    private float _lastCollisionTime;
    private float _lastGetDamageTime;

    private void MoveToTarget()
    {
        try
        {
            if (_lastCollisionTime >= _followCooldown && Target != null)
            {
                Vector2 targetPoint = Target.transform.position;
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
        if (other.gameObject.Equals(Target))
        {
            other.gameObject.GetComponentInParent<BaseEntity>().GetDamage(_damage);
            _rigidbody2D.AddForce(-Velocity.normalized*10, ForceMode2D.Impulse);
            _lastCollisionTime = 0;
        }

        if (Target == null)
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
            _lastGetDamageTime = 0;
        }
    }
    
    private IEnumerator FlashLightMonster(Monster monster)
    {
        
        monster.ChangeColour(Color.white);
        yield return new WaitForSeconds(_damageCooldown/2);
        monster.ChangeColour(Color.red);
        yield return new WaitForSeconds(_damageCooldown/2);
        monster.ChangeColour(Color.white);
    }

    protected override void Kill()
    {
        Spawner.OnMonsterDied();
        switch (gameObject.name)
        {
            case "Ghost(Clone)":
                SoundManager.Instance.MakeSound(2);
                break;
            case "Ghastly(Clone)":
                SoundManager.Instance.MakeSound(3);
                break;
            case "Pumpkin(Clone)":
                SoundManager.Instance.MakeSound(0);
                break;
            case "Pumpkin2(Clone)":
                SoundManager.Instance.MakeSound(1);
                break;
        }
        GameObject.Destroy(gameObject);
    }
}