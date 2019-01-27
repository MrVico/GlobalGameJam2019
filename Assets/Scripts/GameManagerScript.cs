using System.Collections;
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

}
