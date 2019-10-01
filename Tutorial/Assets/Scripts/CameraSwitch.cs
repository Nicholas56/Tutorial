using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (camera2 != null && camera1 != null)
        {
            Debug.DrawRay(transform.position, (transform.position + (new Vector3(10, 0, 0))), Color.red);
            if (Physics.Raycast(transform.position, transform.right, 2))
            {
                camera1.SetActive(false);
                camera2.SetActive(true);
            }
            else
            {
                camera2.SetActive(false);
                camera1.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
