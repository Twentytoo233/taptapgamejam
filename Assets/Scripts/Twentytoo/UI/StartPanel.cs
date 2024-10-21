using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    public override void HideMe()
    {
        gameObject.SetActive(false);
    }

    public override void ShowMe()
    {
        gameObject.SetActive(true);
    }

    private void Start()
    {
        UIMgr.Instance.ShowPanel<StartPanel>();

        

        GetControl<Button>("StartButton").onClick.AddListener(() =>
        {
            //已按下开始按钮 隐藏开始面板
            UIMgr.Instance.HidePanel<StartPanel>();
            HideMe();
            //打开开机面板
            UIMgr.Instance.ShowPanel<TurnOnPanel>();

        });

    }
}
