using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class PlayVideo : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoClip[] SomeVideo = new VideoClip[10];

    VideoPlayer OneVideoComp;
    void Start()
    {
        OneVideoComp = this.GetComponent<VideoPlayer>();
        OneVideoComp.frame = 10;
    }

    private void Update()
    {
        Debug.Log(OneVideoComp.frameCount / 25);
    }
    //���溯�������ⲿUGUI��ť
    public void PlayVideo0()
    {
        OneVideoComp.clip = SomeVideo[0];
        OneVideoComp.Play();
    }
    public void ButtonClikB()
    {
        OneVideoComp.clip = SomeVideo[1];
        OneVideoComp.Play();

    }
}