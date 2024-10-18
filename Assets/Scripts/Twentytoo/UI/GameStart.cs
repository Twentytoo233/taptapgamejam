using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameStart : BasePanel
{
    private Button gameStart;
    private Image recall1;
    private Image recall2;
    private Image outerFrame;
    private bool isSyns = true;
    private Recall recall;
    

    protected override void Awake()
    {
        base.Awake();
        gameStart = GetControl<Button>("GameStart");
        recall1 = GetControl<Image>("Recall1");
        recall2 = GetControl<Image>("Recall2");
        outerFrame = GetControl<Image>("OutFrame");
        //recall=Resources.Load<GameObject>("Recall")

        //ClickBtn("GameStart");
        
    }
    public override void HideMe()
    {
        throw new System.NotImplementedException();
    }

    private void loadCompleteAction<Image>()
    {
        Debug.Log("º”‘ÿÕÍ±œ");
    }
    public override void ShowMe()
    {
        throw new System.NotImplementedException();
    }

    protected override void ClickBtn(string btnName)
    {
        //UIMgr.Instance.ShowPanel(recall);   
    }
}
