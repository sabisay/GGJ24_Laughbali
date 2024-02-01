using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public GameObject clownPrefab;
    public int poolSize = 10;

    private Transform clownContainer;  // Clown objelerinin parent'ý
    private GameObject[] clownPool;
    private int currentClownIndex;
    public Vector3[] spawnPositions;
    private Transform playerTransform;

    public float spawnRate; //kaç saniyede bir yeni enemy spawn olacak ?
    public EnemyManager enemyManager;
    public BaloonManager baloonManager;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        baloonManager = GameObject.Find("BaloonManager").GetComponent<BaloonManager>();
        InitializeClownPool();
        InvokeRepeating("CreateClown", 1.0f, spawnRate);
    }

    void InitializeClownPool()
    {
        clownContainer = new GameObject("ClownContainer").transform;  // Clown objelerini içeren parent oluþtur
        clownPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            clownPool[i] = Instantiate(clownPrefab, clownContainer);
            clownPool[i].SetActive(false);
        }
    }

    public void EnemyDied(GameObject deadClown)
    {
        deadClown.SetActive(false);
    }

    public void CreateClown()
    {
        GameObject clown = GetNextClown();

        Vector3 spawnPos = playerTransform.position + spawnPositions[Random.Range(0, spawnPositions.Length)];
        Quaternion spawnRotation = Quaternion.identity; // Set the rotation to identity (no rotation)

        clown.transform.position = spawnPos;
        clown.transform.rotation = spawnRotation; // Set the rotation
        clown.SetActive(true);
    }

    GameObject GetNextClown()
    {
        // Mermi havuzundan bir sonraki mermiyi al
        GameObject nextClown = clownPool[currentClownIndex];
        currentClownIndex = (currentClownIndex + 1) % poolSize;

        return nextClown;
    }
    public void AllDie()
    {
        CancelInvoke("CreateClown");
        StartCoroutine("GoToNextScene");
        for (int i = 0; i < poolSize; i++)
        {
            if (clownPool[i].activeInHierarchy)
            {
                clownPool[i].SetActive(false);
                baloonManager.FlyBaloon(clownPool[i].transform);
            }
        }

    }

    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.L)) // burayý kapat 
    //    {
    //        AllDie();
    //    }if (Input.GetKeyUp(KeyCode.V)) // burayý kapat 
    //    {
    //        CreateClown();
    //    }
    //}

    IEnumerator GoToNextScene()
    {
        yield return new WaitForSecondsRealtime(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
}
