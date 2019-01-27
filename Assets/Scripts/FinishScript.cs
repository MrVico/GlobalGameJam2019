using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public bool collideWithPlayer;
    public GameObject player;
    public string nextSceneName;

    [SerializeField] GameObject fadeQuad;

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
<<<<<<< HEAD
        SceneManager.LoadScene(nextSceneName);
=======
        StartCoroutine(fadeOut());
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
        SceneManager.LoadScene("Niveau1");
>>>>>>> 648c7bea406d393428f0b7693e3a1b63443b890b
    }
}
