using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private bool wasPressed;
    public bool WasPressed => wasPressed;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector2 checkBoxSize;
    

    private Transform ts;
    private Vector3 initPos;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        ts = gameObject.transform;
        initPos = ts.position;
        targetPos = ts.position + new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.BoxCast(ts.position + offset, checkBoxSize, 0, Vector2.up,0))
        {
            wasPressed = true;
        }
        else
        {
            wasPressed = false;
        }

        if(WasPressed)
        {
            ts.position = Vector3.Lerp(ts.position, targetPos, Time.deltaTime);
        }
        else
        {
            ts.position = Vector3.Lerp(ts.position, initPos, Time.deltaTime);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(ts != null)
        {
            Gizmos.DrawWireCube(ts.position + offset, checkBoxSize);
        }
    }
}
