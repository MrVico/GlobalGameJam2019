using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleElement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject);

        }
    }
}
