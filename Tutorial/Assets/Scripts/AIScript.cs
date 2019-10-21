using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public enum Behaviours { Patrol, Combat, Heal, Hide};
    public Behaviours currBehaviour = Behaviours.Patrol;

    public enum Enemy { Patrol, Hider};
    public Enemy type;

    UnityEngine.AI.NavMeshAgent agent;
    public GameObject[] points;
    public int destPoint = 0;

    public Transform player;
    public LayerMask targetLayer;
    Transform healthPoint;
    Transform hidePoint;
    Health healthScript;

    public int findDistance;
    public int chaseDistance;

    float timeUntilNext = -1.0f;
    float delay = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Health>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthPoint = GameObject.FindGameObjectWithTag("Pick Up").transform;
        hidePoint = GameObject.FindGameObjectWithTag("Hide Point").transform;
        points = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    void RunBehaviours()
    {
        switch (currBehaviour)
        {
            case Behaviours.Patrol:
                RunPatrolState();
                break;
            case Behaviours.Combat:
                RunCombatState();
                break;
            case Behaviours.Heal:
                RunHealState();
                break;
            case Behaviours.Hide:
                RunHideState();
                break;
        }
    }

    void RunPatrolState()
    {
        if(Vector3.Distance(transform.position, player.position) < findDistance)
        {
            transform.LookAt(player);
            Ray sightLine = new Ray(transform.position, (player.position - transform.position));
            RaycastHit hitInfo;
            if(Physics.Raycast(sightLine,out hitInfo, 25.0f))
            {
                if (hitInfo.collider.gameObject.tag == "Player")
                {
                    currBehaviour = Behaviours.Combat;
                }              
            }
        }
        else if(agent.remainingDistance < 0.5f)
        {
            if (points.Length == 0)
            {
                return;
            }
            agent.SetDestination(points[destPoint].transform.position);
            //if goes higher than the total number of waypoints -> go back to start of array
            destPoint = (destPoint + 1) % points.Length;
        }
    }

    void RunCombatState()
    {
        if (this.type == Enemy.Hider)
        {
            if (healthScript.getHealth() > 40)
            {
                agent.SetDestination(player.position);
            }
            else
            {
                currBehaviour = Behaviours.Hide;
            }
        }
        else if (Vector3.Distance(transform.position, player.position) > chaseDistance)
        {
            currBehaviour = Behaviours.Patrol;
        }        
        else
        {
            agent.SetDestination(player.position);
        }
    }

    void RunHealState()
    {
        agent.SetDestination(healthPoint.position);
        if (agent.remainingDistance < 0.01f)
        {
            currBehaviour = Behaviours.Patrol;
        }
    }

    void RunHideState()
    {
        agent.SetDestination(hidePoint.position);
        if (Time.time > timeUntilNext)
        {
            healthScript.Damage(-5);
            timeUntilNext =Time.time + delay;
        }
        else if (healthScript.getHealth() >= 90)
        {
            currBehaviour = Behaviours.Combat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.getHealth() < 26&&this.type!=Enemy.Hider)
        {
            currBehaviour = Behaviours.Heal;
        }
        RunBehaviours();
    }
}
