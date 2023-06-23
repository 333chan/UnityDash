using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{

    private void Exit()
    {
        //ゲーム終了時
        //スコアをリセット
        PlayerPrefs.DeleteAll();

        //ゲーム終了
        Application.Quit();
    }

}
