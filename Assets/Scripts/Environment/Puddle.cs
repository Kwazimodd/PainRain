using UnityEngine;

public class Puddle : MonoBehaviour
{
    [SerializeField] private float _speedModifier;
    private Collider2D _collider2D;

    public float SpeedModifier => _speedModifier;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    public Puddle Clone() 
    {
        return (Puddle)this.MemberwiseClone();
    }

}
