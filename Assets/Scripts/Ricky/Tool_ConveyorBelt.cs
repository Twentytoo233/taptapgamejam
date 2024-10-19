using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public enum Direction
{
    Up=0,
    Left=1,
    Right=2,
    Down=3
}
public class Tool_ConveyorBelt : MonoBehaviour
{
    public Direction direction = Direction.Up;
    public float speed = 5f;
    //private Rigidbody2D rb;

  public void OnTriggerConveyorBelt(Collision2D collision)
    {
        //禁用自身的碰撞器
        GetComponent<Collider2D>().enabled = false;
        Vector2 forceDirection = new Vector2();
        //根据不同的方向设置力的方向
        switch (direction)
        {
            case Direction.Up:
                {
                    forceDirection = new Vector2(0f, 1f);
                }
                break;
            case Direction.Left:
                {
                    forceDirection = new Vector2(-1f, 0f);
                }
                break;
            case Direction.Right:
                {
                    forceDirection = new Vector2(1f, 0f);
                }
                break;
            case Direction.Down:
                {
                    forceDirection = new Vector2(0f, -1f);
                }
                break;

               
        }
        //将原始向量应用当前传送带的旋转
        Vector2 rotatedVector = transform.rotation * forceDirection;

        //Rigidbody2D targetRb = collision.gameObject.GetComponent<Rigidbody2D>();
        //if (targetRb != null)
        //{

        //}
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(rotatedVector * speed, ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = true;

        //获取当前人物速度
        //Vector2 PlayerVelocity = targetRb.velocity;

        //计算与传送带方向的夹角
        //float dotProduct = Vector2.Dot(rotatedVector.normalized, PlayerVelocity.normalized);

        //如果点积大于0，说明人物与传送带同向
        //if (dotProduct > 0)
        //{
        //    targetRb.AddForce(rotatedVector * speed * 2f, ForceMode2D.Impulse);
        //    targetRb.AddForce(rotatedVector * speed * 2f, ForceMode2D.Force);
        //}
        //else if (dotProduct<0)
        //{
        //    targetRb.AddForce(rotatedVector * speed * 0.5f, ForceMode2D.Impulse);
        //    targetRb.AddForce(rotatedVector * speed * 0.5f, ForceMode2D.Force);
        //}
        //else
        //{
        //    targetRb.AddForce(rotatedVector * speed, ForceMode2D.Impulse);
        //    targetRb.AddForce(rotatedVector * speed, ForceMode2D.Force);
        //}
        //重新启用自身碰撞器
        //GetComponent<Collider2D>().enabled = true;

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        OnTriggerConveyorBelt(collision);
    }
}
