using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float damage;
    Rigidbody2D rigid;
    public float speed = 10f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    public void Init(float damage, Vector2 dir)
    {
        this.damage = damage;
        //if (rigid)
        //{
        //    rigid.velocity = dir * speed;
        //}
        Destroy(this.gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (rigid)
        {
            rigid.velocity = Vector2.zero;//×Óµ¯Í£Ö¹
        }
        Destroy(this.gameObject);
    }
}
