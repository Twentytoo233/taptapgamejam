using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour
{
    public GameObject Rock;

    public float t1;     //����һ��ʱ�䣬������������룬���ʱ���Ǵ�С������С����ʧ��ʱ�䣬Ϊ2��ʱ�Ǹ����룬4���Ǹ����� ��                                                                                                                       ����ѭ��(����ʵ����һ��)

    private float t2;    //����һ����̨���еģ�˽�е�ʱ�䡣�ӿ�ʼ�������������е�ʱ�䡣�����ʱ�����ڸ������㣩

    // Use this for initialization

    void Start()
    {
        t2 = t1;        // ����������t1��ֵ��t2;

    }

    // Update is called once per frame
    void Update()
    {
        t2 = t2 - Time.deltaTime;      //����������ʱ�䣬��1������ȥ0.0000X��ֱ��Ϊ0��Ҳ����1���ȥ�ˣ�ʵ�����������С                                                                                                                        ��1�븴��1����

        if (t2 <= 0)
        {

            Instantiate(Rock);

            t2 = t1;                                       //�ظ���ֵ���ظ�����

        }

    }
}
