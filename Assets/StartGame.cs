using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameInfoManager.Instance.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
