using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject mother;
    [SerializeField] GameObject door;

    private bool motherWaits = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > -5.9f) {
            player.transform.Translate(-Time.deltaTime * 3f, 0f, 0f);
            player.GetComponent<Animator>().SetTrigger("Move");
        }
        else {
            player.GetComponent<Animator>().SetTrigger("Happy Idle");
        }

        if (!motherWaits && mother.transform.position.x > -3.5f) {
            mother.transform.Translate(-Time.deltaTime * 3f, 0f, 0f);
            mother.GetComponent<Animator>().SetTrigger("Move");
        }
        else {
            mother.GetComponent<Animator>().ResetTrigger("Move");
            mother.GetComponent<Animator>().SetTrigger("Idle");
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject == door) {
            StartCoroutine(openAndWait());
        }
    }

    IEnumerator openAndWait() {
        door.GetComponent<Animator>().SetTrigger("Open");
        motherWaits = true;
        yield return new WaitForSeconds(1f);
        motherWaits = false;
        yield return new WaitForSeconds(0.5f);
        door.GetComponent<Animator>().SetTrigger("Close");
    }
}
