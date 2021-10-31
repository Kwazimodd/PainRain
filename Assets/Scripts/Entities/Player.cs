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



    public void GetSlowDowned() 
    {
        if (!_isOnPuddle) 
        {
            moveSpeed /= 2;
            _isOnPuddle = true;
            Move(Velocity.normalized * moveSpeed);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(typeof(Puddle), out Component component) && _isOnPuddle)
        {
            moveSpeed *= 2;
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