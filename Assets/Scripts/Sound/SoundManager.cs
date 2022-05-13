using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }

    [SerializeField]
    AudioSource rain;

    [SerializeField]
    AudioSource sound;

    [SerializeField]
    List<AudioClip> audioClips; 
    
    public void MakeSound(int soundID)
    {
        sound.clip = audioClips[soundID];
        sound.Play();
    }
}
