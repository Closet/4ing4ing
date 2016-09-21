using UnityEngine;
using System.Collections;

namespace Chronos.Example
{
    public class Player2 : MonoBehaviour
    {

        public GameObject timekeeper;
        public int rewindCount = -1;

        private GlobalClock[] globalclocks;
        private GlobalClock root;
        private NavMeshAgent nav;
        private Vector3 dest;
        private Timeline timeline;

        void Start()
        {
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
            Debug.Log(root.key);
            timeline = GetComponent<Timeline>();

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
            if (Vector3.Distance(transform.position, dest) < 1)
            {
                RandomDest();
            }
            else
            {
                nav.destination = dest;
            }
        }

        void RandomDest()
        {
            dest.x = Random.Range(-8f, 8f);
            dest.y = 0.25f;
            dest.z = Random.Range(-4.5f, 4.5f);
            nav.destination = dest;
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
