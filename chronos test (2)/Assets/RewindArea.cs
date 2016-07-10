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
				if (count == 5) {
					rewindSw = false;
					count = 0;
				}
			}
		}

		void OnTriggerStay(Collider coll)
		{
			if (rewindSw == true && coll.gameObject.tag == "Object") {
				coll.gameObject.GetComponent<TestEnemy> ().StartRewind ();
			}
		}
	}	
}