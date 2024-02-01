using UnityEngine;

public class InputFromMicrophone : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int maxFire;
    [SerializeField] private AudioLoudnessDetect detector;

    [SerializeField] private float loudnessSensibility = 100;
    [Range(0,25)] // 2 uygun deðer gibi
    [SerializeField] private float threshhold = 15f;
    [SerializeField] private float threshhold2 = 20f;

    public BulletManager bulletManager;
    public EnemySpawner enemySpawner;
    public float fireCooldown = 1.0f;  // Ateþleme aralýðý (saniye)
    private float currentCooldown = 0.0f;
    void Start()
    {
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        enemySpawner = GameObject.Find("ClownSpawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshhold)
        {
            loudness = 0;
        }

        if (loudness > threshhold && currentCooldown <= 0 && !UIManager.Instance.screamReady)
        {
            //Debug.Log("Loudness: " + loudness);
            //Debug.Log("Fireee");

            bulletManager.ShootBullet();

            currentCooldown = fireCooldown;  // Ateþleme aralýðý kadar cooldown baþlat
        }
        if(loudness > threshhold2 && UIManager.Instance.screamReady)
        {
            enemySpawner.AllDie();
        }
        // Ateþleme cooldown'u azalt
        currentCooldown = Mathf.Max(0, currentCooldown - Time.deltaTime);
    }
}
