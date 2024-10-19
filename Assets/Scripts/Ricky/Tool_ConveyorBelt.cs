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
        //�����������ײ��
        GetComponent<Collider2D>().enabled = false;
        Vector2 forceDirection = new Vector2();
        //���ݲ�ͬ�ķ����������ķ���
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
        //��ԭʼ����Ӧ�õ�ǰ���ʹ�����ת
        Vector2 rotatedVector = transform.rotation * forceDirection;

        //Rigidbody2D targetRb = collision.gameObject.GetComponent<Rigidbody2D>();
        //if (targetRb != null)
        //{

        //}
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(rotatedVector * speed, ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = true;

        //��ȡ��ǰ�����ٶ�
        //Vector2 PlayerVelocity = targetRb.velocity;

        //�����봫�ʹ�����ļн�
        //float dotProduct = Vector2.Dot(rotatedVector.normalized, PlayerVelocity.normalized);

        //����������0��˵�������봫�ʹ�ͬ��
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
        //��������������ײ��
        //GetComponent<Collider2D>().enabled = true;

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        OnTriggerConveyorBelt(collision);
    }
}
