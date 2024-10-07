using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class RayCastTest : MonoBehaviour
{
    [HideInInspector]public GameObject obj;

    public float torqueForce;
    // Start is called before the first frame update
    void Start()
    {
        obj = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Ray2D ray = new Ray2D(pos,Vector3.forward);
            //RaycastHit2D hit;
            //if (Physics2D.Raycast(ray, out hit))
            //{
            //    obj = hit.collider.gameObject;    //获得选中物体
            //    Debug.Log("选中");
            //}
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.forward);
            if (hit && (hit.collider.gameObject.name == "Box" || hit.collider.gameObject.name == "Bridge"))
            {
                obj = hit.collider.gameObject;
                Debug.Log("选中");
            }
        }
        if(obj != null && Input.GetMouseButtonDown(1))
        {
            obj.GetComponent<Rigidbody2D>().gravityScale = 1;
            obj = null;
        }
        if(obj != null && Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            obj.GetComponent<Rigidbody2D>().AddTorque(torqueForce);
        }
        if(obj != null)
        {
            //pos为目标位置
            Vector2 pos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            //处理需要更改
            //obj.transform.position = pos;
            //Vector2 direction = (pos - obj.transform.position).normalized;
            obj.GetComponent<Rigidbody2D>().gravityScale = 0;
            obj.transform.position = Vector2.Lerp(obj.transform.position,pos,Time.deltaTime);
            //obj.GetComponent<Rigidbody2D>().AddForce((pos - obj.transform.position) * 2);
        }
    }
}
