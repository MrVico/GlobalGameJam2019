using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialZone : MonoBehaviour
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
        if (collision.tag.Equals("PlayerCharacter"))
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerCharacter"))
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
