﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] GameManagerScript gm;
    [SerializeField] int maxHP = 3;
    [SerializeField] bool invincible = false;
    public bool bananaMode;
    [SerializeField] Image hp1;
    [SerializeField] Image hp2;
    [SerializeField] Image hp3;
    [SerializeField] Text lifeTxt;

    public int lives;
    private int hp;
    private int iterInvincibility = 0;

    public bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        hp = maxHP;
        lifeTxt.text = "x " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTxt.text = "x " + lives;
        if(lives == 0)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" && !invincible)
        {

            if (hp > 1)
            {
                StartCoroutine(spriteInvincible());
            }
            loseHP();


        }
        if (collision.collider.name == "Secret")
        {
            Destroy(collision.gameObject);
        }

        if (collision.collider.tag.Equals("Stairs"))
        {
            Destroy(collision.gameObject);
        }
    }

    public int getHP()
    {
        return hp;
    }

    private void loseHP()
    {
        hp--;
        if (hp == 2)
        {
            hp3.enabled = false;
        }
        else if (hp == 1)
        {
            hp2.enabled = false;
        }
        else if (hp == 0)
        {
            hp1.enabled = false;
            lives--;
            gm.spawnPlayer();
            lifeTxt.text = "x " + lives;
            // Player lost a life, reset his hp
            if (lives > 0)
            {
                StopAllCoroutines();
                resetHP();
            }
        }
    }

    private void gainHP()
    {
        if (hp < 3)
        {
            hp++;
            if (hp == 3)
            {
                hp3.enabled = true;
            }
            else if (hp == 2)
            {
                hp2.enabled = true;
            }
        }
    }

    private void resetHP()
    {
        hp = maxHP;
        hp1.enabled = true;
        hp2.enabled = true;
        hp3.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Water") || collider.tag.Equals("Sand"))
        {
            lives--;
            if (lives > 0)
                gm.spawnPlayer();
            else
                GameOver();
        }

        if (collider.tag.Equals("Key"))
        {
            Destroy(collider.gameObject);
        }
    }

    public void GameOver()
    {
        gm.defeat();
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
