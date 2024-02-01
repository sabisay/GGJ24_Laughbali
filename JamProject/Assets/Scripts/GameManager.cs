using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private PlayerManager playerManager;

    public int enemyWave;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        Debug.Log(playerManager);
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
        NewWave();
    }

    public void GameOver()
    {
        Debug.Log("Player Dead");
        UIManager.Instance.PlayerDead();
    }

    public void PlayerDamaged()
    {
        playerManager.Damage();
    }

    public void NewWave()
    {
        enemyWave += 1;
        
    }
}
