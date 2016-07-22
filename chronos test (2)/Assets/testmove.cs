using UnityEngine;
using System.Collections;

namespace Chronos.Example
{
	public class testmove : MonoBehaviour {

		public GameObject timeline;
		public GameObject rewindArea;
		public int speed = 1;

		private GlobalClock[] globalclocks;
		private Vector3 dest;
		private GlobalClock root;
		private bool rewindSw;
		private int count = 0;
        private bool flag = false;
		void Start()
		{
			globalclocks=timeline.GetComponents<GlobalClock>();
			for (int i = 0; i < globalclocks.Length; ++i) {
				if (globalclocks [i].key == "Root") {
					root = globalclocks [i];
				}
			}
           
		}
       
		// Update is called once per frame
		void Update () {
           
             Variable.char_flag = flag;
            Debug.Log(Variable.char_flag);
            if (rewindSw == true) {
				++count;
				if (count == 120) {
					rewindSw = false;
					rewindArea.SetActive (false);
				}
				return;
			}
            if (Input.GetKeyDown(KeyCode.D))
            {
                if(flag==false)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            Vector3 pos = transform.position;
			Vector3 playerPos = transform.position;
			
            //if (clock.localTimeScale > 0) {
            if (this.gameObject.tag == "Player"&&flag==false)
            {
                Debug.Log("hahah");
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    pos.x += speed * Time.deltaTime;// * clock.localTimeScale;
                    transform.position = pos;
                    Variable.Player1_position = transform.position;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    pos.x += -1 * speed * Time.deltaTime;// * clock.localTimeScale;
                    transform.position = pos;
                    Variable.Player1_position = transform.position;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    pos.z += speed * Time.deltaTime;// * clock.localTimeScale;
                    transform.position = pos;
                    Variable.Player1_position = transform.position;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    pos.z += -1 * speed * Time.deltaTime;// * clock.localTimeScale;
                    transform.position = pos;
                    Variable.Player1_position = transform.position;
                }
                //}
                if (Input.GetKeyDown(KeyCode.X))
                {
                    if (root.localTimeScale == 0)
                    {
                        root.localTimeScale = 1;
                    }
                    else
                    {
                        root.localTimeScale = 0;
                    }
                }
            }
            else if(this.gameObject.tag == "Player2" && flag == true)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    rewindSw = true;
                    count = 0;
                    playerPos.y = 0;
                    rewindArea.transform.position = playerPos;
                    rewindArea.SetActive(true);
                    rewindArea.GetComponent<RewindArea>().rewindSw = true;
                }
                Debug.Log("hoho");
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    pos.x += speed * Time.deltaTime;// * clock.localTimeScale;
                    transform.position = pos;
                    Variable.Player2_position = transform.position;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    pos.x += -1 * speed * Time.deltaTime;// * clock.localTimeScale;
                    transform.position = pos;
                    Variable.Player2_position = transform.position;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    pos.z += speed * Time.deltaTime;// * clock.localTimeScale;
                    transform.position = pos;
                    Variable.Player2_position = transform.position;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    pos.z += -1 * speed * Time.deltaTime;// * clock.localTimeScale;
                    transform.position = pos;
                    Variable.Player2_position = transform.position;
                }
                //}
            }

        }
	}
}
