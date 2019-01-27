using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneManager : MonoBehaviour
{

    public GameObject dog;

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
        print(collision);
        if (collision.collider.tag.Equals("Dog"))
        {
            Destroy(gameObject);
        }
    }

    public void OnColliderEnter2D(Collision2D collision)
    {
       
    }

    public void OnDestroy()
    {
        dog.GetComponent<Animator>().SetTrigger("Bone");
        dog.GetComponent<DogManager>().hasBone = true;
    }
}
