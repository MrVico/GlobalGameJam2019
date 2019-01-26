using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] GameObject birdPrefab;
    [SerializeField] float spawnRate;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(birdPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnRate) {
            Instantiate(birdPrefab, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
