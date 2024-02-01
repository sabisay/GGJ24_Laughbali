using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    //public GameObject bulletPrefab;
    //public float bulletSpeed = 5f;

    //private static Transform bulletsContainer;  // Mermi objelerinin parent'ý
    //private static GameObject[] bulletPool;
    //private static int poolSize = 10; // Choose an appropriate pool size
    //private static int currentBulletIndex;

    //void Start()
    //{
    //    // Mermi havuzunu baþlat
    //    InitializeBulletPool();
    //}

    //void InitializeBulletPool()
    //{
    //    if (bulletsContainer == null)
    //    {
    //        bulletsContainer = new GameObject("EnemyContainer").transform;  // Mermi objelerini içeren parent oluþtur
    //        bulletPool = new GameObject[poolSize];

    //        for (int i = 0; i < poolSize; i++)
    //        {
    //            bulletPool[i] = Instantiate(bulletPrefab, bulletsContainer);
    //            bulletPool[i].SetActive(false);
    //        }
    //    }
    //}

    //public void ShootBullet()
    //{
    //    // Mermiyi ateþle
    //    GameObject bullet = GetNextBullet();

    //    if (bullet != null)
    //    {
    //        Vector3 spawnPosition = transform.position + transform.forward;
    //        bullet.transform.position = spawnPosition;
    //        bullet.SetActive(true);
    //        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
    //        bulletRb.velocity = transform.forward * bulletSpeed;
    //    }
    //}

    //GameObject GetNextBullet()
    //{
    //    // Mermi havuzundan bir sonraki mermiyi al
    //    GameObject nextBullet = bulletPool[currentBulletIndex];
    //    currentBulletIndex = (currentBulletIndex + 1) % poolSize;

    //    return nextBullet;
    //}

    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.K)) // burayý kapat 
    //    {
    //        ShootBullet();
    //    }
    //}
}
