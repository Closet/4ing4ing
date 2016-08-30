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
                    anatasha.GetComponent<anatest>().nav.destination = this.transform.position;
                }
                else if (col.tag == "Player2")
                {
                    anatasha.GetComponent<anatest>().MoveOn = false;
                    anatasha.GetComponent<anatest>().whoAreYou = 0;
                    anatasha.GetComponent<anatest>().runflag = false;
                    anatasha.GetComponent<anatest>().nav.destination = this.transform.position;
                }
                if(col.tag == "closet")
                {
                    Debug.Log("hahaha");
                    anatasha.transform.localScale = new Vector3(0, 0, 0);
                }
            }
        }
    }
}
