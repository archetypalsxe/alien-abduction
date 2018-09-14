using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] audioClips;
    Dictionary<string, AudioSource> audioSources;

    [SerializeField]
    public float volume = 1f;

    void Awake()
    {
        int audioCount = audioClips.Length;
        audioSources = new Dictionary<string, AudioSource>();
        for (int i = 0; i < audioCount; i++)
        {
            audioSources[audioClips[i].name] = gameObject.AddComponent<AudioSource>();
            audioSources[audioClips[i].name].clip = audioClips[i];
        }
    }

    public void Play(string _Name)
    {
        AudioSource audio = FindAudioSource(_Name);
        audio.volume = volume;
        audio.Play();
    }
    public void Play(string name, bool loop)
    {
        AudioSource audio = FindAudioSource(name);
        audio.volume = volume;
        audio.loop = loop;
        audio.Play();
    }

    public AudioSource FindAudioSource(string _Name)
    {
        if (audioSources[_Name] == null)
            print("WARNING: Audio Couldnt Be Found");
        return audioSources[_Name];
    }

    public void PlayRandom()
    {
        int randomIndex = Random.Range(0, audioClips.Length);
        AudioSource audio = FindAudioSource(audioClips[randomIndex].name);
        audio.volume = volume;
        audio.Play();
    }
}
