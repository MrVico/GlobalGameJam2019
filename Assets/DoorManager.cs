using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (player.GetComponent<PlayerStatus>().hasKey)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Open");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
