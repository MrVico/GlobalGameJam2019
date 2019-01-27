using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkScene : MonoBehaviour
{   
    [SerializeField] GameObject fadeQuad;
    [SerializeField] GameObject hug;

    private bool firstFade = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            StartCoroutine(fadeOut());
        }
    }
    
    IEnumerator fadeOut() {
        Color fadeColor = fadeQuad.GetComponent<MeshRenderer>().material.color;
        fadeColor.a = 0;
        fadeQuad.GetComponent<MeshRenderer>().material.color = fadeColor;
        while (fadeColor.a < 1) {
            fadeColor.a += Time.deltaTime;
            fadeQuad.GetComponent<MeshRenderer>().material.color = fadeColor;
            yield return null;
        }
        yield return null;
        if (firstFade) {
            firstFade = false;
            StartCoroutine(fadeIn());
        }
        else {
            SceneManager.LoadScene("Ending");
        }
    }

    IEnumerator fadeIn() {
        Vector3 camPos = Camera.main.transform.position;
        camPos.x = 31f;
        Camera.main.transform.position = camPos;
        Color fadeColor = fadeQuad.GetComponent<MeshRenderer>().material.color;
        fadeColor.a = 1;
        fadeQuad.GetComponent<MeshRenderer>().material.color = fadeColor;
        hug.SetActive(true);
        while (fadeColor.a > 0) {
            fadeColor.a -= Time.deltaTime;
            fadeQuad.GetComponent<MeshRenderer>().material.color = fadeColor;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(fadeOut());
    }
}
