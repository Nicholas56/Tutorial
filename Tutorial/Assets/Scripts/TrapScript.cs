using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject enemy;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"&&enemy!=null)
        {
            enemy.GetComponent<EnemyNavMovement>().isActivated = true;
        }
    }

}
