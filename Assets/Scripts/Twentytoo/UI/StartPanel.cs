using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    //public override void HideMe()
    //{
    //    gameObject.SetActive(false);
    //}

    //public override void ShowMe()
    //{
    //    gameObject.SetActive(true);
    //}

    private void Start()
    {
        UIMgr.Instance.ShowPanel<StartPanel>();
        GetControl<Button>("StartButton").onClick.AddListener(() =>
        {
            //UIMgr.Instance.ShowPanel<MemoryPanel>();
            UIMgr.Instance.ShowPanel<VideoPanel>();

        });

    }
}
