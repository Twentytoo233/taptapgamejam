using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject Rock;
    public float Cooldown;
    // Use this for initialization
    void Start()
    {
        Cooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown > 0)
        {
            Cooldown -= Time.deltaTime;
        }
        creat();
    }

    public void creat()
    {
        if (Cancreat)
        {
            var enemyform = Instantiate(Rock) as GameObject;
            
            Cooldown = 2f;
        }
    }
    public bool Cancreat
    {
        get
        {
            return Cooldown <= 0f;
        }
    }
}
