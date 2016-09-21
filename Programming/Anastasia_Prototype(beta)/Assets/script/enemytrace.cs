using UnityEngine;
using System.Collections;

public class enemytrace : MonoBehaviour {
    public GameObject Player1;
    private NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        _agent.destination = Player1.transform.position;
    }
}
