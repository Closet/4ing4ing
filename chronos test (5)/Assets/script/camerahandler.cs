using UnityEngine;
using System.Collections;

public class camerahandler : MonoBehaviour {
    public static Vector3 vec1;

	// Use this for initialization
	void Start () {
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
        else if(Variable.char_flag=true)
        {
            vec1 = Variable.Player2_position;
            vec1.y = 10;
            transform.position = vec1;
        }
    }
  
}
