using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StareManager : MonoBehaviour
{
    [SerializeField] List<GameObject> stares;

    public GameObject previousStare;
    public GameObject nextStare;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject stare in stares){
            if (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(stare.transform.position.x, stare.transform.position.y)) < 2.5f)
                stare.SetActive(true);
            else
                stare.SetActive(false);
        }
        /*
        if(nextStare != null)
        {
            if (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(nextStare.transform.position.x, nextStare.transform.position.y)) < 2.5)
            {
                nextStare.SetActive(true);
            }
            else
            {
                nextStare.SetActive(false);
            }
        }

        if (previousStare != null)
        {
            if (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(previousStare.transform.position.x, previousStare.transform.position.y)) < 2.5)
            {
                previousStare.SetActive(true);
            }
            else
            {
                previousStare.SetActive(false);
            }
        }
        */
    }
}
