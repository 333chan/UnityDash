using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZ : MonoBehaviour
{

    public Vector3 Enemypos;
    public int ReTrun;
    public float Rate;
    public float peroid;

    // Start is called before the first frame update
    void Start()
    {
        Enemypos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
          transform.position.x, 
          transform.position.y,
          Mathf.Sin(Time.time* Rate) * (peroid * ReTrun) + transform.position.z);


    }
}
