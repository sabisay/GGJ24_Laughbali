using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int healt;
    public float pushRate;
    public int score;

    private EnemySpawner spawner;
    private BaloonManager baloonManager;

    public void Attack()
    {
        GameManager.Instance.PlayerDamaged();
    }

    private void Start()
    {
        spawner = GameObject.Find("ClownSpawner").GetComponent<EnemySpawner>();
        baloonManager = GameObject.Find("BaloonManager").GetComponent<BaloonManager>();
    }

    public void Damaged()
    {
        Dead();

        //if (healt == 0)
        //{
        //    Dead();
        //}
        //else
        //{
        //    healt--;
        //    Rigidbody bulletRb = GetComponent<Rigidbody>();
        //    bulletRb.velocity = transform.forward * pushRate * -1;

        //}
    }

    public void Dead()
    {
        UIManager.Instance.score += 10;
        UIManager.Instance.scoreText.text = UIManager.Instance.score.ToString();
        spawner.EnemyDied(gameObject);
        baloonManager.FlyBaloon(gameObject.transform);
        Debug.Log("score: "+score);
        UIManager.Instance.ScreamCheck();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.HitEffect();

            Attack();
            Debug.Log("attacked to player");
        }else if (other.CompareTag("Bullet"))
        {
            Damaged();
        }
    }

}
