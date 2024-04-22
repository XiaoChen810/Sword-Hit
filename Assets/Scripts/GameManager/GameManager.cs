using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Pawn Pawn1;
    public Pawn Pawn2;

    public bool GameEnd;
    public GameObject MenuPanel;
    public GameObject Win1;
    public GameObject Win2;
    public GameObject Lose1;
    public GameObject Lose2;

    private void Update()
    {
        if(Pawn1.IsDie || Pawn2.IsDie)
        {
            if(Pawn1.IsDie)
            {
                Lose1.SetActive(true);
                Win2.SetActive(true);
            }
            if(Pawn2.IsDie)
            {
                Lose2.SetActive(true);
                Win1.SetActive(true);
            }
            GameEnd = true;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            MenuPanel.SetActive(true);
        }
    }

    public void Menu_Continue()
    {
        MenuPanel.SetActive(false);
    }
    public void Menu_ResetGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    public void Menu_Exit()
    {
        MenuPanel.SetActive(false);
        Application.Quit();
    }


}
