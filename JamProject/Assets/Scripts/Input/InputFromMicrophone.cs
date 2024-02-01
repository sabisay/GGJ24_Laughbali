using UnityEngine;

public class InputFromMicrophone : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int maxFire;
    [SerializeField] private AudioLoudnessDetect detector;

    [SerializeField] private float loudnessSensibility = 100;
    [Range(0,25)] // 2 uygun de�er gibi
    [SerializeField] private float threshhold = 15f;
    [SerializeField] private float threshhold2 = 20f;

    public BulletManager bulletManager;
    public EnemySpawner enemySpawner;
    public float fireCooldown = 1.0f;  // Ate�leme aral��� (saniye)
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

            currentCooldown = fireCooldown;  // Ate�leme aral��� kadar cooldown ba�lat
        }
        if(loudness > threshhold2 && UIManager.Instance.screamReady)
        {
            enemySpawner.AllDie();
        }
        // Ate�leme cooldown'u azalt
        currentCooldown = Mathf.Max(0, currentCooldown - Time.deltaTime);
    }
}
