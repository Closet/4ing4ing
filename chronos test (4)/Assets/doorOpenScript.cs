using UnityEngine;
using System.Collections;

public class doorOpenScript : MonoBehaviour {

	public Transform Door;
	public GameObject button;
	public float speed = 2F;
	public Color color= Color.red;
	private float startTime;
	public bool isTrue;
	void Start(){
		startTime = 0f;
	}

	void Update(){

		if (isTrue) {
			startTime += Time.deltaTime;

			if (startTime <= 2f) {
				Door.Translate (new Vector3 (0, 0, -speed * Time.deltaTime));
			}
			if (startTime>5f && startTime<=7f){
				Door.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
			}

			if (startTime > 7f) {
				isTrue = false;
				button.GetComponent<Renderer> ().material.color = Color.red;
				startTime = 0f;

			}


		}
	}
	void OnTriggerEnter(Collider Get)
	{
		if ((Get.GetComponent<Collider>().tag == "Player" || Get.GetComponent<Collider>().tag == "Player2")) 
		{	
			isTrue = true;
			button.GetComponent<Renderer> ().material.color = Color.yellow;
		}


	}
		
}
