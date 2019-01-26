using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int life;
    public bool invincible = false;

    int iterInvincibility = 0;

    public GameManagerScript gm;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            Debug.Log("life = 0");
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy" && !invincible)
        {
            life--;
            if(life > 0)
            {
                StartCoroutine(spriteInvincible());
            }  
        }
    }

    public void GameOver()
    {
        gm.spawnPlayer();
    }

    IEnumerator spriteInvincible()
    {
        invincible = true;
        
        while (iterInvincibility < 3)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.3f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.3f);
            iterInvincibility++;
        }
        invincible = false;
        iterInvincibility = 0;
    }
}
