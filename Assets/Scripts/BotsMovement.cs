using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsMovement : MonoBehaviour
{
    public float minPos;
    public float maxPos;

    public bool inverseMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > maxPos)
        {
            inverseMove = true;
        }
        else if(gameObject.transform.position.x < minPos)
        {
            inverseMove = false;
        }

        MovePlayer();
    }

    void MovePlayer()
    {
        if (!inverseMove)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y);
        }
        else
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y);
        }
    }
}
