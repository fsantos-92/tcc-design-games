using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    public GameObject Buttons;
    public GameObject Panel;

    // Use this for initialization
    void Start()
    {
        Buttons.SetActive(true);
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && Panel.activeInHierarchy == true)
        {
            Panel.SetActive(false);
            Buttons.SetActive(true);
        }
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToTutorial()
    {
        Buttons.SetActive(false);
        Panel.SetActive(true);
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
