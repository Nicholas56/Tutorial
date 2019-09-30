using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
