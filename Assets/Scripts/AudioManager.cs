using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    BUTTONHOVER, //0
    BUTTONCLICK, //1
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static AudioManager instance;
    private AudioSource audioSource;  

    private void Awake()
    {
        instance = this;    
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }

    //Kelly, when you see this code feel free to alter and change anything I just think setting this up would be easier long term when it comes to properly adding the sounds
    // - Ur fav person, Beyonce
}
