using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private CharacterPanel characterPanel;
    public float moveTime = 3;//移动时间
    private float _moveTime;//定值
    private float waitTime = 3;//等待时间
    private float _waitTime;//定值

    private bool OneIsMustJump = true;//一次头顶检测，跳跃判断
    private int OneTurn = 1;//一次转向，防止抽搐
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
    //随机横向移动
    private void RandomMove()
    {
        if (moveTime > 0)//如果处于移动时间
        {
            characterPanel.move();
            moveTime -= Time.deltaTime;//移动时间减少一秒
            if (moveTime < 0)
            {
                waitTime = _waitTime;//初始化等待时间
            }
        }
        else
        {
            characterPanel.idle();
            if (waitTime > 0)//如果处于等待时间
            {
                waitTime -= Time.deltaTime;//等待时间减少一秒
            }
            else
            {
                moveTime = _moveTime;//初始化移动时间
                //等待结束，随机转向
                bool Isturn = (Random.value > 0.5f);
                if (Isturn)
                {
                    characterPanel.Turndir();//转向
                }


            }
        }
    }
    //跳跃障碍物
    private void JumpObstacle()
    {

        for (int i = -1; i <= 1; i++)//i取-1,0,1,使得y轴变正负，三条射线检测，形成一个小扇角
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, characterPanel.lookdir * new Vector3(0.25f, -0.15f * i, 0),
                               2, LayerMask.GetMask("Platform", "Items"));//检测这俩种图层
            if (hit)//检测到了有碰赚点
            {
                Debug.DrawLine(transform.position, hit.point);
                if (hit.point.y <= transform.position.y)//脚底前方或前方检测到
                {
                    characterPanel.jump();
                }
                else
                { //头顶前方检测到 下面代码含义为，头顶检测到首先判断要不要跳，还是钻过去，
                  //如果钻过去下面，就要使得3秒内OneIsMustJump为flase,走过去，三秒后如果头顶前方有东西，再进行一次判定再
                    bool mustJump = false;
                    if (OneIsMustJump)
                    {
                        mustJump = (Random.value > 0.5f);//进行一次判断是否跳跃
                        StartCoroutine(reMustJump()); //开启协程恢复OneIsMustJump为true
                        OneIsMustJump = false;
                        Debug.Log(mustJump);
                    }
                    if (mustJump)
                    {
                        if (moveTime < _moveTime)
                        {
                            moveTime += Time.deltaTime;//移动时间加一秒确定能让他跳过去；
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
    //悬崖勒马，不让角色跳崖
    private void CliffTurn()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1),
                            Mathf.Infinity, LayerMask.GetMask("Platform"));
        if (!hit)//检测没有有碰撞点
        {
            if (OneTurn >= 1)
            {
                StartCoroutine(turnDir());//协程转向,转向一次后延迟0.5秒才能下一次转向,防止过短时间内频繁转向，抽搐
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
        if (!hit)//检测没有有碰撞点
        {
            if (OneTurn >= 1)
            {
                StartCoroutine(turnDir());//协程转向,转向一次后延迟0.5秒才能下一次转向,防止过短时间内频繁转向，抽搐
                OneTurn--;
            }
            characterPanel.move();
        }
        Debug.DrawRay(transform.position, new Vector2(0, -1), Color.red);
    }
    IEnumerator turnDir()
    {
        characterPanel.Turndir();//转向
        yield return new WaitForSeconds(0.5f);
        OneTurn = 1;
    }
}