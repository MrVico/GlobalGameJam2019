﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScene : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject mother;
    [SerializeField] GameObject key;
    [SerializeField] GameObject fadeQuad;

    private bool moveMother = false;

    // Start is called before the first frame update
    void Start()
    {
        // Prevent the player from moving
        player.GetComponent<PlayerControls>().enabled = false;

        StartCoroutine(fadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if (moveMother) {
            if(mother.transform.localScale.x < 0) {
                Vector3 motherScale = mother.transform.localScale;
                motherScale.x *= -1;
                mother.transform.localScale = motherScale;
            }
            mother.transform.Translate(Time.deltaTime * 3f, 0f, 0f);
            mother.GetComponent<Animator>().SetTrigger("Move");
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

    IEnumerator fadeIn() {
        Color fadeColor = fadeQuad.GetComponent<MeshRenderer>().material.color;
        fadeColor.a = 1;
        fadeQuad.GetComponent<MeshRenderer>().material.color = fadeColor;
        while (fadeColor.a > 0) {
            fadeColor.a -= Time.deltaTime;
            fadeQuad.GetComponent<MeshRenderer>().material.color = fadeColor;
            yield return null;
        }
    }
}
