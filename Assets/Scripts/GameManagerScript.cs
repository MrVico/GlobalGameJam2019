﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject startPosition;
    [SerializeField] GameObject finishPosition;
    [SerializeField] Transform player;
    [SerializeField] GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        activateMusicScene();
        startPosition = GameObject.FindGameObjectWithTag("StartPosition");
        finishPosition = GameObject.FindGameObjectWithTag("FinishPosition");
        player.position = startPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(finishPosition != null && finishPosition.GetComponent<FinishScript>().collideWithPlayer)
        {
            spawnPlayer();
            finishPosition.GetComponent<FinishScript>().inverseCollision();
        }        
    }

    public void spawnPlayer()
    {
        player.position = startPosition.transform.position;
    }

    public void defeat()
    {
        loseScreen.SetActive(true);
    }

    public void replay()
    {
        loseScreen.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void activateMusicScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Menu": AkSoundEngine.PostEvent("Play_MusicIntroHouse", gameObject); break;
            case "Niveau1": AkSoundEngine.PostEvent("Play_Music1", gameObject); break;
            case "Lvl2": AkSoundEngine.PostEvent("Play_Music2", gameObject); break;
            //case "Desk": AkSoundEngine.PostEvent("Play_MusicIntroHouse", gameObject); break;
            case "Ending": AkSoundEngine.PostEvent("Play_MusicIntroHouse", gameObject); break;
        }
    }

    public void desactivateMusicScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Menu": AkSoundEngine.PostEvent("Stop_MusicIntroHouse", gameObject); break;
            case "Niveau1": AkSoundEngine.PostEvent("Stop_Music1", gameObject); break;
            case "Lvl2": AkSoundEngine.PostEvent("Stop_Music2", gameObject); break;
            //case "Desk": AkSoundEngine.PostEvent("Stop_MusicIntroHouse", gameObject); break;
            case "Ending": AkSoundEngine.PostEvent("Stop_MusicIntroHouse", gameObject); break;
        }
    }

}
