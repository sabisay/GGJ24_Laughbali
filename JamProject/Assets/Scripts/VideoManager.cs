using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public bool videoFinished;

    void Start()
    {
        // VideoPlayer'�n loopPointReached event'ini dinle
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
        // Video ba�lat�l�r
        videoPlayer.Play();

        // Videonun ilk saniyesini bekler
        yield return new WaitForSeconds(18.0f);

        // Video bittikten sonra di�er sahneyi y�kler
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(2);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
