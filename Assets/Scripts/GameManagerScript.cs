using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject startPosition;
    public GameObject finishPosition;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = GameObject.FindGameObjectWithTag("StartPosition");
        finishPosition = GameObject.FindGameObjectWithTag("FinishPosition");
        spawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(finishPosition.GetComponent<FinishScript>().collideWithPlayer)
        {
            spawnPlayer();
            finishPosition.GetComponent<FinishScript>().inverseCollision();
        }
    }

    private void spawnPlayer()
    {
        player.position = startPosition.transform.position;
    }
}
