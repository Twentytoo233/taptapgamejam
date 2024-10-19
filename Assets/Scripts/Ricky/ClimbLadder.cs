using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    private float vertical;//垂直输入
    private float speed = 3f;//爬梯子的速度
    private bool isLadder;//是否站在梯子上
    private bool isClimbing;

    private Animator anim;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder==true&&Mathf.Abs(vertical)>0)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing==true)
        {
            rb.gravityScale = 0f;//爬梯子时候的重量比例为0
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            isClimbing = true;
            //播放爬梯子动画

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            //动画停止

        }
    }
}
