using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogManager : MonoBehaviour
{

    public bool hasBone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBone)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<PlayerStatus>().lives--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().spawnPlayer();
        }
    }
}
