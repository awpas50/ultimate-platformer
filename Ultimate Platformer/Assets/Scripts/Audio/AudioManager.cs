using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // ref:https://www.youtube.com/watch?v=6OT43pvUyfY

    public Sound[] sounds;
    public static AudioManager instance;
    public static Dictionary<SoundList, float> soundTimerDict;
    public static Dictionary<SoundList, bool> soundConditionDict;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        soundConditionDict = new Dictionary<SoundList, bool>();
        soundTimerDict = new Dictionary<SoundList, float>();

        foreach (SoundList val in Enum.GetValues(typeof(SoundList)))
        {
            soundConditionDict[val] = false;
            soundTimerDict[val] = 0;
        }
    }

    public static bool CanPlaySound(SoundList sound, float CD)
    {
        Debug.Log(Time.time + CD + " " + soundTimerDict[sound]);
        float lastTimePlayed = soundTimerDict[sound];
        if (lastTimePlayed + CD < Time.time)
        {
            soundTimerDict[sound] = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }

    // for playing in Trigger
    public void Play(SoundList soundList)
    {
        // Create an empty game object, than add a audioSource & audioClip on it.
        GameObject soundGameObject = new GameObject("Sound " + (int)soundList);
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        AudioClip audioClip = GetAudioClip(soundList);

        audioSource.volume = GetVolume(soundList);
        audioSource.pitch = GetPitch(soundList);
        audioSource.reverbZoneMix = GetReverbZoneMix(soundList);
        audioSource.PlayOneShot(audioClip);

        Destroy(soundGameObject, 5f);
    }

    // Play only once (for playing in Update() function so that the clip won't play every frame.)
    // If you want to play the sound again, make sure to assign the soundConditionDict[soundList] to false in any other scripts.
    public void PlayOnce(SoundList soundList)
    {
        if (soundConditionDict[soundList] == false)
        {
            // Create an empty game object, than add a audioSource & audioClip on it.
            GameObject soundGameObject = new GameObject("Sound " + (int)soundList);
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            AudioClip audioClip = GetAudioClip(soundList);

            audioSource.volume = GetVolume(soundList);
            audioSource.pitch = GetPitch(soundList);
            audioSource.reverbZoneMix = GetReverbZoneMix(soundList);
            audioSource.PlayOneShot(audioClip);

            soundConditionDict[soundList] = true;
            Destroy(soundGameObject, 10f);
        }
    }

    public void PlayContinuously(SoundList soundList, float CD)
    {
        if (CanPlaySound(soundList, CD))
        {
            // Create an empty game object, than add a audioSource & audioClip on it.
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            AudioClip audioClip = GetAudioClip(soundList);

            audioSource.volume = GetVolume(soundList);
            audioSource.pitch = GetPitch(soundList);
            audioSource.reverbZoneMix = GetReverbZoneMix(soundList);
            audioSource.PlayOneShot(audioClip);

            Destroy(soundGameObject, 10f);
        }
    }

    public AudioClip GetAudioClip(SoundList soundList)
    {
        // Access particular clip according to the enum variable.
        foreach (Sound s in sounds)
        {
            if (s.soundList == soundList)
            {
                return s.clip;
            }
        }
        Debug.LogError("Sound " + soundList + " not found!");
        return null;
    }

    public float GetVolume(SoundList soundList)
    {
        foreach (Sound s in sounds)
        {
            if (s.soundList == soundList)
            {
                return s.volume;
            }
        }
        return 0;
    }

    public float GetPitch(SoundList soundList)
    {
        foreach (Sound s in sounds)
        {
            if (s.soundList == soundList)
            {
                return s.pitch;
            }
        }
        return 0;
    }

    public float GetReverbZoneMix(SoundList soundList)
    {
        foreach (Sound s in sounds)
        {
            if (s.soundList == soundList)
            {
                return s.reverbZoneMix;
            }
        }
        return 0;
    }
}
