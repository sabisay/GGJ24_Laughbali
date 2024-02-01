using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 10;
    public float bulletSpeed =50f;

    private Transform bulletsContainer;  // Mermi objelerinin parent'ý
    private GameObject[] bulletPool;
    private int currentBulletIndex;

    private PlayerMovement playerMovement;

    public GameObject player;
    public GameObject camera;

    public AudioSource audioSource;

    void Start()
    {
        // Mermi havuzunu baþlat
        InitializeBulletPool();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        //audioSource.GetComponent<AudioSource>();
    }

    void InitializeBulletPool()
    {
        bulletsContainer = new GameObject("PlayerBulletsContainer").transform;  // Mermi objelerini içeren parent oluþtur
        bulletPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            bulletPool[i] = Instantiate(bulletPrefab, bulletsContainer);
            bulletPool[i].SetActive(false);
        }
    }

    public void ShootBullet()
    {
        // Mermiyi ateþle
        GameObject bullet = GetNextBullet();

        //////////Normal ateþ////////
        Vector3 spawnPosition = transform.position + transform.forward;
        bullet.transform.position = spawnPosition;
        bullet.SetActive(true);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;
        audioSource.Play();

    }


    GameObject GetNextBullet()
    {
        // Mermi havuzundan bir sonraki mermiyi al
        GameObject nextBullet = bulletPool[currentBulletIndex];
        currentBulletIndex = (currentBulletIndex + 1) % poolSize;

        return nextBullet;
    }

    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.Mouse0)) // burayý kapat 
    //    {
    //        ShootBullet();
    //    }
    //}
}
