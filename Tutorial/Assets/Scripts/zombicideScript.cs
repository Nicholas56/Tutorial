using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombicideScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        print("bang");
        EventManager.TriggerEvent("zombicide");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
