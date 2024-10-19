using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    private double videoTime, currentTime;
    // Start is called before the first frame update
    void Start()
    {
        videoTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= videoTime)
        {
            //视频播放结束，这里可以写视频播放结束后的事件
        }

    }
}
