using UnityEngine;
using System.Collections;
namespace Chronos.Example
{
    public class enemypath : MonoBehaviour
    {
        private GameObject target;
        // Use this for initialization
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("targethandler");
        }

        // Update is called once per frame
        
        void OnTriggerStay(Collider col)
        {
            if (transform.parent.gameObject.GetComponent<TestEnemy>().Mode == 0)
            {
                if (transform.parent.gameObject.GetComponent<TestEnemy>().recon == 1)
                {
                    if (col.gameObject.tag == "path")
                    {
                      
                        // transform.parent.gameObject.GetComponent<TestEnemy>().path++;
                        //  Debug.Log(transform.parent.gameObject.GetComponent<TestEnemy>().path);
                        for (int i = 0; i < transform.parent.gameObject.GetComponent<TestEnemy>().reconnum; i++)
                        {

                            if (col.gameObject.GetInstanceID() == transform.parent.gameObject.GetComponent<TestEnemy>().reconpath[i].GetInstanceID())
                            {
                                transform.parent.gameObject.GetComponent<TestEnemy>().reconcount = i + 1;
                                


                            }
                        }
                    }
                }
                if (transform.parent.gameObject.GetComponent<TestEnemy>().recon == 2)
                {
                    if (col.gameObject.tag == "path")
                    {
                        
                        // transform.parent.gameObject.GetComponent<TestEnemy>().path++;
                        //  Debug.Log(transform.parent.gameObject.GetComponent<TestEnemy>().path);
                        for (int i = 0; i < transform.parent.gameObject.GetComponent<TestEnemy>().reconnum; i++)
                        {

                            if (col.gameObject.GetInstanceID() == transform.parent.gameObject.GetComponent<TestEnemy>().reconpath[i].GetInstanceID())
                            {
                                int ran;
                                while (true)
                                {
                                    ran = Random.Range(0, transform.parent.gameObject.GetComponent<TestEnemy>().reconnum);
                                    if (ran != i)
                                        break;
                                }
                                transform.parent.gameObject.GetComponent<TestEnemy>().random = ran;


                            }
                        }
                    }
                }
            }
            if (transform.parent.gameObject.GetComponent<TestEnemy>().Mode == 2)
            {
                if (col.gameObject.tag == "path")
                {
                    // transform.parent.gameObject.GetComponent<TestEnemy>().path++;
                    //  Debug.Log(transform.parent.gameObject.GetComponent<TestEnemy>().path);
                    for (int i = 0; i < target.GetComponent<targetaddress>().target_address.Length; i++)
                    {
                        if (col.gameObject.GetInstanceID() == target.GetComponent<targetaddress>().target_address[i].GetInstanceID())
                        {
                            transform.parent.gameObject.GetComponent<TestEnemy>().path2[i] = 1;
                            Debug.Log(i);
                        }
                    }
                }
            }
        }
    }
}