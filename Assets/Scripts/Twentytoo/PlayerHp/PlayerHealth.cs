using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;

    public float spawnTime;

    private Vector2 spawnPoint = default(Vector2);
    public Vector2 SpawnPoint => spawnPoint;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SetSpawnPoint(transform.position);
    }


    void Update()
    {
        
    }
    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;   
    }
    //暂时写这
    public void SetSpawnPoint(Vector2 spawnPoint)
    {
        this.spawnPoint = spawnPoint;
        Debug.Log("更新存档点");
    }
    public Vector2 GetSpawnPoint()
    {
        return spawnPoint;
    }
    public void Spawn()
    {
        gameObject.transform.position = spawnPoint;
        gameObject.SetActive(true);
        Debug.Log("复活");
    }
    public void DeadAction()
    {
        Debug.Log("死亡");
        //transform.position = spawnPoint;
        gameObject.SetActive(false);
        Invoke("Spawn", spawnTime);
    }
}
