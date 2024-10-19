using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterPanel : MonoBehaviour
{
    public bool Iscanjump = false;//是否能跳跃，默认不能
    public float Hpmax = 100;//最大生命
    public float Hp = 100;//生命
    public float Atk = 10;//攻击力
    public float AtkRan = 1;//攻击浮动
    public float Def = 10;//防御力
    public float lookdir;//获取初始Scale.x，用于转向 
    public float dropConst = 15;//下坠常数
    public float speed = 5;//地面移动速度
    public float jumpspeedUp = 20;//上升速度
    public float jumpspeedVertiacal = 0.5f;//空中左右移动速度
    private Rigidbody2D rig;//2D刚体
    private Animator ani;
    private Transform Canvas;//获取角色个人UI面板

    
    // Start is called before the first frame update
    void Start()
    {
        Canvas = transform.Find("Canvas");
        ani = transform.GetComponent<Animator>();

        rig = GetComponent<Rigidbody2D>();//获取刚体
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lookdir = transform.localScale.x;
        check();
        //跳跃优化手感
        Quickjump();

    }
    //标准化检查
    private void check()
    {
        if (Hp > Hpmax) Hp = Hpmax;//血量不超过上限
        if (Hp <= 0) { Hp = 0; death(); };//血量不超过下限，且死亡
    }
    //受伤,其他脚本调用
    public void hurt(float atk)
    {
        float hurtnum = (20 * atk / (20 + Def)) + Random.Range(-AtkRan, AtkRan);
        //受伤动画 为什么要将触发器中的受伤动画移动在角色面板的hurt函数下？因为受伤不仅有角色攻击受伤，还有陷阱，掉落等伤害，所以直接血量减少时播放受伤动画更加好
        transform.GetComponent<Animator>().SetBool("Ishurt", true);
        StartCoroutine(endHurt());//开启协程结束受伤动画
        //伤害数值显示
        //Canvas.GetComponent<CharaCanvas>().ShowHurtText(hurtnum);
        Hp -= hurtnum;

    }
    IEnumerator endHurt()
    {
        yield return 0;//此处暂停，下一帧执行
        transform.GetComponent<Animator>().SetBool("Ishurt", false);
    }
    //死亡
    private void death()
    {
        ani.SetBool("Isdeath", true);
    }
    //跳跃
    public void jump()
    {
        if (Iscanjump == true)
        {
            rig.velocity = new Vector2(0, jumpspeedUp);//设置刚体速度，给予向量
        }
    }
    //优化跳跃手感，迅速下落,放入帧频率更新函数里面
    public void Quickjump()
    {
        float a = dropConst * 5 - Mathf.Abs(rig.velocity.y);//通过下坠常数，空中速度快为0时，下坠常数a越大，即越快速 度过这个状态
        rig.velocity -= Vector2.up * a * Time.deltaTime;
    }
    //以下是敌人的调运行为函数
    //转向
    public void Turndir()
    {
        transform.localScale = new Vector3(-lookdir, transform.localScale.y, transform.localScale.z);//通过改变scale改变方向
    }
    //移动
    public void move()
    {
        Vector3 vt = new Vector3(lookdir / Mathf.Abs(lookdir), 0, 0);
        //空中左右移动，为地面jumpcharacterPanel.speedVertiacal倍
        if (Iscanjump == false)
        {
            gameObject.transform.Translate(vt * speed * jumpspeedVertiacal * Time.deltaTime);//通过这个函数来使用vt使得左右移动
        }
        //地面左右移动
        else { gameObject.transform.Translate(vt * speed * Time.deltaTime); }
        //ani.SetBool("Ismove", true);

        //斜坡移动
        

    }
    //等待
    public void idle()
    {
        //ani.SetBool("Ismove", false);
    }
}