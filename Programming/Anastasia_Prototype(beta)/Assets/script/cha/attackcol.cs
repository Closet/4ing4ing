using UnityEngine;
using System.Collections;
namespace Chronos.Example
{
    public class attackcol : MonoBehaviour
    {
        void OnTriggerStay(Collider col)
        {
            if (col.tag == "Enemy" && Input.GetKeyDown("z"))
            {
                Debug.Log("attack");
                //GameObject.FindGameObjectsWithTag("Player")
                //s  GetComponent<testmove>().attackflag = true;
                GetComponent<testmove>().attackflag = true;
                col.GetComponent<TestEnemy>().SW = 1;
            }
            if (col.tag == "closet")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<testmove>().closetflag = true;
                GameObject.FindGameObjectWithTag("anata").GetComponent<anatest>().closetvec = col.transform.position;

            }
        }
        void OnTriggerExit(Collider col)
        {
            if (col.tag == "closet")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<testmove>().closetflag = false;

            }
        }
    }
}
