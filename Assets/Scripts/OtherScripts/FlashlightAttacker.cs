using UnityEngine;

public class FlashlightAttacker : MonoBehaviour
{
    private Collider2D _collider2D;
    [SerializeField] private uint _damage;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(typeof(Monster), out Component component))
        {
            Monster monster = component.GetComponent<Monster>();
            monster.GetDamage(_damage);
        }
    }
}
