using UnityEngine;
using System.Collections;

public class camerahandler : MonoBehaviour {
    public static Vector3 vec1;
    public Vector3 vec;
    
    // Use this for initialization
    void Start () {
        vec = GameObject.Find("StopPlayer").transform.position;
        Variable.Player1_position = vec;
        vec = GameObject.Find("rewindPlayer2").transform.position;
        Debug.Log("bbbbbbbbbbbbbbb");
        Variable.Player2_position = vec;
        vec1 = Variable.Player1_position;
        vec1.y = 10;
        transform.position= vec1;
	}
	
	// Update is called once per frame
	void Update () {
        if(Variable.char_flag==false)
        {
            vec1 = Variable.Player1_position;
            vec1.y = 10;
            transform.position = vec1;
        }
        else if(Variable.char_flag==true)
        {
            vec1 = Variable.Player2_position;
            vec1.y = 10;
            transform.position = vec1;
        }
    }
  
}
