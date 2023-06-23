using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dethe : MonoBehaviour
{

    public FadeController fade;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(fade.fadeout == false)
        {
            gameObject.SetActive(true);
        }
    }
}
