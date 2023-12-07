using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string level = "1FirstMove";
    public GameObject[] selectedLevel;

        // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++){
            selectedLevel[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++){
            selectedLevel[i].SetActive(true);
        }        
    }

    public void OpenLevel_1()
    {
        level = "1FirstMove";
    }
    public void OpenLevel_2()
    {
        level = "2SecondMove";
    }
    public void OpenLevel_3()
    {
        level = "3Competition";
    }
    public void OpenLevel_4()
    {
        level = "4FirstLine";
    }
    public void OpenLevel_5()
    {
        level = "5SecondLine";
    }
    public void OpenLevel_6()
    {
        level = "6Competiton";
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene(level);

    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
