using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource[] musicSources; // Array of music sources
    public AudioSource [] sfxSources;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("base", 0); // Play music on the first music source
    }

    public void PlayMusic(string name, int musicSourceIndex)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else if (musicSourceIndex < 0 || musicSourceIndex >= musicSources.Length)
        {
            Debug.Log("Invalid music source index");
        }
        else
        {
            musicSources[musicSourceIndex].clip = s.clip;
            musicSources[musicSourceIndex].Play();
        }
    }

    public void StopMusic(int musicSourceIndex)
    {
        if (musicSourceIndex >= 0 && musicSourceIndex < musicSources.Length)
        {
            musicSources[musicSourceIndex].Stop();
        }
    }

    public void PlaySFX(string name, int sfxSourceIndex)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSources[sfxSourceIndex].PlayOneShot(s.clip);
        }
    }
}
