using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPanel : BasePanel
{
    /*
     1.���¿�ʼ��Ϸ��ťʱ ��ʾVideoPanel��� ���ؿ�ʼ���
    2.������Ƶ 5������ �������
    3.�ȴ����䶯��������� ��ʾ���
     */
    public VideoPlayer turnOn;
    public VideoPlayer turnOff;
    public GameObject videoImage1;//����image
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
            UIMgr.Instance.HidePanel<StartPanel>();
            turnOn.Play();
            currentTime += Time.deltaTime;
        }

        if (currentTime >= videoTime)
        {
            //��Ƶ���Ž���
            IsPlay = false;
            //�ر���Ƶ���
            UIMgr.Instance.HidePanel<VideoPanel>();
            //�򿪼������
            UIMgr.Instance.ShowPanel<MemoryPanel>();
        }

    }

}
