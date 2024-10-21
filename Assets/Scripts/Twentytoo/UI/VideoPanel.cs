using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPanel : BasePanel
{
    /*
     1.���¿�ʼ��Ϸ��ťʱ ��ʾVideoPanel��� ���ؿ�ʼ���
    2.������Ƶ0 5������ �������
    3.�ȴ����䶯��������� ��ʾ���
    4.������Ƶ0 5������ �������
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
        //��ȡUI�ؼ� TurnOn
        turnOn = GetControl<RawImage>("TurnOn");
        //��ȡUI�ؼ� TurnOff
        turnOff = GetControl<RawImage>("TurnOff");
    }

    // Update is called once per frame
    void Update()
    {

        ShowMe();
        //���ſ�����Ƶ
        
    }

}
