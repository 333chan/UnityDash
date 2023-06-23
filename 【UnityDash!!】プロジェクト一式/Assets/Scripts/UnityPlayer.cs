using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnityPlayer : MonoBehaviour
{

    CharacterController controller;
    Animator animator;

    Vector3 movedir = Vector3.zero;

    public float speedZ;
    public float speedX;
    public float Jump;
    public float JumpCnt;
    public float G;
    public float acceleratorZ;
    const int DefaultLife = 3;
    const float StumTime = 2.5f;


    int life = DefaultLife;
    float recoverTime = 0.0f;

    public int Life()
    {
        return life;
    }

    bool IsStun()
    {
        return recoverTime > 0.0f || life <= 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsStun())
        {
            movedir.x = 0.0f;
            movedir.z = 0.0f;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            movedir.x = Input.GetAxis("Horizontal") * speedX;
            movedir.z = Mathf.Clamp(movedir.z + (acceleratorZ * Time.deltaTime), 0, speedZ);
        }


        if (controller.isGrounded)
        {
            movedir.y = 0;
            JumpCnt = 1;
        }
        if (Input.GetButton("Jump"))
        {
            if(JumpCnt == 1)
            {
                JumpA();
            }

        }
        else if (IsStun())
        {
            return;
        }
        movedir.y -= G * Time.deltaTime;

        Vector3 globaldir = transform.TransformDirection(movedir);
        controller.Move(globaldir * Time.deltaTime);

        animator.SetBool("Run", movedir.z > 0.0f);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (IsStun()) return;

        //
        if (hit.gameObject.tag == "Enemy")
        {
            // ライフを減らして気絶状態nに移行
            animator.SetTrigger("Damage");
            life--;
            recoverTime = StumTime;

            movedir.y = 0;

            // ヒットしたオブジェクトは削除
            Destroy(hit.gameObject);

        }
    }

    public void JumpA()
    {

        if(JumpCnt!=0)
        {
            movedir.y = Jump;
            animator.SetTrigger("Jump");
            JumpCnt -= 1;

        }

    }


}
