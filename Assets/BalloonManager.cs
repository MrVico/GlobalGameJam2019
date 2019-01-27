using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonManager : MonoBehaviour
{

    public GameObject bone;

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

    public void OnDestroy()
    {
        bone.GetComponent<Rigidbody2D>().simulated = true;
    }
}
