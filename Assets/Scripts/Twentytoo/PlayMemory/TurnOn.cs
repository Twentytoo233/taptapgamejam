using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TurnOn : MonoBehaviour
{
    public VideoPlayer turnOn;
    public GameObject videoImage;//����image
    private bool IsPlay = true;

    private double videoTime, currentTime;
    // Start is called before the first frame update
    void Awake()
    {
        
        videoTime = 5f;
        turnOn = videoImage.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlay)
        {
            turnOn.Play();
            currentTime += Time.deltaTime;
        }
        
        if (currentTime >= videoTime)
        {
            //��Ƶ���Ž��� �رս���
            gameObject.SetActive(false);
        }

    }
}
