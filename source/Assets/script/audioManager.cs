using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public GameObject sfxAudioSource;


    private void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Background AudioSource is not assigned.");
        }
    }

    public void PlaySFX(Vector3 spawn)
    {
        GameObject.Instantiate(sfxAudioSource, spawn , Quaternion. identity);
    }
}
