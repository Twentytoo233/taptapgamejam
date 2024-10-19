using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBox : MonoBehaviour
{
    private Animator ani;
    private AnimatorStateInfo state;//动画状态
    private bool IsPlayerExist;//主角是否存在攻击范围内
    // Start is called before the first frame update
    void Start()
    {
        ani = transform.GetComponentInParent<Animator>();
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        //攻击主角
        if (collision.tag == "Player")
        {
            if (IsPlayerExist == false)
            {
                IsPlayerExist = true;
            }
            attack();

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        //主角退出范围
        if (collision.tag == "Player" && IsPlayerExist == true)
        {
            IsPlayerExist = false;
            ani.SetInteger("attack", 0);

        }
    }
    private void attack()
    {


        state = ani.GetCurrentAnimatorStateInfo(0);

        //判断播放完或主角走出范围
        if ((state.IsName("attack1") || state.IsName("attack2")) && state.normalizedTime > 1f)
        {

            ani.SetInteger("attack", 0);

        }
        //如果主角在范围内
        if (IsPlayerExist == true)
        {

            if (state.IsName("idle") || state.IsName("run") && ani.GetInteger("attack") == 0)
            {

                ani.SetInteger("attack", 1);
            }
            else if (state.IsName("attack1") && ani.GetInteger("attack") == 1)
            {
                ani.SetInteger("attack", 2);
            }

        }
        if (state.normalizedTime >= 1.0f)
        {
            ani.SetFloat("normalizedTime", state.normalizedTime);
        }


    }
}
