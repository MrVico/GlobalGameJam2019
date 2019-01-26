using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    public GameObject stares;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag.Equals("Player"))
        {
            stares.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
