using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPanel : BasePanel
{
    /*
     1.按下开始游戏按钮时 显示VideoPanel面板 隐藏开始面板
    2.播放视频0 5秒后结束 隐藏面板
    3.等待回忆动画播放完毕 显示面板
    4.播放视频0 5秒后结束 隐藏面板
     */

    private RawImage turnOn;
    private RawImage turnOff;

    public override void HideMe()
    {
        gameObject.SetActive(false);
    }

    public override void ShowMe()
    {
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        //获取UI控件 TurnOn
        turnOn = GetControl<RawImage>("TurnOn");
        //获取UI控件 TurnOff
        turnOff = GetControl<RawImage>("TurnOff");
    }

    // Update is called once per frame
    void Update()
    {

        ShowMe();
        //播放开机视频
        
    }

}
