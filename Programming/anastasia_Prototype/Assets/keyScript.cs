using UnityEngine;
using System.Collections;

public class keyScript : MonoBehaviour {
    public bool getKey;
    public GameObject key;
    public Light keylight;


    // Use this for initialization
    void Start () {
        getKey = false;
	}

    // Update is called once per frame
    void OnTriggerStay(Collider Get)
    {
        if ((Get.GetComponent<Collider>().tag == "Player" || Get.GetComponent<Collider>().tag == "Player2") && Input.GetKeyDown("g"))
        {
            getKey = true;
            MeshRenderer m = key.GetComponent<MeshRenderer>();

            m.enabled = false;
        }


    }

}
