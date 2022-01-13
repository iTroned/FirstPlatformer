using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    bool isFlying = false;
    public float sight = 10;
    Animator controller;
    void Start()
    {
        controller = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFlying == true)
        {
            controller.SetBool("IsFlying", true);
        }
        else
        {
            controller.SetBool("IsFlying", false);
        }
        if(Vector2.Distance(transform.position, GameObject.Find("Bombie").transform.position) <= sight)
        {
            isFlying = true;

        }
        else
        {
            isFlying = false;
        }
    }
}
