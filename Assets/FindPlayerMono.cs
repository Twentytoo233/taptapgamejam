using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerMono : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<CinemachineVirtualCamera>().Follow == null)
        {
            GetComponent<CinemachineVirtualCamera>().Follow = GameInfoManager.Instance.playerInfo.playerObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
