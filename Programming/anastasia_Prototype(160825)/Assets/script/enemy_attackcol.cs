using UnityEngine;
using System.Collections;
namespace Chronos.Example
{
    public class enemy_attackcol : MonoBehaviour
    {

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
            if (transform.parent.gameObject.GetComponent<TestEnemy>().Mode == 1)
            {
                if (col.tag == "Player" || col.tag == "Player2" || col.tag == "anata")
                {
                    Debug.Log("attack");
                    transform.parent.gameObject.GetComponent<TestEnemy>().Mode = 4;//attack
                }
            }
        }
    }
}