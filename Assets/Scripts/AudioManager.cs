using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void PlayAudio(int clip)
    {
        _audioSource.PlayOneShot(_audioClips[clip]);
    }

    public void PlayGameEndAudio()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_audioClips[1]);
    }

}
