using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool hitOnPlayer = false;
    private Rigidbody2D rigidbody;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody2D>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        // Remove/Change this if we want to be able to move the boxes!
        rigidbody.mass = 100;
        rigidbody.AddTorque(500);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (transform.position.y > player.transform.position.y && !hitOnPlayer && collider.tag.Equals("Player")) {
            hitOnPlayer = true;
            player.SendMessage("loseHP");
            if (player.GetComponent<PlayerStatus>().getHP() <= 0)
                player.SendMessage("resetHP");
        }
    }
}
