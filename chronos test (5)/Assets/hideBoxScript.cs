using UnityEngine;
using System.Collections;

public class hideBoxScript : MonoBehaviour {
	public GameObject player;
	public GameObject player2;

	void OnTriggerEnter(Collider Get)
	{
		if (Get.GetComponent<Collider> ().tag == "Player") {
			
			player.transform.gameObject.tag = "hidePlayer";
		}
		if (Get.GetComponent<Collider> ().tag == "Player2") {

			player2.transform.gameObject.tag = "hidePlayer2";
		}
	}
}
