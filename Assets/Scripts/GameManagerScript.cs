using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject startPosition;
    public GameObject finishPosition;
    public Transform player;
    public GameObject loseScreen;

    public GameObject pv2;
    public GameObject pv3;

    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = GameObject.FindGameObjectWithTag("StartPosition");
        finishPosition = GameObject.FindGameObjectWithTag("FinishPosition");
        player.position = startPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(finishPosition.GetComponent<FinishScript>().collideWithPlayer)
        {
            spawnPlayer();
            finishPosition.GetComponent<FinishScript>().inverseCollision();
        }

        text.GetComponent<Text>().text = "x " + player.gameObject.GetComponent<PlayerStatus>().life;
    }

    public void spawnPlayer()
    {
        player.gameObject.GetComponent<PlayerStatus>().health = 3;
        player.gameObject.GetComponent<PlayerStatus>().life--;
        pv3.GetComponent<Image>().enabled = true;
        pv2.GetComponent<Image>().enabled = true;
        player.position = startPosition.transform.position;
    }

    public void defeat()
    {
        loseScreen.SetActive(true);
    }

    public void replay()
    {
        loseScreen.SetActive(false);
        player.gameObject.GetComponent<PlayerStatus>().life = 3;
        spawnPlayer();
    }

    public void loseHealth()
    {
        int health = player.gameObject.GetComponent<PlayerStatus>().health;
        if (health == 2)
        {
            pv3.GetComponent<Image>().enabled = false;
        }
        else if(health == 1)
        {
            pv3.GetComponent<Image>().enabled = false;
            pv2.GetComponent<Image>().enabled = false;
        }
    }

    public void gainHealth()
    {
        int health = player.gameObject.GetComponent<PlayerStatus>().health;
        if (health == 3)
        {
            pv3.GetComponent<Image>().enabled = true;
        }
        else if (health == 2)
        {
            pv2.GetComponent<Image>().enabled = true;
        }
    }
}
