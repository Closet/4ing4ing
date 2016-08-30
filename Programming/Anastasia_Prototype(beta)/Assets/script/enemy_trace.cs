using UnityEngine;
using System.Collections;
namespace Chronos.Example
{
    public class enemy_trace : MonoBehaviour
    {
        RaycastHit Hit;//Player1
        
        public GameObject Player1;
        public GameObject Player2;
        public GameObject anata;
        Vector3 vec;
        NavMeshHit hit;
        NavMeshHit hit2;
        private NavMeshAgent agent;
        public GameObject target;
        int layerMask;
        // Use this for initialization
        void Start()
        {
            agent = transform.parent.gameObject.GetComponent<NavMeshAgent>();
            layerMask = (-1) - ((1 << LayerMask.NameToLayer("Useray")));
            Debug.Log(layerMask);
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider col)
        {
            
            
        }
        void OnTriggerStay(Collider col)
        {

            if ((transform.parent.gameObject.GetComponent<TestEnemy>().Mode == 0|| transform.parent.gameObject.GetComponent<TestEnemy>().Mode == 1|| transform.parent.gameObject.GetComponent<TestEnemy>().Mode == 2)&& transform.parent.gameObject.GetComponent<TestEnemy>().SW==0)
            {
                if (col.gameObject.tag == "Player")
                {
                    if (!agent.Raycast(Player1.transform.position,out hit))
                    {
                        if(Physics.Raycast(transform.position,col.transform.position-transform.position,out Hit, Mathf.Infinity, 1<<8))
                        {
                            Vector3 v = (col.transform.position - transform.position)-transform.forward ;
                            float rad =Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
                            if (rad < 90 && rad > -90)
                            {
                               // Debug.Log(rad);
                                if (Hit.collider.tag == "Player")
                                {
                                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 1;
                                    transform.parent.gameObject.GetComponent<TestEnemy>().count = 0;
                                    transform.parent.gameObject.GetComponent<TestEnemy>().Mode = 1;
                                    transform.parent.gameObject.GetComponent<TestEnemy>().finalvec = transform.position;
                                    if (transform.parent.gameObject.GetComponent<TestEnemy>().recon > 0)
                                    {
                                        transform.parent.gameObject.GetComponent<TestEnemy>().realpo = transform.position;
                                    }
                                }
                            }
                        }
                        
                    }
                }
                if (col.gameObject.tag == "Player2")
                {
                    
                   
                    //  Debug.DrawRay(Hit.origin, Hit.direction * 10f, Color.red, 5f);
                    if (!agent.Raycast(Player2.transform.position, out hit))
                    {
                        if (Physics.Raycast(transform.position, col.transform.position - transform.position, out Hit, Mathf.Infinity, 1 << 8))
                        {
                            Vector3 v = (col.transform.position - transform.position) - transform.forward;
                            float rad = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
                            if (rad < 90 && rad > -90)
                            {
                             //   Debug.Log(rad);
                                if (Hit.collider.tag == "Player2")
                                {

                                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 2;
                                    transform.parent.gameObject.GetComponent<TestEnemy>().count = 0;
                                    transform.parent.gameObject.GetComponent<TestEnemy>().Mode = 1;
                                    transform.parent.gameObject.GetComponent<TestEnemy>().finalvec = transform.position;
                                    if (transform.parent.gameObject.GetComponent<TestEnemy>().recon > 0)
                                    {
                                        transform.parent.gameObject.GetComponent<TestEnemy>().realpo = transform.position;
                                    }
                                }
                            }
                        }
                    }
                }
                if (col.gameObject.tag == "anata")
                {
                    
                        Physics.Raycast(transform.position, (anata.transform.position - transform.position) / 10, out Hit, Mathf.Infinity, layerMask);
                    
                    if (!agent.Raycast(anata.transform.position, out hit))
                    {
                        if (Physics.Raycast(transform.position, col.transform.position - transform.position, out Hit, Mathf.Infinity, 1 << 8))
                        {
                            Vector3 v = (col.transform.position - transform.position) - transform.forward;
                            float rad = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
                            if (rad < 90 && rad > -90)
                            {
                             //   Debug.Log(rad);
                                if (Hit.collider.tag == "anata")

                                {
                                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 3;
                                    transform.parent.gameObject.GetComponent<TestEnemy>().count = 0;
                                    transform.parent.gameObject.GetComponent<TestEnemy>().Mode = 1;
                                    transform.parent.gameObject.GetComponent<TestEnemy>().finalvec = transform.position;
                                    if (transform.parent.gameObject.GetComponent<TestEnemy>().recon > 0)
                                    {
                                        transform.parent.gameObject.GetComponent<TestEnemy>().realpo = transform.position;
                                    }
                                }
                            }
                        }
                    }
                }/*
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
                }*/
            }
            


        }
        /*
        void OnTriggerExit(Collider col)
        {
            if (transform.parent.gameObject.GetComponent<TestEnemy>().count > 60&& transform.parent.gameObject.GetComponent<TestEnemy>().flag != 0)
            {
                if (col.gameObject.tag == "Player1")
                {
                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 0;
                    transform.parent.gameObject.GetComponent<TestEnemy>().count = 0;
                    transform.parent.gameObject.GetComponent<TestEnemy>().Mode = 1;
                }
                if (col.gameObject.tag == "Player2")
                {
                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 0;
                    transform.parent.gameObject.GetComponent<TestEnemy>().count = 0;
                    transform.parent.gameObject.GetComponent<TestEnemy>().Mode = 1;
                }
                if (col.gameObject.tag == "anata")
                {
                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 0;
                    transform.parent.gameObject.GetComponent<TestEnemy>().count = 0;
                    transform.parent.gameObject.GetComponent<TestEnemy>().Mode = 1;
                }
            }
        }*/
    }
}