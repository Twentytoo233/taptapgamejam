using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/*
    1.开机动画结束 显示面板
    2.播放Dotween动画
    3.结束 隐藏面板 显示视频播放面板
 */
public class MemoryPanel : BasePanel
{
    private Image showImg;//图片1
    private Image showImg2;//图片2
    public List<Sprite> sprites = new List<Sprite>();//保存精灵图的链表，下标0、1、2、....
    private int imgCount = 1;//当前图片的下标，因为我初始已经赋值两张精灵图，所以下一张替换时从2开始

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
        video_time = 10f;

        //查找并赋值组件对象
        //showImg = GetControl<Image>("Recall1");
        //showImg2 = GetControl<Image>("Recall2");
        showImg = transform.Find("Recall1").GetComponent<Image>();
        showImg2 = transform.Find("Recall2").GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        ShowSildeImg();
        currentTime += Time.deltaTime;
        if (currentTime >= video_time)
        {
            //视频播放结束，这里可以写视频播放结束后的事件
            StopSildeShow();
            UIMgr.Instance.HidePanel<MemoryPanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<TurnOffPanel>();
        }
    }

    /// <summary>
    /// 幻灯片自动播放事件，使用dotween动画实现
    /// </summary>
    public void ShowSildeImg()
    {
        Sequence sequence = DOTween.Sequence();//声明一个dotween动画队列，按照队列先入先出的原则播放

        //添加图片一的动画一：图片1的alpha值8秒内从1变为0，实现图片渐变效果
        sequence.Append(showImg.DOFade(0, 8).OnComplete(() =>
        {
            //添加一个动画播放完成的回调函数OnComplete，lambda表达式写法，动画播放完成后替换精灵图
            ChangeSprite(showImg);
            Debug.Log("图片一精灵图替换为：" + (imgCount + 1));
        }));
        //动画一播放的同时加入图片的二的动画二与动画一同时播放：此时图片2的alpha值8秒内从0变为1。
        sequence.Join(showImg2.DOFade(1, 8));

        sequence.AppendInterval(1f);//延迟2秒后播放后面动画

        ////添加同时播放的动画3和动画4，原理同上
        //sequence.Append(showImg2.DOFade(0, 5).OnComplete(() =>
        //{
        //    ChangeSprite(showImg2);
        //    //Debug.Log("图片二精灵图替换为：" + (imgCount + 1));
        //}));
        //sequence.Join(showImg.material.DOFade(1, 5));

        //sequence.AppendInterval(1);
        //sequence.SetLoops(-1);//参数为-1表示设置动画为无限循环，就形成了一个幻灯片播放效果了
        //StopSildeShow();
    }
    private void ChangeSprite(Image img)
    {
        //判断当前显示的精灵图下标是否小于链表精灵图总数量-1
        if (imgCount < sprites.Count - 1)
        {
            imgCount++;
        }
        else
        {
            imgCount = 0;//超过则从下标0重新开始
        }
        img.sprite = sprites[imgCount];//替换当前图片的精灵图为下次要显示的精灵图
    }
    private void StopSildeShow()
    {
        DOTween.KillAll();//砍掉所以补间动画
    }
}
