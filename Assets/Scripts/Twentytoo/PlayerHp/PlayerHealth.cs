using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour

{
    public float spawnTime;

    private Vector2 spawnPoint = default(Vector2);
    public Vector2 SpawnPoint => spawnPoint;

    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        SetSpawnPoint(transform.position);

        GameInfoManager.Instance.Init();
    }


    void Update()
    {
        
    }
    //��ʱд��
    public void SetSpawnPoint(Vector2 spawnPoint)
    {
        this.spawnPoint = spawnPoint;
        Debug.Log("���´浵��");
    }
    public Vector2 GetSpawnPoint()
    {
        return spawnPoint;
    }
    public void Spawn()
    {
        gameObject.transform.position = spawnPoint;
        gameObject.SetActive(true);
        Debug.Log("����");
    }
    public void DeadAction()
    {
        Debug.Log("����");
        //transform.position = spawnPoint;
        gameObject.SetActive(false);
        Invoke("Spawn", spawnTime);
    }
}
