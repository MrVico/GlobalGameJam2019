using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : MonoBehaviour
{

    GameObject player;
    GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        ground = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y > player.transform.position.y)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
