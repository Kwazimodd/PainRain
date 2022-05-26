using UnityEngine;


public abstract class BaseEntity : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float health;

    [SerializeField] protected float moveSpeed;

    protected Rigidbody2D _rigidbody2D;
    protected Collider2D _collider2D;
    protected Animator _animator;
    protected SpriteRenderer _spriteRenderer;


    public Vector2 Velocity
    {
        get { return _rigidbody2D.velocity; }
        set
        {
            _rigidbody2D.velocity = value;
            OnVelocityChange();
        }
    }

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void IncreaseMaxHealth(float value)
    {
        maxHealth += value;
    }

    public virtual void Heal(float value)
    {
        health += value;
        if (health > maxHealth)
            health = maxHealth;
    }

    public virtual void Damage(float value)
    {
        health -= value;
        if (health <= 0)
            Kill();
    }

    protected virtual void Kill()
    {
        GameObject.Destroy(gameObject);
    }

    protected virtual void OnVelocityChange()
    {
        if (Velocity == Vector2.zero)
        {
            _animator.SetBool("Idle", true);
        }
        else
        {
            _animator.SetBool("Idle", false);

            if ((int)Velocity.x > 0)
            {
                _animator.SetInteger("move", 1);
            }
            else if ((int)Velocity.x < 0)
            {
                _animator.SetInteger("move", 3);
            }
            else if ((int)Velocity.y > 0)
            {

                _animator.SetInteger("move", 2);
            }
            else if ((int)Velocity.y < 0)
            {
                _animator.SetInteger("move", 0);
            }
        }
    }

    public void ChangeColour(Color color)
    {
        _spriteRenderer.color = color;
    }
}
