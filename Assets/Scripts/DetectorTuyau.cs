using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorTuyau : MonoBehaviour
{
    public Sprite goodTube;
    public GameObject tuyau;
    public GameObject flaque;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MouvableElement")
        {
            Destroy(collision.gameObject);
            tuyau.GetComponent<SpriteRenderer>().sprite = goodTube;
            flaque.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
            tuyau.GetComponent<BoxCollider2D>().enabled = false;
            flaque.GetComponent<MeshCollider>().enabled = false;
        }

        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
