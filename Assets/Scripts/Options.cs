using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    public GameObject optionsWindow; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            displayOptions();
        }
    }

    public void displayOptions()
    {
        optionsWindow.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("GGJ2019 - Copie");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ContinueGame()
    {
        optionsWindow.SetActive(false);
    }
}
