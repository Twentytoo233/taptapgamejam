using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<GameObject> PressGroup = new List<GameObject>();
    private bool canOpen;
    // Start is called before the first frame update
    void Start()
    {
        canOpen = false;

        //判断物体是否为可触发踏板
        for (int i = 0; i < PressGroup.Count; i++)
        {
            //if (PressGroup[i].tag!="")
        }
    }

    // Update is called once per frame
    void Update()
    {
        canOpen = true;
        for (int i = 0; i < PressGroup.Count; i++)
        {
            if (!PressGroup[i].GetComponent<PressurePlate>().WasPressed)
            {
                canOpen = false;
                break;
            }
        }
        if (canOpen)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up, Time.deltaTime);
        }
    }
}
