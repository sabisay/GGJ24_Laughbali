using DG.Tweening;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    void Die()
    {
        // D��man�n �l�m� durumunda �a�r�l�r ve havuza geri d�ner.
        enemySpawner.EnemyDied(gameObject);
    }
}
