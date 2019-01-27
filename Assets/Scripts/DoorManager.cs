using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public GameObject player;

    private Animator animator;

    private float timer = 0f;
    private bool doorOpening = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpening) {
            timer += Time.deltaTime;
            if(timer > 1f)
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && player.GetComponent<PlayerStatus>().hasKey)
        {
            animator.SetTrigger("Open");
            doorOpening = true;
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //StartCoroutine(openInABit());
        }
    }
    
    // Doesn't work 'cause it also delays the OPEN animation for some reason
    /*
    IEnumerator openInABit() {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    */
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Mother") && SceneManager.GetActiveScene().name.Equals("Menu")) {
            animator.SetTrigger("Open");
            animator.SetTrigger("Close");
        }
    }
}
