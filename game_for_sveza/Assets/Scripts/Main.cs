using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int experience;
    public Text experienceText;

    private void Start() // инициализация игры
    {
        experience = PlayerPrefs.GetInt("experience");

    }

    public void ButtonClick()
    {
        experience++;
        PlayerPrefs.SetInt("experience",  experience);
        Debug.Log(experience);
    }

    void Update() // функция, вызываемая каждый кадр
    {
        experienceText.text = experience.ToString();
    }

}
