using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSStyle : MonoBehaviour
{
    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }
}
