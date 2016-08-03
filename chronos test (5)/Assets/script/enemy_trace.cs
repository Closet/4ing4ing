using UnityEngine;
using System.Collections;
namespace Chronos.Example
{
    public class enemy_trace : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider col)
        {

            if (transform.parent.gameObject.GetComponent<TestEnemy>().flag == 0)
            {
                if (col.gameObject.tag == "Player1")
                {
                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 1;
                }
                if (col.gameObject.tag == "Player2")
                {
                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 2;
                }
                if (col.gameObject.tag == "anata")
                {
                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 3;
                }
            }
        }
        
        void OnTriggerExit(Collider col)
        {
            if (transform.parent.gameObject.GetComponent<TestEnemy>().count > 180)
            {
                if (col.gameObject.tag == "Player1")
                {
                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 0;
                    transform.parent.gameObject.GetComponent<TestEnemy>().count = 0;
                }
                if (col.gameObject.tag == "Player2")
                {
                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 0;
                    transform.parent.gameObject.GetComponent<TestEnemy>().count = 0;
                }
                if (col.gameObject.tag == "anata")
                {
                    transform.parent.gameObject.GetComponent<TestEnemy>().flag = 0;
                    transform.parent.gameObject.GetComponent<TestEnemy>().count = 0;
                }
            }
        }
    }
}