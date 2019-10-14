﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maximumHealth = 100;
    [SerializeField] int scoreValue = 50;
    int currentHealth = 0;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
        anim = GetComponent<Animator>();
    }

    public bool IsDead { get { return currentHealth <= 0; } }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maximumHealth;
    }

    public void Damage(int damageValue)
    {
        currentHealth -= damageValue;

        if (currentHealth <= 0)
        {
            if (gameObject.tag != "Player")
            {
                if (anim)
                {
                    anim.SetBool("Dead", true);
                }
                UIScript.updateScore(scoreValue);
                Destroy(GetComponent<EnemyNavMovement>());
                Destroy(GetComponent<UnityEngine.AI.NavMeshAgent>());
                Destroy(GetComponent<CharacterController>());
                Destroy(GetComponentInChildren<EnemyAttack>());

                //GameManager.amountKilled++;
                //Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
