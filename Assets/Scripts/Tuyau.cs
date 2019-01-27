using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuyau : MonoBehaviour
{
    public Animator animColli;
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
        if(collision.tag == "MovableElement")
        {
            collision.GetComponent<BoxCollider2D>().enabled = false;
            animColli.enabled = true;
            animColli.SetBool("TriggerTuyau", true);
        }
    }
}
