using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameManager.instance.CharIndex = selectedCharacter;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
