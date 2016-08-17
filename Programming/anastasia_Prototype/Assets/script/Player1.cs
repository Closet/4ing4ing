using UnityEngine;
using System.Collections;

namespace Chronos.Example
{
    public class Player1 : MonoBehaviour
    {

        public GameObject timekeeper;
        public int rewindCount = -1;

        private GlobalClock[] globalclocks;
        private GlobalClock root;
        private Vector3 dest;
        private Timeline timeline;

        void Start()
        {
           
            timeline = GetComponent<Timeline>();

        }

        void Update()
        {
            if (rewindCount >= 0)
            {
                ++rewindCount;
                if (rewindCount == 120)
                {
                    timeline.globalClockKey = "TimeStopPlayer";
                    rewindCount = -1;
                }
            }
            
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
