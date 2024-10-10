using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private CharacterPanel characterPanel;
    public float moveTime = 3;//�ƶ�ʱ��
    private float _moveTime;//��ֵ
    private float waitTime = 3;//�ȴ�ʱ��
    private float _waitTime;//��ֵ

    private bool OneIsMustJump = true;//һ��ͷ����⣬��Ծ�ж�
    private int OneTurn = 1;//һ��ת�򣬷�ֹ�鴤
    // Start is called before the first frame update
    void Start()
    {
        characterPanel = transform.GetComponent<CharacterPanel>();
        _moveTime = moveTime;
        _waitTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        RandomMove();
        //JumpObstacle();
        CliffTurn();
        ObstacleTurn();
    }
    //��������ƶ�
    private void RandomMove()
    {
        if (moveTime > 0)//��������ƶ�ʱ��
        {
            characterPanel.move();
            moveTime -= Time.deltaTime;//�ƶ�ʱ�����һ��
            if (moveTime < 0)
            {
                waitTime = _waitTime;//��ʼ���ȴ�ʱ��
            }
        }
        else
        {
            characterPanel.idle();
            if (waitTime > 0)//������ڵȴ�ʱ��
            {
                waitTime -= Time.deltaTime;//�ȴ�ʱ�����һ��
            }
            else
            {
                moveTime = _moveTime;//��ʼ���ƶ�ʱ��
                //�ȴ����������ת��
                bool Isturn = (Random.value > 0.5f);
                if (Isturn)
                {
                    characterPanel.Turndir();//ת��
                }


            }
        }
    }
    //��Ծ�ϰ���
    private void JumpObstacle()
    {

        for (int i = -1; i <= 1; i++)//iȡ-1,0,1,ʹ��y����������������߼�⣬�γ�һ��С�Ƚ�
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, characterPanel.lookdir * new Vector3(0.25f, -0.15f * i, 0),
                               2, LayerMask.GetMask("Platform", "Items"));//���������ͼ��
            if (hit)//��⵽������׬��
            {
                Debug.DrawLine(transform.position, hit.point);
                if (hit.point.y <= transform.position.y)//�ŵ�ǰ����ǰ����⵽
                {
                    characterPanel.jump();
                }
                else
                { //ͷ��ǰ����⵽ ������뺬��Ϊ��ͷ����⵽�����ж�Ҫ��Ҫ�����������ȥ��
                  //������ȥ���棬��Ҫʹ��3����OneIsMustJumpΪflase,�߹�ȥ����������ͷ��ǰ���ж������ٽ���һ���ж���
                    bool mustJump = false;
                    if (OneIsMustJump)
                    {
                        mustJump = (Random.value > 0.5f);//����һ���ж��Ƿ���Ծ
                        StartCoroutine(reMustJump()); //����Э�ָ̻�OneIsMustJumpΪtrue
                        OneIsMustJump = false;
                        Debug.Log(mustJump);
                    }
                    if (mustJump)
                    {
                        if (moveTime < _moveTime)
                        {
                            moveTime += Time.deltaTime;//�ƶ�ʱ���һ��ȷ������������ȥ��
                        }
                        characterPanel.jump();
                    }


                }
            }
            else
            {

                Debug.DrawRay(transform.position, characterPanel.lookdir * new Vector3(0.25f, -0.15f * i, 0));
            }

        }






    }
    IEnumerator reMustJump()
    {
        yield return new WaitForSeconds(3);
        waitTime += Time.deltaTime;
        OneIsMustJump = true;
    }
    //�����������ý�ɫ����
    private void CliffTurn()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1),
                            Mathf.Infinity, LayerMask.GetMask("Platform"));
        if (!hit)//���û������ײ��
        {
            if (OneTurn >= 1)
            {
                StartCoroutine(turnDir());//Э��ת��,ת��һ�κ��ӳ�0.5�������һ��ת��,��ֹ����ʱ����Ƶ��ת�򣬳鴤
                OneTurn--;
            }
            characterPanel.move();
        }
        Debug.DrawRay(transform.position, new Vector2(0, -1), Color.blue);
    }
    private void ObstacleTurn()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1),
                            Mathf.Infinity, LayerMask.GetMask("Item"));
        if (!hit)//���û������ײ��
        {
            if (OneTurn >= 1)
            {
                StartCoroutine(turnDir());//Э��ת��,ת��һ�κ��ӳ�0.5�������һ��ת��,��ֹ����ʱ����Ƶ��ת�򣬳鴤
                OneTurn--;
            }
            characterPanel.move();
        }
        Debug.DrawRay(transform.position, new Vector2(0, -1), Color.red);
    }
    IEnumerator turnDir()
    {
        characterPanel.Turndir();//ת��
        yield return new WaitForSeconds(0.5f);
        OneTurn = 1;
    }
}