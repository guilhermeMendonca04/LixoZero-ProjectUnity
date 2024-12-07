using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuEscolha : MonoBehaviour
{   
    public GameObject mainScreen;
    public GameObject mainTutorial;

    void Start(){
        mainScreen.SetActive(true);
        mainTutorial.SetActive(false);
    }
    public void Sair(){
        Application.Quit();
    }

    public void Jogar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HideScreen(){
        mainScreen.SetActive(false);
        mainTutorial.SetActive(true);
    }

    public void ShowScreen(){
        mainScreen.SetActive(true);
        mainTutorial.SetActive(false);
    }
}
