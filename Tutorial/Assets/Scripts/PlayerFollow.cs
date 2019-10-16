using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{   
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.SetParent(player);
       // StartCoroutine("follow");
    }

    /*private void LateUpdate()
    {
        Vector3 direction = (player.transform.position - transform.position);
        direction = new Vector3(direction.x, 0, direction.z);
        transform.position += direction;
        
    }
    IEnumerator follow()
    {
        yield return new WaitForSeconds(1.0f);
        Vector3 direction = (player.transform.position - transform.position).normalized;
        direction = new Vector3(direction.x, 0, direction.z);
        transform.position += direction;
        StartCoroutine("follow");
    }*/
}
