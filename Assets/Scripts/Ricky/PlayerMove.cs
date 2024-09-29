using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float MoveSpeed = 6f;
    [SerializeField]
    private float jumpForce = 10f;
    private float MoveH;
    [SerializeField]
    private bool isGrounded;

    public Transform checkPoint;
    [SerializeField]
    public LayerMask layerMask;
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
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded==true)
        {
            OnJump();
            //播放动画
            //rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded)
        {
            MoveH = Input.GetAxis("Horizontal") * MoveSpeed;
            rightDir = MoveH >= 0 ? true : false;
        }
        else
        {
            if (rightDir)
                MoveH = Mathf.Max(Input.GetAxis("Horizontal") * MoveSpeed * 1.4f, -0.7f * MoveSpeed);
            else
                MoveH = Mathf.Min(Input.GetAxis("Horizontal") * MoveSpeed * 1.4f, 0.7f * MoveSpeed);
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
    }
    private void CheckGround()
    {
        Collider2D collider = Physics2D.OverlapBox(checkPoint.position, checkBoxSize, 0, layerMask);
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
        Gizmos.DrawWireCube(checkPoint.position, checkBoxSize);
        Gizmos.color = Color.red;
    }
    private void Flip()
    {
        if (MoveH>0&&isGrounded)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (MoveH<0&&isGrounded)
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
    }
    private void GetDaze()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed * 2.3f, Input.GetAxis("Vertical")* jumpForce);
        isGrounded = true;
    }
}
