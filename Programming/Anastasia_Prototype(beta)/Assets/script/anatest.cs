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
        public NavMeshAgent nav;
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
        public bool closetflag = false;
        public Vector3 closetvec;
        // Use this for initialization
        void Start()
        {
            nav = GetComponent<NavMeshAgent>();
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
                nav.destination = transform.position;
            }
            if(closetflag==true)
            {
                nav.destination = closetvec;
                Debug.Log("haha");
            }
            else if(MoveOn)
            {
               
                if(whoAreYou==1)
                {
                    
                    nav.destination = Player1.transform.position;
                }
                else if(whoAreYou==2)
                {
                    nav.destination = Player2.transform.position;
                }
                v1 = (Vec - transform.position).normalized;
                Distancedir = Vector3.Distance(Vec, transform.position);
                if (runflag2 == true)
                {
                    Debug.Log("runrunrun2");
                    nav.speed = 5*1.2f;
                    
                    runflag2 = false;
                }
                else if (runflag == false)
                {
                    nav.speed = 5;

                }

                else if (runflag == true)
                {
                    Debug.Log("runrunrunrun");
                    nav.speed = 5 * 1.2f;
                }
                /*
                if (speed != 0)
                    dir = Quaternion.LookRotation(v1);
                v2.y = dir.eulerAngles.y;
                dir.eulerAngles = v2;

                transform.rotation = Quaternion.Slerp(transform.rotation,dir, TurnSpeed * Time.deltaTime);*/
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
