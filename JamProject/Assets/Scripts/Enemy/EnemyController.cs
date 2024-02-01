using DG.Tweening;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    void Die()
    {
        // Düþmanýn ölümü durumunda çaðrýlýr ve havuza geri döner.
        enemySpawner.EnemyDied(gameObject);
    }
}
