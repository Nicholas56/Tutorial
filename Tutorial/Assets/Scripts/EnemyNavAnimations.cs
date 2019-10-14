using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavAnimations : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(agent.velocity.magnitude);
        if (agent)
        {
            anim.SetFloat("Speed", agent.velocity.magnitude);
        }
    }
}
