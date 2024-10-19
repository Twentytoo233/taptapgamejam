using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundThorn : MonoBehaviour
{
    public int damage = 10;
    private PlayerHealth playerHealth;
    private void Awake()
    {
        //�������Ѫ���Ľű�
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            playerHealth.DamagePlayer(damage);
        }
    }
}
