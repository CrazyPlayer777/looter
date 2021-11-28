using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] Levels;
    public GameObject Fx,Ragdoll,Explosion;
    int CurrentLevel;
    [Header("UI")]
    public GameObject GamePlayUI;
    public GameObject GameWinUI;
    public GameObject GameOverUI;

    public Text LevelText,CashCollect,TargetCash;

    public bool isGameOver;
    [HideInInspector]
    public int ObstacleCount,ObstacleCollected;
    public bool attacked;

    bool LevelComplete;
   

    [Header("GAME UI")]
    public Text CashCollected;
      public Text LevelTextWin;
    

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        

    }

    void Start()
    {
        LevelComplete = false;
         CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        Instantiate(Levels[CurrentLevel]);
        isGameOver = false;
        attacked = false;
        if (CurrentLevel == 0)
        {
            LevelText.text = "TUTORIAL";
        }
        else
        {
            LevelText.text = "CHAPTER : " + CurrentLevel;
        }
        ObstacleCount = GameObject.FindGameObjectsWithTag("Obstacle").Length;
        TargetCash.text = "TARGET CASH : $" +(ObstacleCount - 3) * 10;
        
    }

    void Update()
    {
        
    }

    public void LevelCompleted() {
        if (ObstacleCollected > (ObstacleCount - 3) && !LevelComplete)
        {
        
            int getLevel = PlayerPrefs.GetInt("Level", 0);
            PlayerPrefs.SetInt("Level", (getLevel + 1));
            LevelComplete = true;
            GameWinUI.SetActive(true);
            if (CurrentLevel == 0)
            {
                LevelTextWin.text = "TUTORIAL";
            }
            else
            {
                LevelTextWin.text = "CHAPTER : " + CurrentLevel;
            }
            CashCollected.text = "Cash Collected  $" + (ObstacleCollected * 10);
            Adcontrol.instance.ShowAds();

        }
        else {
            StartCoroutine(ShowGameOVer());
        }
    }

    public void GameOver(Transform player)
    {
        if (!isGameOver)
        {
            GameObject dead = Instantiate(Ragdoll, player)as GameObject;
            dead.transform.SetParent(null);
            Instantiate(Fx, dead.transform);
            player.gameObject.SetActive(false);
            isGameOver = true;
            StartCoroutine(ShowGameOVer());
          //  Adcontrol.instance.ShowAds();

        }
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");

    }

    IEnumerator ShowGameOVer() {
        
        yield return new WaitForSeconds(1.2f);
        GameOverUI.SetActive(true);
        Adcontrol.instance.check();
        Adcontrol.instance.ShowInterstitial();
        


    }

    public void ExplosionWin() {
        Explosion.SetActive(true);

    }

    public void ShowReward() {
        Adcontrol.instance.ShowRewardBasedVideo();
    }

    public void ScoreAdd() {
        ObstacleCollected= ObstacleCollected+1;
        CashCollect.text = "Cash Collected : $" + (ObstacleCollected * 10);
     //   Debug.Log(ObstacleCollected);
    }
}
