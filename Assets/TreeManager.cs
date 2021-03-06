﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public bool isActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActivated)
        {
            gameObject.GetComponent<Animator>().ResetTrigger("On");
            gameObject.GetComponent<Animator>().SetTrigger("Off");
        }
        else
        {
            gameObject.GetComponent<Animator>().SetTrigger("On");
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            isActivated = true;
        }
    }

}
