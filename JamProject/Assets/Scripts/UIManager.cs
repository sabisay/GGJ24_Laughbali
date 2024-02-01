using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Sprite[] healthBarSprites;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image hitEffect;

    [SerializeField] private GameObject deadScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private TMP_Text lastScore;

    [SerializeField] private GameObject screamImage;

    public TMP_Text scoreText;
    public float score;
    PlayerManager playerManager;
    public bool screamReady;

    
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
        playerManager = GameObject.Find("Canvas").GetComponent<PlayerManager>();
        healthBar.sprite = healthBarSprites[^1];
        
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.T))
    //    {
    //        playerManager.Damage();
    //    }
    //    if (Input.GetKeyDown(KeyCode.Y))
    //    {
    //        playerManager.AddHealt();
    //    }
    //}
    public void ChangeHealth(int healthIndex)
    {
        healthBar.sprite = healthBarSprites[healthIndex];
    }

    public void PlayerDead()
    {
        Time.timeScale = 0;
        deadScreen.gameObject.SetActive(true);
        lastScore.gameObject.SetActive(true);
        lastScore.text = score.ToString();
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayerWin()
    {
        Time.timeScale = 0;
        winScreen.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
    }

    public void ScreamCheck()
    {
        if(score > 500)
        {
            screamReady = true;
            screamImage.SetActive(true);
            //eðer buraya girerse ekranda scream yazýsý çýksýn
        }
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void HitEffect()
    {
        hitEffect.gameObject.SetActive(true);
        hitEffect.DOFade(1, 1f).OnComplete(() => { hitEffect.DOFade(0, 3f); /*hitEffect.gameObject.SetActive(false);*/});
        
    }
}
