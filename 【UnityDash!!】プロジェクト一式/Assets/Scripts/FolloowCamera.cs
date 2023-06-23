using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloowCamera: MonoBehaviour
{
    Vector3 diff;

    public GameObject target;
    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        diff = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            target.transform.position - diff,
            Time.deltaTime * followSpeed
            );

    }
}
