using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGame : MonoBehaviour
{

    void Start()
    {

    }
    public void OnStratButtonClicked()
    {
        SceneManager.LoadScene("Game");

    }

}
