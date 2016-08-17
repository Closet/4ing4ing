using UnityEngine;
using System.Collections;
namespace Chronos.Example
{
    public class enemypath : MonoBehaviour
    {
        public GameObject target;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerStay(Collider col)
        {
            if (transform.parent.gameObject.GetComponent<TestEnemy>().Mode == 0)
            {
                if (transform.parent.gameObject.GetComponent<TestEnemy>().recon == 1)
                {
                    if (col.gameObject.tag == "path")
                    {
                        Debug.Log("asdasd");
                        // transform.parent.gameObject.GetComponent<TestEnemy>().path++;
                        //  Debug.Log(transform.parent.gameObject.GetComponent<TestEnemy>().path);
                        for (int i = 0; i < transform.parent.gameObject.GetComponent<TestEnemy>().reconnum; i++)
                        {

                            if (col.gameObject.GetInstanceID() == transform.parent.gameObject.GetComponent<TestEnemy>().reconpath[i].GetInstanceID())
                            {
                                transform.parent.gameObject.GetComponent<TestEnemy>().reconcount = i + 1;
                                Debug.Log(col.gameObject.GetInstanceID());


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