using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    // Müzik dosyasý buradan atanýr
    public AudioClip musicClip;

    // Audio source nesnesi
    private AudioSource musicSource;

    void Start()
    {
        // Müzik için bir audio source bileþeni al
        musicSource = GetComponent<AudioSource>();

        // Müziði ayarla ve çalmaya baþla
        musicSource.clip = musicClip;
        musicSource.Play();
    }
}
