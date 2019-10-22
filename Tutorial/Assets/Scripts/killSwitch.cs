using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killSwitch : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.StartListening("zombicide",kill);
    }

    private void OnDisable()
    {
        EventManager.StopListening("zombicide",kill);
    }

    void kill()
    {
        Destroy(gameObject);
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
