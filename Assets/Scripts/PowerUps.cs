using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    /*
    void Update()
    {
        if (gameObject.GetComponent<BoxCollider2D>().g
        {
            activatePowerUp();
            Destroy(gameObject);
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.collider.name == "Player")
        {
            activatePowerUp();  
        }
        
    }

    void activatePowerUp()
    {
        player.GetComponent<Movement>().runSpeed *= 2.5f;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(powerUpTimer());
        

    }

    IEnumerator powerUpTimer()
    {
        yield return new WaitForSeconds(5f);
        player.GetComponent<Movement>().runSpeed /= 2.5f;
        Destroy(gameObject);
    }
}
