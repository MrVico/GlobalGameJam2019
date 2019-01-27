using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScene : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject mother;
    [SerializeField] GameObject key;

    private bool moveMother = false;

    // Start is called before the first frame update
    void Start()
    {
        // Prevent the player from moving
        player.GetComponent<PlayerControls>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveMother) {
            mother.transform.Translate(Time.deltaTime * 3f, 0f, 0f);
            if(mother.transform.position.x > 18f) {
                moveMother = false;
                Destroy(mother);
                StartCoroutine(waitOutIntro());
            }
        }
    }

    IEnumerator waitOutIntro() {
        yield return new WaitForSeconds(1f);
        key.SetActive(true);
        // The player can now move
        player.GetComponent<PlayerControls>().enabled = true;
    }

    private void OnMouseDown() {
        Destroy(GetComponent<BoxCollider2D>());
        moveMother = true;
        mother.GetComponent<Animator>().SetTrigger("Walk");
    }

    
}
