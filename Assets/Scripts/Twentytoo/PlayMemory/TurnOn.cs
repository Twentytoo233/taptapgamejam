using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TurnOn : MonoBehaviour
{
    public VideoPlayer turnOn;
    public GameObject videoImage;//播放image
    private bool IsPlay = true;

    private double videoTime, currentTime;
    // Start is called before the first frame update
    void Awake()
    {
        
        videoTime = 5f;
        turnOn = videoImage.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlay)
        {
            turnOn.Play();
            currentTime += Time.deltaTime;
        }
        
        if (currentTime >= videoTime)
        {
            //视频播放结束 关闭界面
            gameObject.SetActive(false);
        }

    }
}
