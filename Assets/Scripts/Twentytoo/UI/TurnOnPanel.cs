using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnPanel : BasePanel
{
    private float video_time, currentTime;
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
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= video_time)
        {
            //��Ƶ���Ž������������д��Ƶ���Ž�������¼�
            UIMgr.Instance.HidePanel<TurnOnPanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<MemoryPanel>();
        }

    }
}
