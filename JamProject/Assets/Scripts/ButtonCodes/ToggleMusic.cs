using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusic : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Örneðin sahne baþladýðýnda sesin açýk olmasýný istiyorsanýz:
        audioSource.Play();
    }

    public void ToggleAudio()
    {
        if (audioSource.isPlaying)
        {
            // Eðer ses çalýyorsa, durdur.
            audioSource.Pause();
        }
        else
        {
            // Eðer ses çalmýyorsa, çalmaya baþla.
            audioSource.Play();
        }
    }
}
