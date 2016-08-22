using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Chronos.Example
{
	public class testmove : MonoBehaviour {
        public Image skill1;
        public Image skill2;
        public Image skill3;
        public GameObject Player1;
        public GameObject Player2;
		public GameObject timeline;
		public GameObject rewindArea;
        public GameObject stopArea;
        public GameObject on;
        public GameObject off;
		public int speed = 6;
        public GameObject anatasha;
		private GlobalClock[] globalclocks;
		private Vector3 dest;
		private GlobalClock root;
		private bool rewindSw;
		private int count = 0;
        private bool flag = false;
        private float runspeed = 1;
        private float ratio1 = 1f;
        private float ratio2 = 1f;
        private float ratio3 = 1f;
        private bool item_flag = false;
        private int qPress = 0;
        public bool autocome = false;
        private Timeline timeline1;
        private Timeline timeline2;
        public int rewindCount1 = -1;
        public int rewindCount2 = -1;
        public bool comeflag = false;
        public int qcount = 0;
        public float skill_gaze1 = 100;
        public float skill_gaze2 = 100;
        public bool skill2_flag = false;
        void Start()
		{
            autocome = false;
            qPress = 0;
            item_flag = false;
            ratio1 = 1.0f;
            ratio2 = 1.0f;
            ratio3 = 1.0f;
            
            globalclocks =timeline.GetComponents<GlobalClock>();
			for (int i = 0; i < globalclocks.Length; ++i) {
				if (globalclocks [i].key == "Root") {
					root = globalclocks [i];
				}
			}
            timeline1 = GetComponent<Timeline>();
        }
		// Update is called once per frame
		void Update () {
            Vector3 pos1 = Player1.transform.position;
            Vector3 playerPos1 = Player1.transform.position;
            Vector3 pos2 = Player2.transform.position;
            Vector3 playerPos2 = Player2.transform.position;
            if (rewindCount1 >= 0)
            {
                ++rewindCount1;
                if (rewindCount1 == 120)
                {
                    timeline1.globalClockKey = "TimeStopPlayer";
                    rewindCount1 = -1;
                }
            }
            if (rewindCount2 >= 0)
            {
                ++rewindCount2;
                if (rewindCount2 == 120)
                {
                    timeline2.globalClockKey = "TimeStopPlayer";
                    rewindCount2 = -1;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (item_flag == false)
                {
                    item_flag = true;
                    on.SetActive(false);
                    off.SetActive(true);
                    
                }
                else if (item_flag == true)
                {
                    item_flag = false;
                    on.SetActive(true);
                    off.SetActive(false);
                }
            }
            if (ratio1 < 1)
            {
                ratio1 -= 0.01f;
                skill1.fillAmount = ratio1;
                if (ratio1 < 0)
                {
                    
                    ratio1 = 1f;
                    skill1.fillAmount = ratio1;
                }
               
            }
            if (ratio2 < 1)
            {
                ratio2 -= 0.01f;
                skill2.fillAmount = ratio2;
                if (ratio2 < 0)
                {
                    ratio2 = 1f;
                    skill2.fillAmount = ratio2;
                }                
            }
            if (ratio3 < 1)
            {
                ratio3 -= 0.01f;
                skill3.fillAmount = ratio3;
                if (ratio3 < 0)
                {
                    ratio3 = 1f;
                    skill3.fillAmount = ratio3;
                }
                
            }
            runspeed = 1;
             Variable.char_flag = flag;
            if (rewindSw == true) {
				++count;
                rewindArea.transform.position = playerPos2;
               
				
			}
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (flag == false)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                runspeed = 1.2f;
                if(anatasha.GetComponent<anatest>().MoveOn == true)
                {
                    Debug.Log("run2");
                    anatasha.GetComponent<anatest>().runflag2 = true;
                }
            }
            //스킬 gaze
            if(root.localTimeScale==0)
            {
                //skill_gaze1 -= 1f;
                if (skill_gaze1 < 0)
                {
                    skill_gaze1 = 0;
                    stopArea.SetActive(false);
                    root.localTimeScale = 1;
                    if (comeflag == true)
                    {
                        anatasha.GetComponent<anatest>().MoveOn = true;
                    }
                    Debug.Log("end1");
                }
            }
            if(rewindSw==true)
            {
                //skill_gaze2 -= 1f;
                if(false)
                {
                    skill_gaze2 = 0;
                    rewindSw = false;
                    rewindArea.SetActive(false);
                    Debug.Log("end2");
                }
            }


            //
            //if (clock.localTimeScale > 0) {
            if (flag==false)
            {                               
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    pos1.x += speed * Time.deltaTime*runspeed;// * clock.localTimeScale;
                    Player1.transform.position = pos1;
                    Variable.Player1_position = Player1.transform.position;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    pos1.x += -1 * speed * Time.deltaTime * runspeed;// * clock.localTimeScale;
                    Player1.transform.position = pos1;
                    Variable.Player1_position = Player1.transform.position;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    pos1.z += speed * Time.deltaTime * runspeed;// * clock.localTimeScale;
                    Player1.transform.position = pos1;
                    Variable.Player1_position = Player1.transform.position;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    pos1.z += -1 * speed * Time.deltaTime * runspeed;// * clock.localTimeScale;
                    Player1.transform.position = pos1;
                    Variable.Player1_position = Player1.transform.position;
                }
                //}
                if (Input.GetKeyDown(KeyCode.S))
                {
                    ratio1 -= 0.01f;
                    if (root.localTimeScale == 0)
                    {
                        stopArea.SetActive(false);
                        root.localTimeScale = 1;
                        if(comeflag==true)
                        {
                            anatasha.GetComponent<anatest>().MoveOn = true;
                        }
                    }
                    else
                    {
                        if (skill_gaze1 > 0)
                        {
                            if (anatasha.GetComponent<anatest>().MoveOn == true)
                            {
                                comeflag = true;
                            }
                            anatasha.GetComponent<anatest>().MoveOn = false;
                            stopArea.SetActive(true);
                            root.localTimeScale = 0;
                        }
                    }
                }
            }
            else if( flag == true)
            {
                if (rewindSw == true)
                {
                    runspeed = 0.2f;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    //  if()
                    if (rewindSw == false&&skill_gaze2>0)
                    {
                        rewindSw = true;
                        count = 0;
                        playerPos2.y = 0;
                        rewindArea.transform.position = playerPos2;
                        rewindArea.SetActive(true);
                        rewindArea.GetComponent<RewindArea>().rewindSw = true;
                        ratio2 -= 0.01f;
                    }
                    else
                    {
                        rewindSw = false;
                        rewindArea.SetActive(false);
                    }
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    pos2.x += speed * Time.deltaTime * runspeed;// * clock.localTimeScale;
                    Player2.transform.position = pos2;
                    Variable.Player2_position = Player2.transform.position;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    pos2.x += -1 * speed * Time.deltaTime * runspeed;// * clock.localTimeScale;
                    Player2.transform.position = pos2;
                    Variable.Player2_position = Player2.transform.position;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    pos2.z += speed * Time.deltaTime * runspeed;// * clock.localTimeScale;
                    Player2.transform.position = pos2;
                    Variable.Player2_position = Player2.transform.position;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    pos2.z += -1 * speed * Time.deltaTime * runspeed;// * clock.localTimeScale;
                    Player2.transform.position = pos2;
                    Variable.Player2_position = Player2.transform.position;
                }
                //}
            }
            if(qcount>0)
            {
                qcount++;
                if (qcount == 90)
                    qcount = 0;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (qcount>0 && anatasha.GetComponent<anatest>().MoveOn == true)
                {
                    anatasha.GetComponent<anatest>().runflag = true;
                    Debug.Log("DOWN");
                }
                //
                else if(qcount ==0  && anatasha.GetComponent<anatest>().MoveOn == true)
                {
                    Debug.Log("DONT come");
                    anatasha.GetComponent<anatest>().donotcome = true;
                    anatasha.GetComponent<anatest>().autocome = false;

                    anatasha.GetComponent<anatest>().whoAreYou = 0;
                    autocome = false;
                }
                else if (autocome == false)
                {
                    anatasha.GetComponent<anatest>().MoveOn = true;
                    if (flag == false)
                    {
                        anatasha.GetComponent<anatest>().whoAreYou = 1;
                    }
                    else
                    {
                        anatasha.GetComponent<anatest>().whoAreYou = 2;
                    }
                }
                qcount = 1;

            }
            if (Input.GetKey(KeyCode.Q))
            {
                if (qPress > 120)
                {
                    autocome = true;
                    anatasha.GetComponent<anatest>().autocome = true;
                    Debug. Log("dadada");
                }
                else if(qPress == 0 && autocome == true)
                {
                    Debug.Log("do not come");
                    anatasha.GetComponent<anatest>().donotcome = true;
                    anatasha.GetComponent<anatest>().autocome = false;

                    anatasha.GetComponent<anatest>().whoAreYou = 0;
                    autocome = false;
                }
              
                qPress++;
            }
            
            if (autocome==true)
            {
                anatasha.GetComponent<anatest>().MoveOn = true;
            }
            if(Input.GetKeyUp(KeyCode.Q)&&qPress>0)
            {
                Debug.Log("asadasd");
                qPress = 0;
            }
        }
        public void StartRewind()
        {
            
            Debug.Log(timeline1.globalClockKey);
            if (rewindCount1 == -1)
            {
                timeline1.globalClockKey = "Rewind";
                rewindCount1 = 0;
            }
        }
    }
}
