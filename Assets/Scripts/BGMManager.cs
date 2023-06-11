using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
    public AudioClip menuMusic;
    public AudioClip inGameMusic;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(menuMusic);
        StartCoroutine(GameStartFadeOut());
    }

    IEnumerator GameStartFadeOut()
    {
        while (_audioSource.volume < 0.5f)
        {
            _audioSource.volume *= 1.01f;
            yield return null;
        }
    }

    public void ChangeMusic()
    {
        StartCoroutine(ChangeMusicFadeOut());
    }

    IEnumerator ChangeMusicFadeOut()
    {
        while (_audioSource.volume > 0.1f)
        {
            _audioSource.volume *= 0.99f;
            yield return null;
        }
        _audioSource.Stop();
        _audioSource.clip = inGameMusic;
        _audioSource.Play();
        StartCoroutine(ChangeMusicFadeIn());
    }

    IEnumerator ChangeMusicFadeIn()
    {
        while (_audioSource.volume < 0.5f)
        {
            _audioSource.volume *= 1.01f;
            yield return null;
        }
    }
}
