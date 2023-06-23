using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public bool DontDestroyEnablad = true;

    // Update is called once per frame
    void Start()
    {
        if(DontDestroyEnablad)
        {
            DontDestroyOnLoad(this);
        }

    }
}
