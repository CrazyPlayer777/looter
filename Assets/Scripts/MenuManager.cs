using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public string MoreGamesURL, RateURL;
    public Text LevelText;
   

    int level;
    void Start()
    {
       
         level =   PlayerPrefs.GetInt("Level", 0);
        if (level == 0)
        {
            LevelText.text = "TUTORIAL";
        }
        else
        {
            LevelText.text = "CHAPTER : " + level;
        }
       // LevelText.text = "CURRENT LEVEL : " + level;
    }

    

    public void MoreGames() {
        Application.OpenURL(MoreGamesURL);
    }

    public void Rate()
    {
        Application.OpenURL(RateURL);
    }

    public void StartGame() {

        SceneManager.LoadScene("Game");
    }

   


}
