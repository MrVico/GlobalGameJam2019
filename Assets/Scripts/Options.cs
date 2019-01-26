using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    public GameObject optionsWindow;

    public bool isDisplayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            displayOptions();
        }
    }

    public void displayOptions()
    {
        Debug.Log("IsDisplayed: " + isDisplayed);
        if (!isDisplayed)
        {
            Time.timeScale = 0;
            isDisplayed = true;
            optionsWindow.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            isDisplayed = false;
            optionsWindow.SetActive(false);
        }
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
