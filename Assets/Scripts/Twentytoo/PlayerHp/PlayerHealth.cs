using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
//<<<<<<< HEAD
//=======
//{
//    public int playerHealth = 100;
//>>>>>>> parent of ae8945e (Merge branch 'master' of https://github.com/Twentytoo233/taptapgamejam)

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
//<<<<<<< HEAD
//=======
//    public void DamagePlayer(int damage)
//    {
//        playerHealth -= damage;   
//    }
//>>>>>>> parent of ae8945e (Merge branch 'master' of https://github.com/Twentytoo233/taptapgamejam)
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
