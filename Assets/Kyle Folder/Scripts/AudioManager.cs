using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundClip
{
    MotherHugSound,
    PillSound,
    BottleSound,
}

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] soundClip;
    [SerializeField]
    public AudioSource SFXSource;
    [SerializeField]
    public AudioSource MusicSource;
    [SerializeField]
    private AudioClip musicClip;
    private static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        MusicSource.clip = musicClip;
        MusicSource.Play();
    }

    public static void PlaySound(SoundClip soundClip)
    {
        instance.SFXSource.PlayOneShot(instance.soundClip[(int)soundClip]);
    }
}
