using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public UnityPlayer unityChan;   //プレイヤーコンポーネント取得用
    public Text scoreText;          //スコアテキストコンポーネント取得用
    public LifePanel lifePanel;     //ライフパネルポーネント取得用
    public int score = 0;           // スコア

    const int SCOR_ELIMIT = 9999;   //スコアリミット

    // Update is called once per frame
    public void Update()
    {
        // スコア更新
        score = CalcScore();

        if (score <= SCOR_ELIMIT)
        {
            scoreText.text = "Score : " + score + "m"; 
        }
        else
        {
            //スコア上限処理
            scoreText.text = "Score : " + SCOR_ELIMIT + "m"; ;
        }



        // ライフパネルの更新
        lifePanel.UpdateLife(unityChan.Life());

        //ライフが0になったら
        if (unityChan.Life() <= 0)
        {
            //パネルの表示OFF
            enabled = false;

            if (PlayerPrefs.GetInt("HighScore") < score) 
            {
                //ハイスコアの更新
                PlayerPrefs.SetInt("HighScore", score);
            }
        }

    }

    int CalcScore()
    {
        // プレイヤーの走行距離をスコアに
        return (int)unityChan.transform.position.z;
    }
}
