using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    //private SkeletonAnimation anim;
    private Animator anim;
    private float previousFramePosY;//记录上一帧y位置 判断是否播放下坠动画

    [SerializeField]
    private float MoveSpeed = 6f;
    [SerializeField]
    private float jumpForce = 10f;
    private float MoveH;
    [SerializeField]
    private bool isGrounded;
    private bool canDoubleJump;

    private int jumpCount;

    public Transform checkPoint;
    [SerializeField]
    private Vector2 checkBoxSize;

    [Header("Better Jump")]
    [SerializeField]
    private float fallFactor;//长跳跃系数
    [SerializeField]
    private float shortJumpFactor;

    [SerializeField]
    private bool getDaze;
    private bool rightDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<SkeletonAnimation>();
        anim = GetComponent<Animator>();
        //Physics2D.queriesStartInColliders = false;
        canDoubleJump = false;
    }

    void Update()
    {
        if (isGrounded)
        {
            MoveH = Input.GetAxis("Horizontal") * MoveSpeed;
            rightDir = MoveH >= 0 ? true : false;
            if(MoveH == 0)
            {
                //播放动画
                //anim.AnimationName = "idle";
                anim.Play("Idle");
            }
            else if(MoveH !=0 && anim.name != "Walk")
            {
                //播放动画
                //anim.AnimationName = "run";
                anim.Play("Walk");
            }
        }
        else
        {
            if (rightDir)
                MoveH = Mathf.Max(Input.GetAxis("Horizontal") * MoveSpeed * 1.4f, -0.7f * MoveSpeed);
            else
                MoveH = Mathf.Min(Input.GetAxis("Horizontal") * MoveSpeed * 1.4f, 0.7f * MoveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            OnJump();
            canDoubleJump = true;
            
            //rb.velocity = Vector2.up * jumpForce;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
        {
            //OnDoubleJump();
            OnJump();
            canDoubleJump = false;
        }

        rb.velocity = new Vector2(MoveH, rb.velocity.y);
        //Debug.Log(MoveH);
        Flip();
        CheckGround();
        if (getDaze)
        {
            if (rb.gravityScale>0)
            {
                rb.gravityScale = 0;
            }
            GetDaze();
        }
        //动画处理
        if(GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            if (anim.name != "Fall") anim.Play("Fall");//anim.AnimationName = "fall";
        }
        else if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            if(anim.name != "Jump") anim.Play("Jump"); //anim.AnimationName = "jump";
        }

        previousFramePosY = transform.position.y;
    }
    private void CheckGround()
    {
        Collider2D collider = Physics2D.OverlapBox(checkPoint.position, checkBoxSize, 0);
        if (collider!=null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(checkPoint.position, checkBoxSize);
    }
    private void Flip()
    {
        if (MoveH>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (MoveH<0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    private void BetterJump()
    {
        if (rb.velocity.y<0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallFactor * Time.deltaTime;
        }
        else if (rb.velocity.y>0&&!Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * shortJumpFactor * Time.deltaTime;
        }
    }

    private void OnJump()
    {
        rb.velocity = Vector2.up * jumpForce;
        //播放跳跃动画
        //anim.AnimationName = "jump";
    }
    private void OnDoubleJump()
    {
        rb.velocity = Vector2.up * jumpForce * 0.8f;
        //播放跳跃动画
        //anim.AnimationName = "jump";
    }
    private void GetDaze()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed * 2.3f, Input.GetAxis("Vertical")* jumpForce);
        isGrounded = true;
    }
}
