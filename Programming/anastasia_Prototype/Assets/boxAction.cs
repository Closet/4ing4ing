using UnityEngine;
using System.Collections;

public class boxAction : MonoBehaviour {
	public Rigidbody rb;
	public GameObject Box;
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider Get)
	{
		if (Get.GetComponent<Collider> ().tag == "Enemy") {	
			rb.isKinematic = false;
			rb.detectCollisions = true;
		}
	}
}
