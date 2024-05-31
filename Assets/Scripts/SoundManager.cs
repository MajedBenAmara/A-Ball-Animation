using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip[] _audioClip = {};

    public static SoundManager Instance;
    private void Start()
    {
        Instance = this;
    }
    public void PlayBounce()
    {
        _audioSource.PlayOneShot(_audioClip[0]);
    }
    public void PlaySquish()
    {
        _audioSource.PlayOneShot(_audioClip[1]);
    }
    public void PlaySquash()
    {
        _audioSource.PlayOneShot(_audioClip[2]);
    }
}
