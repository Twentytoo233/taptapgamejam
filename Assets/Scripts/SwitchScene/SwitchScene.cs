using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScene : BasePanel
{
    public bool switchScene = false;
    public Recall recall;
    public bool isSyns = true;

    public override void HideMe()
    {
        throw new System.NotImplementedException();
    }

    public override void ShowMe()
    {
        throw new System.NotImplementedException();
    }

    private void loadCompleteAction()
    {
        Debug.Log("≥°æ∞º”‘ÿÕÍ±œ");
    }

    void Start()
    {
        //recall = UIMgr.Instance.GetPanel<Recall>();
        UIMgr.Instance.ShowPanel<Recall>(E_UILayer.top,null,isSyns);
    }

    

    // Update is called once per frame
    void Update()
    {
        if (switchScene == true)
            SceneMgr.Instance.LoadSceneAsyn("TestScene", loadCompleteAction);
    }
}
