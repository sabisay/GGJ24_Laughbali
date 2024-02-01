using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    private int currentSceneIndex;

public void NextScene()
{
    currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    StartCoroutine(LoadNextSceneAsync());
}

private IEnumerator LoadNextSceneAsync()
{
    int nextSceneIndex = (currentSceneIndex + 1) % UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;

    AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextSceneIndex);

    // Sahne yüklenene kadar bekle
    while (!asyncLoad.isDone)
    {
        yield return null;
    }
}
}
