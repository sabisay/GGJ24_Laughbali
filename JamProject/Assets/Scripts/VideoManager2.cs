using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager2 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public bool videoFinished;
    public Button buton;

    void Start()
    {
        // VideoPlayer'ýn loopPointReached event'ini dinle
        videoPlayer.loopPointReached += OnVideoEnd;
        StartCoroutine(PlayVideoAndLoadSceneAsync());
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video bitti");
        videoFinished = true;
    }

    IEnumerator PlayVideoAndLoadSceneAsync()
    {
        // Video baþlatýlýr
        videoPlayer.Play();

        // Videonun ilk saniyesini bekler
        yield return new WaitForSeconds(13.0f);

        buton.gameObject.SetActive(true);


    }
}
