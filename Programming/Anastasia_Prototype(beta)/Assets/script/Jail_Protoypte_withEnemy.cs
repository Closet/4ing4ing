using UnityEngine;
using System.Collections;
using System;

public class Jail_Protoypte_withEnemy : MonoBehaviour {

	public Animator doorani;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider Get)
	{
		if ((Get.GetComponent<Collider>().tag == "Player" && Variable.char_flag == false) && Input.GetKeyDown("g"))
		{
			Debug.Log("충돌함");
			doorani.SetTrigger("door_Trigger");
			//   UnityEditor.NavMeshBuilder.BuildNavMesh();
		}
		if ((Get.GetComponent<Collider>().tag == "Player2" && Variable.char_flag == true) && Input.GetKeyDown("g"))
		{
			Debug.Log("충돌함");
			doorani.SetTrigger("door_Trigger");
			//   UnityEditor.NavMeshBuilder.BuildNavMesh();
		}
		/*
		if (Get.GetComponent<Collider> ().tag == "Enemy") {
			{
				if (Get.GetComponent<TestEnemy> ().Mode == 4)
					Debug.Log ("enemy충돌함");
				doorani.SetTrigger ("door_Trigger");
			}
		}
		*/


	}
}
