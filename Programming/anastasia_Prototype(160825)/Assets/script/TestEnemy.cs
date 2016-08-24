using UnityEngine;
using System.Collections;

namespace Chronos.Example
{
    public class TestEnemy : MonoBehaviour
    {

        public int recon = 0;
        public GameObject timekeeper;
        public int rewindCount = -1;

        private GlobalClock[] globalclocks;
        private GlobalClock root;
        private NavMeshAgent nav;
        private Vector3 dest;
        private Timeline timeline;
        public int flag = 0;
        public GameObject Player1;
        public GameObject Player2;
        public GameObject Ana;
        public GameObject target;
        public Vector3 vec;
        public Vector3 realpo;
        public int count;
        public int Mode = 0;//Ai 0은 주위 근처 수색, AI 1은 쫓는 중
        public Vector3 finalvec;
        public int path;
        public int[] path2 = new int[60];
        public GameObject[] reconpath;
        public int reconcount = 0;
        public int reconnum;
        public int dir = -1;
        public int random = 0;
        void Start()
        {
            if (recon == 1|| recon == 2)
            {
                reconnum = reconpath.Length;
            }
            Mode = 0;
            realpo = this.transform.position;
            vec = new Vector3(0, 0, 0);
            nav = GetComponent<NavMeshAgent>();
            RandomDest();
            globalclocks = timekeeper.GetComponents<GlobalClock>();
            for (int i = 0; i < globalclocks.Length; ++i)
            {
                if (globalclocks[i].key == "Root")
                {
                    root = globalclocks[i];
                }
            }

            timeline = GetComponent<Timeline>();
            Debug.Log(path2.Length);
            for (int i = 0; i < 60; i++)
            {
                path2[i] = 0;
            }
            dir = -1;
        }

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
            if (Mode == 1)//추격
            {
                if (flag > 0)
                {
                    count++;
                }
                if (count == 1)
                {

                    for (int i = 0; i < target.GetComponent<targetaddress>().targetsize; i++)
                    {
                        path2[i] = 0;
                    }
                }
                if (flag == 1)
                {
                    nav.destination = Player1.transform.position;
                }
                else if (flag == 2)
                {
                    nav.destination = Player2.transform.position;
                }
                else if (flag == 3)
                {
                    nav.destination = Ana.transform.position;

                }
                if (count == 60 * 3)
                {
                    flag = 0;
                    count = 0;
                    Mode = 2;
                }
            }
            else if (Mode == 2)//수색
            {
                nav.destination = finalvec;
                count++;
                if (count > 60)
                {
                    findpath();
                }
                if (count == 60 * 10)
                {
                    Mode = 3;
                }
            }

            else if (Mode == 3)//돌아오기
            {
                RandomDest();
            }
            else if (Mode == 4)//공격 
            {
                count++;
                nav.destination = this.transform.position;
                if (count == 60)
                {
                    Mode = 1;
                    count = 2;
                }
            }
            else if (Mode == 0)//대기 and 돌아다니기 
            {
                if (recon == 0)
                {
                    RandomDest();
                }
                else if (recon == 1)
                {
                    reconDest();
                }
                else if(recon==2)
                {
                    reconDeset2();
                }
            }
        }

        void RandomDest()
        {
            nav.destination = realpo;
            if (Vector3.Distance(transform.position, dest) < 10)
            {
                Mode = 0;
            }
        }
        void reconDest()
        {

            nav.destination = reconpath[reconcount % (reconpath.Length)].transform.position;
        }
        void reconDeset2()
        {
            nav.destination = reconpath[random].transform.position;
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
        public void findpath()
        {
            int a = 0;
            for (int i = 0; i < target.GetComponent<targetaddress>().targetsize; i++)
            {
                if (path2[i] == 1)
                {
                    if (i == 0)
                    {
                        if (path2[i + 1] == 0)
                        {
                            a = i + 1;
                            Debug.Log("11111111");
                            if (dir == -1)
                            {
                                dir = 1;
                            }
                            break;
                        }


                    }
                    else if (path2[i + 1] == 0)
                    {
                        a = i + 1;
                        Debug.Log("11111111");
                        if (dir == -1)
                        {
                            dir = 1;
                        }
                        break;
                    }

                    else if (path2[i - 1] == 0)
                    {
                        a = i - 1;
                        Debug.Log("11111111");
                        if (dir == -1)
                        {
                            dir = 0;
                        }
                        break;
                    }

                    if (a == target.GetComponent<targetaddress>().targetsize)
                    {
                        a = 0;
                        if (dir == -1)
                        {
                            dir = 1;
                        }
                        Debug.Log("11111111");
                        break;
                    }

                }

            }
            Debug.Log(a);
            nav.destination = target.GetComponent<targetaddress>().target_address[a].transform.position;
            Debug.Log(target.GetComponent<targetaddress>().target_address[a].transform.position);
        }
    }
}
