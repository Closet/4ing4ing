using UnityEngine;
using System.Collections;
namespace Chronos.Example
{
    public class anatest : MonoBehaviour
    {
        public int whoAreYou;
        public GameObject Player1;
        public GameObject Player2;
        public CharacterController CC;
        public Animation Any;
        public int rewindCount = -1;
        public Vector3 Vec;
        Vector3 v1;
        Vector3 v2;

        Quaternion dir;

        public int speed = 6;
        float TurnSpeed = 5f;
        float Distancedir;

        public bool MoveOn;
        public bool AttackOn;
        public bool autocome;
        public bool runflag;
        public bool donotcome;
        private GlobalClock[] globalclocks;
        private Vector3 dest;
        private GlobalClock root;
        private bool rewindSw;
        private int count = 0;
        private bool flag = false;
        private Timeline timeline;
        public GameObject timekeeper;
        public bool runflag2 = false;
       
        // Use this for initialization
        void Start()
        {
            donotcome = false;
            globalclocks = timekeeper.GetComponents<GlobalClock>();
            for (int i = 0; i < globalclocks.Length; ++i)
            {
                if (globalclocks[i].key == "Root")
                {
                    root = globalclocks[i];
                }
            }
            runflag = false;
            autocome = false;
            MoveOn = false;
            timeline = GetComponent<Timeline>();
        }

        // Update is called once per frame
        void Update()
        {
            if (rewindCount >= 0)
            {
                ++rewindCount;
                if (rewindCount == 120)
                {
                    timeline.globalClockKey = "Character";
                    rewindCount = -1;
                }
            }
            if(donotcome==true)
            {
                MoveOn = false;
                donotcome = false;
                whoAreYou = 0;
              

            }

            if(MoveOn)
            {
               
                if(whoAreYou==1)
                {
                    Vec = Player1.transform.position;
                    
                }
                else if(whoAreYou==2)
                {
                    Vec = Player2.transform.position;
                    Debug.Log(Vec);
                }
                v1 = (Vec - transform.position).normalized;
                Distancedir = Vector3.Distance(Vec, transform.position);
                if (runflag2 == true)
                {
                    Debug.Log("runrunrun2");
                    CC.Move(v1 * speed * Time.deltaTime * 1.2f);
                    CC.Move(new Vector3(0, -0.5f, 0));
                    runflag2 = false;
                }
                else if (runflag == false)
                {
                    CC.Move(v1 * speed * Time.deltaTime);
                    CC.Move(new Vector3(0, -0.5f, 0));
                }

                else if (runflag == true)
                {
                    Debug.Log("runrunrun");
                    CC.Move(v1 * speed * Time.deltaTime * 1.2f);
                    CC.Move(new Vector3(0, -0.5f, 0));
                }
                
                if (speed != 0)
                    dir = Quaternion.LookRotation(v1);
                v2.y = dir.eulerAngles.y;
                dir.eulerAngles = v2;

                transform.rotation = Quaternion.Slerp(transform.rotation,dir, TurnSpeed * Time.deltaTime);
            }
                //}
        }
        public void StartRewind()
        {
            Debug.Log(timeline.globalClockKey);
            if (rewindCount == -1)
            {
                timeline.globalClockKey = "Rewind";
                rewindCount = 0;
            }
        }
    }
}
