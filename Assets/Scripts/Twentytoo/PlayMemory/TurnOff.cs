using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    private double videoTime, currentTime;
    // Start is called before the first frame update
    void Start()
    {
        videoTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= videoTime)
        {
            //��Ƶ���Ž������������д��Ƶ���Ž�������¼�
        }

    }
}
