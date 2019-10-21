using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    AudioSource audioSrc;
    GameObject[] enemies;
    float[] distances;
    [SerializeField] AudioClip music1;
    [SerializeField] float musicDistance = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = music1;
        audioSrc.Play();

        enemies = GameObject.FindGameObjectsWithTag("Vampire");
        distances = new float[enemies.Length];
        //StartCoroutine("checkEnemies");
    }

    public void StopSound()
    {
        audioSrc.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            distances[i] = Vector3.Distance(transform.position, enemies[i].transform.position);
        }
        if (Mathf.Min(distances) < musicDistance)
        {
            audioSrc.volume = 1.0f - (Mathf.Min(distances) / musicDistance);

        }
    }
}
