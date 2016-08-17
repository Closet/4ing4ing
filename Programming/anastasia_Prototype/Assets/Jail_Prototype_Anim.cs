﻿using UnityEngine;
using System.Collections;

public class Jail_Prototype_Anim : MonoBehaviour {
    public Animator doorani;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider Get)
    {
        if ((Get.GetComponent<Collider>().tag == "Player" && Variable.char_flag == false) && Input.GetKeyDown("g"))
        {
            Debug.Log("충돌함");
            doorani.SetTrigger("door_Trigger");
        }
        if ((Get.GetComponent<Collider>().tag == "Player2" && Variable.char_flag == true) && Input.GetKeyDown("g"))
        {
            Debug.Log("충돌함");
            doorani.SetTrigger("door_Trigger");
        }
    }
}
