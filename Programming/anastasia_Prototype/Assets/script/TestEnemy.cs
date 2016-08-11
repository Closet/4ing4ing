using UnityEngine;
using System.Collections;

namespace Chronos.Example{
	public class TestEnemy : MonoBehaviour {

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
        public Vector3 vec;
        public Vector3 realpo;
        public int count;
        void Start () {
            realpo = this.transform.position;
            vec = new Vector3(0, 0, 0);
			nav = GetComponent<NavMeshAgent> ();
			RandomDest ();
			globalclocks=timekeeper.GetComponents<GlobalClock>();
			for (int i = 0; i < globalclocks.Length; ++i) {
				if (globalclocks [i].key == "Root") {
					root = globalclocks [i];
				}
			}

			timeline = GetComponent<Timeline> ();
            
		}
		
		void Update () {
			
			if (rewindCount >= 0) {
				++rewindCount;
				if (rewindCount == 120) {
					timeline.globalClockKey = "Character";
					rewindCount = -1;
				}
			}
            if(flag>0)
            {
                count ++;
            }
			if(flag==1 && Player1.transform.tag=="Player")
            {
                nav.destination = Player1.transform.position;
            }
			else if(flag==2 && Player2.transform.tag=="Player2")
            {
                nav.destination = Player2.transform.position;
            }
            else if(flag==3)
            {
                nav.destination = Ana.transform.position;
            }
			else {
				RandomDest ();
			} 
		}

		
		void RandomDest()
		{
			dest.x = realpo.x+Random.Range (-8f, 8f);
			dest.y = 0.25f;
			dest.z = realpo.z+Random.Range (-4.5f, 4.5f);
			nav.destination = dest;
		}

		public void StartRewind()
		{
			Debug.Log (timeline.globalClockKey);
			if (rewindCount == -1) {
				timeline.globalClockKey = "Rewind";
				rewindCount = 0;
			}
		}
	}
}
