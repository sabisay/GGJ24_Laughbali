using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Button voice;
    public Sprite imageLowSprite;
    public Sprite imageHighSprite;

    private bool isHigh;
    void Start()
    {
        isHigh = true; // Başlangıçta yüksek olmadığını varsayalım
        // İlk başta yüksek resmi etkinleştir
        UpdateButtonImage();
        voice.onClick.AddListener(ChangeImage);
    }

    void ChangeImage()
    {
        isHigh = !isHigh;
        UpdateButtonImage();
    }

    void UpdateButtonImage()
    {
        if (isHigh)
        {
            voice.image.sprite = imageHighSprite;
        }
        else
        {
            voice.image.sprite = imageLowSprite;
        }
    }
}
