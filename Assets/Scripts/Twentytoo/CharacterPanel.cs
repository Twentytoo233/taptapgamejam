using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterPanel : MonoBehaviour
{
    public bool Iscanjump = false;//�Ƿ�����Ծ��Ĭ�ϲ���
    public float Hpmax = 100;//�������
    public float Hp = 100;//����
    public float Atk = 10;//������
    public float AtkRan = 1;//��������
    public float Def = 10;//������
    public float lookdir;//��ȡ��ʼScale.x������ת�� 
    public float dropConst = 15;//��׹����
    public float speed = 5;//�����ƶ��ٶ�
    public float jumpspeedUp = 20;//�����ٶ�
    public float jumpspeedVertiacal = 0.5f;//���������ƶ��ٶ�
    private Rigidbody2D rig;//2D����
    private Animator ani;
    private Transform Canvas;//��ȡ��ɫ����UI���

    
    // Start is called before the first frame update
    void Start()
    {
        Canvas = transform.Find("Canvas");
        ani = transform.GetComponent<Animator>();

        rig = GetComponent<Rigidbody2D>();//��ȡ����
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lookdir = transform.localScale.x;
        check();
        //��Ծ�Ż��ָ�
        Quickjump();

    }
    //��׼�����
    private void check()
    {
        if (Hp > Hpmax) Hp = Hpmax;//Ѫ������������
        if (Hp <= 0) { Hp = 0; death(); };//Ѫ�����������ޣ�������
    }
    //����,�����ű�����
    public void hurt(float atk)
    {
        float hurtnum = (20 * atk / (20 + Def)) + Random.Range(-AtkRan, AtkRan);
        //���˶��� ΪʲôҪ���������е����˶����ƶ��ڽ�ɫ����hurt�����£���Ϊ���˲����н�ɫ�������ˣ��������壬������˺�������ֱ��Ѫ������ʱ�������˶������Ӻ�
        transform.GetComponent<Animator>().SetBool("Ishurt", true);
        StartCoroutine(endHurt());//����Э�̽������˶���
        //�˺���ֵ��ʾ
        //Canvas.GetComponent<CharaCanvas>().ShowHurtText(hurtnum);
        Hp -= hurtnum;

    }
    IEnumerator endHurt()
    {
        yield return 0;//�˴���ͣ����һִ֡��
        transform.GetComponent<Animator>().SetBool("Ishurt", false);
    }
    //����
    private void death()
    {
        ani.SetBool("Isdeath", true);
    }
    //��Ծ
    public void jump()
    {
        if (Iscanjump == true)
        {
            rig.velocity = new Vector2(0, jumpspeedUp);//���ø����ٶȣ���������
        }
    }
    //�Ż���Ծ�ָУ�Ѹ������,����֡Ƶ�ʸ��º�������
    public void Quickjump()
    {
        float a = dropConst * 5 - Mathf.Abs(rig.velocity.y);//ͨ����׹�����������ٶȿ�Ϊ0ʱ����׹����aԽ�󣬼�Խ���� �ȹ����״̬
        rig.velocity -= Vector2.up * a * Time.deltaTime;
    }
    //�����ǵ��˵ĵ�����Ϊ����
    //ת��
    public void Turndir()
    {
        transform.localScale = new Vector3(-lookdir, transform.localScale.y, transform.localScale.z);//ͨ���ı�scale�ı䷽��
    }
    //�ƶ�
    public void move()
    {
        Vector3 vt = new Vector3(lookdir / Mathf.Abs(lookdir), 0, 0);
        //���������ƶ���Ϊ����jumpcharacterPanel.speedVertiacal��
        if (Iscanjump == false)
        {
            gameObject.transform.Translate(vt * speed * jumpspeedVertiacal * Time.deltaTime);//ͨ�����������ʹ��vtʹ�������ƶ�
        }
        //���������ƶ�
        else { gameObject.transform.Translate(vt * speed * Time.deltaTime); }
        //ani.SetBool("Ismove", true);

        //б���ƶ�
        

    }
    //�ȴ�
    public void idle()
    {
        //ani.SetBool("Ismove", false);
    }
}