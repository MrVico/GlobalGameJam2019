using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour
{

    public GameObject tree;

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
        if (collision.collider.tag.Equals("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        tree.GetComponent<TreeManager>().isActivated = false;
        tree.GetComponent<Animator>().SetTrigger("Off");
        foreach(BoxCollider2D collide in tree.GetComponents<BoxCollider2D>())
        {
            collide.enabled = false;
        }
    }
}
