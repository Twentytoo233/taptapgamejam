using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEngine.SceneManagement;

public class TurnOffPanel : BasePanel
{
    private float video_time, currentTime;

    float tempProgress;
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
        video_time = 5f;

        tempProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= video_time)
        {
            //��Ƶ���Ž������������д��Ƶ���Ž�������¼�
            UIMgr.Instance.HidePanel<TurnOffPanel>();
            HideMe();
            //�л����³���
            EventCenter.Instance.AddEventListener<float>(E_EventType.E_SceneLoadChange, (o) => {
                UpdateProgess(o);
            });
            SceneMgr.Instance.LoadSceneAsyn("SceneL0", () =>
             {
                 Debug.Log("�����������");
             });
            
        }
    }
    public void UpdateProgess(float progessVal)
    {
        //tempProgress = Mathf.Lerp(tempProgress, progessVal,Time.deltaTime);
        tempProgress = progessVal;
        Debug.Log("���յ�" + tempProgress);
        //slider.value = tempProgress;
        //text.text = tempProgress * 100 + "%";
    }


}
