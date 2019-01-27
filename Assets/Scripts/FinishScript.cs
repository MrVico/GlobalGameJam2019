﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public bool collideWithPlayer;
    public GameObject player;
    public string nextSceneName;

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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            goToNextScene();
        }
        //Debug.Log(collision.collider.tag);
    }

    public void inverseCollision()
    {
        collideWithPlayer = !collideWithPlayer;
    }

    public void goToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
