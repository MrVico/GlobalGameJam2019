using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public bool collideWithPlayer;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        collideWithPlayer = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            inverseCollision();
        }
        Debug.Log(collision.collider.tag);
    }

    public void inverseCollision()
    {
        collideWithPlayer = !collideWithPlayer;
    }
}
