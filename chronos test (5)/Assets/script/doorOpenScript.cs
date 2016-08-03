using UnityEngine;
using System.Collections;
namespace Chronos.Example{
	
	public class doorOpenScript : MonoBehaviour {
		public GameObject timekeeper;
		public int rewindCount = -1;

		private GlobalClock[] globalclocks;
		private GlobalClock root;
		private NavMeshAgent nav;
		private Vector3 dest;
		public Transform Door;
		public GameObject button;
		public float speed = 2F;
		public Color color= Color.red;
		private float startTime;
		public bool isTrue;
		private Timeline timeline;
		void Start(){
			startTime = 0f;
			nav = GetComponent<NavMeshAgent>();
			
			globalclocks = timekeeper.GetComponents<GlobalClock>();
			for (int i = 0; i < globalclocks.Length; ++i)
			{
				if (globalclocks[i].key == "Root")
				{
					root = globalclocks[i];
				}
			}
			Debug.Log(root.key);
			timeline = GetComponent<Timeline>();
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
}
