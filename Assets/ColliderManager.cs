using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{

    public BoxCollider2D topBench;
    public GameObject player;

    float value;

    // Start is called before the first frame update
    void Start()
    {
        value = topBench.bounds.center.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<CircleCollider2D>().bounds.center.y > value)
        {
            topBench.enabled = true;
        }

        else
        {
            topBench.enabled = false;
        }
    }

    
}
