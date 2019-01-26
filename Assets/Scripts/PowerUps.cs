using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject player;

    public GameManagerScript gm;

    private float speedMultiplier = 2f;

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
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        if(collider.tag.Equals("Player"))
        {
            activatePowerUp();  
        }
    }

    void activatePowerUp()
    {
        if (gameObject.tag == "SpeedUp")
        {
            player.GetComponent<PlayerControls>().moveSpeed *= speedMultiplier;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(powerUpTimer());
        }

        else if(gameObject.tag == "HealthUp")
        {
            if (player.gameObject.GetComponent<PlayerStatus>().health < 3)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gainHealth();
            }   
        }

        else if(gameObject.tag == "Bonus")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gainBonus();
        }
    }

    public void gainHealth()
    {
        GameObject.Find("Player").GetComponent<PlayerStatus>().health++;
        gm.gainHealth();
    }

    public void gainBonus()
    {

    }

    IEnumerator powerUpTimer()
    {
        yield return new WaitForSeconds(5f);
        player.GetComponent<PlayerControls>().moveSpeed /= speedMultiplier;
        Destroy(gameObject);
    }
}
