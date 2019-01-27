using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private GameObject thing;
    private float heightModifier = 0f;

    // Start is called before the first frame update
    void Start()
    {
        thing = transform.Find("Thing").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(Time.deltaTime, Time.deltaTime*heightModifier));
        
        if (transform.position.y > 5f)
            Destroy(gameObject);
    }

    private void Hit() {
        if(thing != null) {
            // Add the script containing the rigidbody
            thing.AddComponent<Box>();
            thing.transform.parent = null;
            thing = null;
            // The bird flies away
            heightModifier = 1f;
        }
    }

    // Called when the thing/box is destroyed by a bullet
    private void FlyAway() {
        heightModifier = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Finish"))
        {
            Destroy(gameObject);
        }
    }

    /*
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag.Equals("Finish"))
    {
        Destroy(gameObject);
    }
}*/

}
