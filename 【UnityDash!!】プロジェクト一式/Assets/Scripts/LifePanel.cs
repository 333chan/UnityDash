using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour
{

    public GameObject[] icons;

    // ライフに応じて画像を出しわける
    public void UpdateLife(int life)
    {
        for (int i = 0; i < icons.Length; i++) 
        {
            if (i < life) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }
}
