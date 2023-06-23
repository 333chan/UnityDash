using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeTitle : MonoBehaviour
{
    //ハイスコアテキストオブジェクト
    public Text HighScoreText;

    void Start ()
    {
 

        //ハイスコアテキストを更新
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore") + "m";
    }
    public void OnStratButtonClicked()
    {
        //スタートボタンをクリックしたら
        SceneManager.LoadScene("Game");
    }

}
