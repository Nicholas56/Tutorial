using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavMovement : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    public bool isActivated;
    float rotationLimit = 5;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            agent.SetDestination(target.position);
            if (agent.remainingDistance < (agent.stoppingDistance + 0.5f))
            {
                transform.LookAt(target.transform);
            }
            t.eulerAngles = new Vector3(rotationLimit, t.eulerAngles.y, t.eulerAngles.z);
        }
    }
}
