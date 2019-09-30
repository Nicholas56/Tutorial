using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform playerModel;
    CharacterController controller;
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float gravity = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerModel = playerGameObject.transform;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerModel != null)
        {
            Vector3 direction = playerModel.position - transform.position;

            Vector3 velocity = direction.normalized * moveSpeed;
            velocity.y = -gravity;
            if (direction.magnitude > 2)
            {
                controller.Move(velocity * Time.deltaTime); ;
            }
        }
    }
}
