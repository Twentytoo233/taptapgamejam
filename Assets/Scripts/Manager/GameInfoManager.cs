using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoManager : SingletonAutoMono<GameInfoManager>
{
    public PlayerInfo playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        playerInfo = new PlayerInfo();
        GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>().Follow = playerInfo.playerObj.transform;
    }
}
public class PlayerInfo
{
    public Vector2 spawnPoint;
    public GameObject playerObj;
    public int energy;
    public int maxEnergy;
    public int spawnTime;
    public PlayerInfo()
    {
        spawnPoint = new Vector2(-4.2f, 0.8f);
        maxEnergy = 3;
        energy = maxEnergy;
        playerObj = GameObject.Instantiate(ResourcesMgr.Instance.Load<GameObject>("Prefabs/Player"),spawnPoint,Quaternion.identity);
        GameObject.DontDestroyOnLoad(playerObj);
    }
    public void DeadAction()
    {
        playerObj.gameObject.SetActive(false);
        //MonoMgr.Instance.Invoke("Spawn", spawnTime);
        Spawn();
    }
    public void Spawn()
    {
        playerObj.gameObject.transform.position = spawnPoint;
        playerObj.gameObject.SetActive(true);
    }
    public void SetSpawnPoint(Vector2 spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }
    public Vector2 GetSpawnPoint()
    {
        return spawnPoint;
    }
}
