using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBox : MonoBehaviour
{
    private Animator ani;
    private AnimatorStateInfo state;//����״̬
    private bool IsPlayerExist;//�����Ƿ���ڹ�����Χ��
    // Start is called before the first frame update
    void Start()
    {
        ani = transform.GetComponentInParent<Animator>();
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        //��������
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
        //�����˳���Χ
        if (collision.tag == "Player" && IsPlayerExist == true)
        {
            IsPlayerExist = false;
            ani.SetInteger("attack", 0);

        }
    }
    private void attack()
    {


        state = ani.GetCurrentAnimatorStateInfo(0);

        //�жϲ�����������߳���Χ
        if ((state.IsName("attack1") || state.IsName("attack2")) && state.normalizedTime > 1f)
        {

            ani.SetInteger("attack", 0);

        }
        //��������ڷ�Χ��
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
