using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    
    public GameObject _pauseMenu;

    public void PauseToggle()
    {
        if (Time.timeScale == 1) 
        { 
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Unpause()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
