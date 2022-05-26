using System;
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

    public Action OnAffect;

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
        Player player = collision.gameObject.GetComponent<Player>();

        if (player == null) 
            return; 

        //playing audio
        AudioSource.PlayClipAtPoint(sound, transform.position);

        //playing particles
        ParticleSystem newParticleSystem = Instantiate(particleSystem, transform.position, Quaternion.identity);

        //performing action
        Affect(player);

        OnAffect.Invoke();

        //disabling
        this.gameObject.SetActive(false);
    }
}
