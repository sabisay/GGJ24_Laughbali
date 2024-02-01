using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaloonManager : MonoBehaviour
{
    public GameObject baloonPrefab;
    public int poolSize = 10;

    private Transform baloonContainer;  // Balon objelerinin parent'ý
    private GameObject[] baloonPool;
    private int currentBaloonIndex;

    public GameObject enemy;

    void Start()
    {
        // Mermi havuzunu baþlat
        InitializeBaloonPool();
    }

    void InitializeBaloonPool()
    {
        baloonContainer = new GameObject("BaloonContainer").transform;  // Mermi objelerini içeren parent oluþtur
        baloonPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            baloonPool[i] = Instantiate(baloonPrefab, baloonContainer);
            baloonPool[i].SetActive(false);
        }
    }

    public void FlyBaloon(Transform transform)
    {
        GameObject baloon = GetNextBaloon();
        baloon.transform.position = transform.position;
        baloon.SetActive(true);
        baloon.transform.DOMoveY(transform.position.y+ 10,10);
    }


    GameObject GetNextBaloon()
    {
        GameObject nextBaloon = baloonPool[currentBaloonIndex];
        currentBaloonIndex = (currentBaloonIndex + 1) % poolSize;

        return nextBaloon;
    }

}
