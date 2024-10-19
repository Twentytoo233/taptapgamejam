using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayMemory : MonoBehaviour
{
    
    private Image showImg;//ͼƬ1
    private Image showImg2;//ͼƬ2
    public List<Sprite> sprites = new List<Sprite>();//���澫��ͼ�������±�0��1��2��....
    private int imgCount = 1;//��ǰͼƬ���±꣬��Ϊ�ҳ�ʼ�Ѿ���ֵ���ž���ͼ��������һ���滻ʱ��2��ʼ
    private void Start()
    {
        //���Ҳ���ֵ�������
        showImg = transform.Find("Recall1").GetComponent<Image>();
        showImg2 = transform.Find("Recall2").GetComponent<Image>();
        ShowSildeImg();
        //StopSildeShow();

    }
    /// <summary>
    /// �õ�Ƭ�Զ������¼���ʹ��dotween����ʵ��
    /// </summary>
    private void ShowSildeImg()
    {
        Sequence sequence = DOTween.Sequence();//����һ��dotween�������У����ն��������ȳ���ԭ�򲥷�

        //���ͼƬһ�Ķ���һ��ͼƬ1��alphaֵ5���ڴ�1��Ϊ0��ʵ��ͼƬ����Ч��
        sequence.Append(showImg.DOFade(0, 5).OnComplete(() =>
        {
            //���һ������������ɵĻص�����OnComplete��lambda���ʽд��������������ɺ��滻����ͼ
            ChangeSprite(showImg);
            Debug.Log("ͼƬһ����ͼ�滻Ϊ��" + (imgCount + 1));
        }));
        //����һ���ŵ�ͬʱ����ͼƬ�Ķ��Ķ������붯��һͬʱ���ţ���ʱͼƬ2��alphaֵ5���ڴ�0��Ϊ1��
        sequence.Join(showImg2.DOFade(1, 5));

        sequence.AppendInterval(1f);//�ӳ�2��󲥷ź��涯��

        //���ͬʱ���ŵĶ���3�Ͷ���4��ԭ��ͬ��
        sequence.Append(showImg2.DOFade(0, 5).OnComplete(() =>
        {
            ChangeSprite(showImg2);
            //Debug.Log("ͼƬ������ͼ�滻Ϊ��" + (imgCount + 1));
        }));
        sequence.Join(showImg.material.DOFade(1, 5));

        //sequence.AppendInterval(1);
        //sequence.SetLoops(-1);//����Ϊ-1��ʾ���ö���Ϊ����ѭ�������γ���һ���õ�Ƭ����Ч����
        //StopSildeShow();
    }
    // �滻ͼƬ�ľ���ͼ
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
    // ֹͣ�����¼�
    private void StopSildeShow()
    {
        DOTween.KillAll();//�������Բ��䶯��
    }
}
