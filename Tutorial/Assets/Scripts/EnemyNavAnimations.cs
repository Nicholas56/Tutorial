using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavAnimations : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    int IdleState;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        StartCoroutine("changeIdle");
    }

    // Update is called once per frame
    void Update()
    {
        //print(agent.velocity.magnitude);
        if (agent)
        {
            anim.SetFloat("Speed", agent.velocity.magnitude);
            anim.SetInteger("IdleState", IdleState);
        }
    }

    IEnumerator changeIdle()
    {
        yield return new WaitForSeconds(10.0f);
        IdleState = Random.Range(0, 2);
        StartCoroutine("changeIdle");
    }
}
