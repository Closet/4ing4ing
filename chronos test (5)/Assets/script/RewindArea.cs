using UnityEngine;
using System.Collections;
namespace Chronos.Example{
	public class RewindArea : MonoBehaviour {

		public bool rewindSw=false;
		private int count = 0;

		void Update()
		{
			if (rewindSw == true) {
				++count;
				if (count == 1) {
					rewindSw = false;
					count = 0;
				}
			}
		}

		void OnTriggerStay(Collider coll)
		{
            Debug.Log(coll.gameObject.name);
            if (rewindSw == true && coll.gameObject.tag == "Enemy") {
				coll.gameObject.GetComponent<TestEnemy> ().StartRewind ();
                
            }
            if(rewindSw == true && coll.gameObject.tag == "Player")
            {
                coll.gameObject.GetComponent<testmove>().StartRewind();
            }
            if (rewindSw == true && coll.gameObject.tag == "anata")
            {
                coll.gameObject.GetComponent<anatest>().StartRewind();
            }
            if (rewindSw == true && coll.gameObject.tag == "something")
            {
                coll.gameObject.GetComponent<objectrewind>().StartRewind();
            }
        }
	}	
}