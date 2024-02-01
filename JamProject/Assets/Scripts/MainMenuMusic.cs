using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    // M�zik dosyas� buradan atan�r
    public AudioClip musicClip;

    // Audio source nesnesi
    private AudioSource musicSource;

    void Start()
    {
        // M�zik i�in bir audio source bile�eni al
        musicSource = GetComponent<AudioSource>();

        // M�zi�i ayarla ve �almaya ba�la
        musicSource.clip = musicClip;
        musicSource.Play();
    }
}
