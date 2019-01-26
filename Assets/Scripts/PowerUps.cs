using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject player;

    public GameManagerScript gm;

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
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        if (gameObject.tag == "SpeedUp")
        {
            player.GetComponent<Movement>().runSpeed *= 2.2f;
            StartCoroutine(powerUpTimer());
        }

        else if(gameObject.tag == "HealthUp")
        {
            gainHealth();
        }
    }

    public void gainHealth()
    {
        GameObject.Find("Player").GetComponent<PlayerStatus>().health++;
        gm.gainHealth();
    }

    IEnumerator powerUpTimer()
    {
        yield return new WaitForSeconds(5f);
        player.GetComponent<Movement>().runSpeed /= 2.2f;
        Destroy(gameObject);
    }
}
