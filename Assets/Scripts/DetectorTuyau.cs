using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorTuyau : MonoBehaviour
{
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
            Animator animColli = collision.GetComponent<Animator>();
            if (animColli != null)
            {
                animColli.SetBool("TriggerAllInTuyau", true);
            }
        }
    }
}
