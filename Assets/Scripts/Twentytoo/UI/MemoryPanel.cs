using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/*
    1.������������ ��ʾ���
    2.����Dotween����
    3.���� ������� ��ʾ��Ƶ�������
 */
public class MemoryPanel : BasePanel
{
    private Image showImg;//ͼƬ1
    private Image showImg2;//ͼƬ2
    public List<Sprite> sprites = new List<Sprite>();//���澫��ͼ�������±�0��1��2��....
    private int imgCount = 1;//��ǰͼƬ���±꣬��Ϊ�ҳ�ʼ�Ѿ���ֵ���ž���ͼ��������һ���滻ʱ��2��ʼ

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

        //���Ҳ���ֵ�������
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
            //��Ƶ���Ž������������д��Ƶ���Ž�������¼�
            StopSildeShow();
            UIMgr.Instance.HidePanel<MemoryPanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<TurnOffPanel>();
        }
    }

    /// <summary>
    /// �õ�Ƭ�Զ������¼���ʹ��dotween����ʵ��
    /// </summary>
    public void ShowSildeImg()
    {
        Sequence sequence = DOTween.Sequence();//����һ��dotween�������У����ն��������ȳ���ԭ�򲥷�

        //���ͼƬһ�Ķ���һ��ͼƬ1��alphaֵ8���ڴ�1��Ϊ0��ʵ��ͼƬ����Ч��
        sequence.Append(showImg.DOFade(0, 8).OnComplete(() =>
        {
            //���һ������������ɵĻص�����OnComplete��lambda���ʽд��������������ɺ��滻����ͼ
            ChangeSprite(showImg);
            Debug.Log("ͼƬһ����ͼ�滻Ϊ��" + (imgCount + 1));
        }));
        //����һ���ŵ�ͬʱ����ͼƬ�Ķ��Ķ������붯��һͬʱ���ţ���ʱͼƬ2��alphaֵ8���ڴ�0��Ϊ1��
        sequence.Join(showImg2.DOFade(1, 8));

        sequence.AppendInterval(1f);//�ӳ�2��󲥷ź��涯��

        ////���ͬʱ���ŵĶ���3�Ͷ���4��ԭ��ͬ��
        //sequence.Append(showImg2.DOFade(0, 5).OnComplete(() =>
        //{
        //    ChangeSprite(showImg2);
        //    //Debug.Log("ͼƬ������ͼ�滻Ϊ��" + (imgCount + 1));
        //}));
        //sequence.Join(showImg.material.DOFade(1, 5));

        //sequence.AppendInterval(1);
        //sequence.SetLoops(-1);//����Ϊ-1��ʾ���ö���Ϊ����ѭ�������γ���һ���õ�Ƭ����Ч����
        //StopSildeShow();
    }
    private void ChangeSprite(Image img)
    {
        //�жϵ�ǰ��ʾ�ľ���ͼ�±��Ƿ�С��������ͼ������-1
        if (imgCount < sprites.Count - 1)
        {
            imgCount++;
        }
        else
        {
            imgCount = 0;//��������±�0���¿�ʼ
        }
        img.sprite = sprites[imgCount];//�滻��ǰͼƬ�ľ���ͼΪ�´�Ҫ��ʾ�ľ���ͼ
    }
    private void StopSildeShow()
    {
        DOTween.KillAll();//�������Բ��䶯��
    }
}
