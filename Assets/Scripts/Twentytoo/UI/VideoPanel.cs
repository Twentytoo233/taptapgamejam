using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPanel : BasePanel
{
    /*
     1.按下开始游戏按钮时 显示VideoPanel面板
    2.播放视频 5秒后结束 隐藏面板
    3.等待回忆动画播放完毕 显示面板
     */
    public VideoPlayer turnOn;
    public VideoPlayer turnOff;
    public GameObject videoImage1;//播放image
    public GameObject videoImage2;
    private bool IsPlay = true;

    private double videoTime, currentTime;
    // Start is called before the first frame update
    void Start()
    {
        videoTime = 5f;
        turnOn = videoImage1.GetComponent<VideoPlayer>();
        turnOff = videoImage2.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlay)
        {
            turnOn.Play();
            currentTime += Time.deltaTime;
        }

        if (currentTime >= videoTime)
        {
            //视频播放结束
            IsPlay = false;
            UIMgr.Instance.HidePanel<VideoPanel>();
        }

    }

}
