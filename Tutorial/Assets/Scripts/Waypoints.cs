using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject waypoints;
    public Transform[] points;
    public int destPoint = 0;

    bool isChase;

    // Start is called before the first frame update
    void Start()
    {
        points = waypoints.GetComponentsInChildren<Transform>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.autoBraking = false;
        GotoNextPoint();
        StartCoroutine("checkFor");
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)        {            return;        }

        agent.SetDestination(points[destPoint].position);

        destPoint = (destPoint + 1) % points.Length;
        //if (destPoint == 0) { destPoint = 1; }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.1f&&isChase)
        {
            GotoNextPoint();
        }
    }

    IEnumerator checkFor()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (((this.transform.position - player.position).magnitude < 7) && (Random.Range(0, 2) == 1))
        {
            isChase = false;
            agent.SetDestination(player.position);
        }
        else { isChase = true; }
        yield return new WaitForSeconds(0.5f);

        StartCoroutine("checkFor");
    }
}
