using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public UnityPlayer unityChan;
    public GameObject Panelfade;

    Image fadealpha;

    public float alpha;
    public bool fadeout;
    public float SceneNo;

    // Start is called before the first frame update
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>();
        alpha = fadealpha.color.a;
        fadeout = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(fadeout == true)
        {
            if (unityChan.Life() <= 0) 
            {
                FadeOut();
            }

        }
    }

    void FadeOut()
    {
        alpha += 0.5f*Time.deltaTime;
        fadealpha.color = new Color(0,0,0,alpha);
        if(alpha >= 1.0)
        {
            fadeout = false;
            SceneManager.LoadScene("Title");
            alpha = 0;
        }
    }


}
