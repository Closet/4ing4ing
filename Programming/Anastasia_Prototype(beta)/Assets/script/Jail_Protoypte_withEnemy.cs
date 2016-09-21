using UnityEngine;
using System.Collections;
using System;
using Chronos.Example;

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

	void OnTriggerStay(Collider Get)
	{
		if ((Get.GetComponent<Collider> ().tag == "Player" && Variable.char_flag == false) && (Input.GetKeyDown ("a") || Input.GetKeyDown ("space"))) {
			Debug.Log ("11");
			doorani.SetTrigger ("door_Trigger");
			//   UnityEditor.NavMeshBuilder.BuildNavMesh();
		}
		if ((Get.GetComponent<Collider> ().tag == "Player2" && Variable.char_flag == true) && (Input.GetKeyDown ("a") || Input.GetKeyDown ("space"))) {
			Debug.Log ("11");
			doorani.SetTrigger ("door_Trigger");
			//   UnityEditor.NavMeshBuilder.BuildNavMesh();
		}

		if (Get.GetComponent<Collider> ().tag == "Enemy") {
			if (Get.GetComponent<TestEnemy> ().Mode != 0 && doorani.GetCurrentAnimatorStateInfo (0).IsName ("Default")) {
				Debug.Log ("door open");
				doorani.SetInteger ("doorEnemy", 1);
			}
		}
	}

	void OnTriggerExit(Collider Get2)
	{
		if (Get2.GetComponent<Collider> ().tag == "Enemy") {
			if (Get2.GetComponent<TestEnemy> ().Mode != 0) {
				Debug.Log ("door close");
				doorani.SetInteger ("doorEnemy", 2);
				Debug.Log ("setintegerto0");
				doorani.SetInteger ("doorEnemy", 0);


			}
		}

	}
}

