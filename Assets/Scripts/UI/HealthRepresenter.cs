using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthRepresenter : MonoBehaviour
{
    [SerializeField] private Image _healthImageFiller;
    [SerializeField] private Player _player;

    [SerializeField] private float _maxHealth;

    private void Awake()
    {
        if (_healthImageFiller == null) 
            throw new System.Exception("Image is not set");

        if (_player == null)
            throw new System.Exception("Player is not set");
    }

    void Update()
    {
        float health = _player.Health;
        _healthImageFiller.fillAmount = health / _maxHealth;
    }
}
