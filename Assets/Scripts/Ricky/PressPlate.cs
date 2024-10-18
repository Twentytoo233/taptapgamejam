using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPlate : MonoBehaviour
{
    //[SerializeField]
    //private int value;
    private bool isPressed = false;//是否被按压
    private Vector3 originalPosition;//按压板初始位置
    [SerializeField]
    private float pressDepth = 0.2f;
    public Animator doorAni;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isPressed&&collision.gameObject.CompareTag("Player")||collision.gameObject.CompareTag("HeavyObject"))
        {
            isPressed = true;

            transform.position = new Vector3(transform.position.x, transform.position.y - pressDepth, transform.position.z);
            OpenDoor();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isPressed&& collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("HeavyObject"))
        {
            isPressed = false;
            transform.position = originalPosition;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDoor()
    {
        GameObject door = GameObject.Find("Door");
        //door.transform.position +=Vector3.up * value;
        doorAni.SetTrigger("Open");
        doorAni.SetTrigger("Openkeep");
        //doorAni.ResetTrigger("Open");
    }
}
