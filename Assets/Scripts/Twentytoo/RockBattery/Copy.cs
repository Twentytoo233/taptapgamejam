using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour
{
    public GameObject Rock;

    public float t1;     //定义一个时间，可以在面板输入，这个时间是从小球发射至小球消失的时间，为2秒时是个距离，4秒是个距离 。                                                                                                                       做个循环(几秒实例化一个)

    private float t2;    //定义一个后台运行的，私有的时间。从开始运行至结束运行的时间。（这个时间用于辅助计算）

    // Use this for initialization

    void Start()
    {
        t2 = t1;        // 把面板输入的t1赋值给t2;

    }

    // Update is called once per frame
    void Update()
    {
        t2 = t2 - Time.deltaTime;      //把面板输入的时间，“1”，减去0.0000X，直至为0，也就是1秒过去了，实例化复制这个小                                                                                                                        球，1秒复制1个。

        if (t2 <= 0)
        {

            Instantiate(Rock);

            t2 = t1;                                       //重复赋值，重复运行

        }

    }
}
