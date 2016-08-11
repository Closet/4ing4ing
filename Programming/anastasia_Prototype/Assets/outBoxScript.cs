using UnityEngine;
using System.Collections;

public class outBoxScript : MonoBehaviour {

	public GameObject player;
	public GameObject player2;

	void OnTriggerEnter(Collider Get)
	{
		if (Get.GetComponent<Collider> ().tag == "hidePlayer") {

			player.transform.gameObject.tag = "Player";
		}
		if (Get.GetComponent<Collider> ().tag == "hidePlayer2") {

			player2.transform.gameObject.tag = "Player2";
		}
	}
}
