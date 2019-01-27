using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseLevel : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().desactivateMusicScene();
            loseScreen.SetActive(true);

        }
        //Debug.Log(collision.collider.tag);
    }
}
