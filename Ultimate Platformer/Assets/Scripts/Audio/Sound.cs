using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SoundList
{
    Jump,
    CorrectInput,
    IncorrectInput,
    DieInLava,
    DieInSpike,
    ComboBurst,
    HeatResistance,
    EMP,
    LowGravity,
    ButtonPress
}

[System.Serializable]
public class Sound
{
    // as we are going to add audio in the AudioManager gameObject, we need a reference
    public AudioClip clip;
    public SoundList soundList;
    [HideInInspector] public AudioSource source;
    [HideInInspector] public float originalVolume;
    [Range(0f, 2f)] public float volume;
    [Range(0.1f, 3f)] public float pitch;
    // determine 2D or 3D sound.
    [Range(0f, 1f)] public float reverbZoneMix;
}

