using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusic : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // �rne�in sahne ba�lad���nda sesin a��k olmas�n� istiyorsan�z:
        audioSource.Play();
    }

    public void ToggleAudio()
    {
        if (audioSource.isPlaying)
        {
            // E�er ses �al�yorsa, durdur.
            audioSource.Pause();
        }
        else
        {
            // E�er ses �alm�yorsa, �almaya ba�la.
            audioSource.Play();
        }
    }
}
