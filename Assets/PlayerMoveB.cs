using Spine.Unity;
using UnityEngine;

public enum PlayerState
{
    
}
public class PlayerMoveB : MonoBehaviour
{
    public Transform checkPoint;
    public Vector2 checkBoxSize;
    public float moveSpeed;
    public float jumpSpeed;

    private SkeletonAnimation anim;

    public bool isGround = true;
    private int remainJumpCount = 2;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        //λ�ƴ���
        if (inputX > 0)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(inputX < 0)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);
        }
        //����
        if (inputX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(inputX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //��Ծ
        if(Input.GetKeyDown(KeyCode.Space) && (isGround || remainJumpCount > 0))
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<Rigidbody2D>().velocity.x,jumpSpeed);
            remainJumpCount--;
        }
        //������
        CheckGround();
    }
    private void CheckGround()
    {
        Collider2D collider = Physics2D.OverlapBox(checkPoint.position, checkBoxSize, 0);
        if (collider != null)
        {
            isGround = true;
            remainJumpCount = 2;
        }
        else
        {
            isGround = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(checkPoint.position, checkBoxSize);
    }
}
