using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneTrigger : MonoBehaviour
{
    public string sceneName;
    public Vector2 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(sceneName == null)
            {
                Debug.LogError($"Error！==========>{gameObject.name}==========>{this.name}==========>请输入正确的切换场景名！");
            }
            else
            {
                SceneMgr.Instance.LoadScene(sceneName);
                GameInfoManager.Instance.playerInfo.SetSpawnPoint(spawnPoint);
                GameInfoManager.Instance.playerInfo.playerObj.transform.position = spawnPoint;
                GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>().Follow = GameInfoManager.Instance.playerInfo.playerObj.transform;
            }
        }
    }
}
