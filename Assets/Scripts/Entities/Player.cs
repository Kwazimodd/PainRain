using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player: BaseEntity
{
    private bool _isOnPuddle = false;
    
    public int Health
    {
        get 
        {
            return health;
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputMovement = value.Get<Vector2>();
        Move(inputMovement*moveSpeed);
    }

    private void Move(Vector2 velocityVector)
    {
        Velocity = velocityVector;
    }

    public void GetSlowDowned(float modifier) 
    {
        if (!_isOnPuddle) 
        {
            moveSpeed *= modifier;
            _isOnPuddle = true;
            Move(Velocity.normalized * moveSpeed);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Puddle>(out Puddle puddle) && _isOnPuddle)
        {
            moveSpeed /= puddle.SpeedModifier;
            _isOnPuddle = false;
            Move(Velocity.normalized*moveSpeed);
        }
        
    }

    protected override void Kill()
    {
        base.Kill();
        SceneManager.LoadScene("GameMap", LoadSceneMode.Single);
    }
}