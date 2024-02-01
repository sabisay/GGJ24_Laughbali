using SurvivalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Range(-1, 3)]
    [SerializeField] private int health;

    public AudioClip gameOverSound;
    public AudioSource audioSource;
    private PlayerMovement playerMovement;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void AddHealt()
    {
        
        health++;
        if(health < 0)
        {
            UIManager.Instance.ChangeHealth(0);
            return;
        }
        if(health < 4) UIManager.Instance.ChangeHealth(health);
        else health--;
        Debug.Log(health);
    }

    public void Damage()
    {
        health -= 1;
        if (health == -1)
        {
            Dead();
        }
        else
        {
            if (health < -1) return;
            UIManager.Instance.ChangeHealth(health);
            UIManager.Instance.HitEffect();
            Debug.Log(health);
        }
    }

    public void Dead()
    {
        playerMovement.walkSound.enabled = false;
        GameManager.Instance.GameOver();
        audioSource.Play();
    }


}
