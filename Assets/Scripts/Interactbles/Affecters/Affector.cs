using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class for template method. Used for audio, performing action and particles.
/// </summary>
///
[RequireComponent(typeof(Collider2D))]
public abstract class Affector : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private ParticleSystem particleSystem;

    private AudioSource audioSource;
    private Collider2D collider;
    protected abstract void Affect(Player player);
    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player == null)
            return;

        //playing audio

        //playing particles

        //performing action
        Affect(player);

        //disabling
        this.gameObject.SetActive(false);
    }
}
