using UnityEngine;
using System.Collections;
namespace Chronos.Example
{
    public class anacollider : MonoBehaviour
    {


        // Use this for initialization
        public GameObject anatasha;
        void OnTriggerEnter(Collider col)
        {
            if (anatasha.GetComponent<anatest>().autocome == false)
            {
                if (col.tag == "Player")
                {
                    Debug.Log("ing");
                    anatasha.GetComponent<anatest>().MoveOn = false;
                    anatasha.GetComponent<anatest>().whoAreYou = 0;
                    anatasha.GetComponent<anatest>().runflag = false;
                }
                else if (col.tag == "Player2")
                {
                    anatasha.GetComponent<anatest>().MoveOn = false;
                    anatasha.GetComponent<anatest>().whoAreYou = 0;
                    anatasha.GetComponent<anatest>().runflag = false;
                }
            }
        }
    }
}
