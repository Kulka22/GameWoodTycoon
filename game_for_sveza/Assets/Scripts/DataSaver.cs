using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class DataSaver : MonoBehaviour
{
    public int woodXP;
    public int countOfActiveBuildings;
    public static DataSaver Instance { get; private set; }

    private void Awake()
    {
        LoadData();
    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)        // уходит в фон
            SaveData();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)    // теряет фокус (например, пришёл звонок)
            SaveData();
    }

    void SaveData()
    {
        if (countOfActiveBuildings > 9)
            countOfActiveBuildings = 9;
        PlayerPrefs.SetInt("WoodXP", woodXP);
        PlayerPrefs.SetInt("Count", countOfActiveBuildings);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        woodXP = PlayerPrefs.GetInt("WoodXP", 0);
        countOfActiveBuildings = PlayerPrefs.GetInt("Count", 0);
        //Debug.Log("Сохры: " + woodXP);
        //woodXP = 0;
        //countOfActiveBuildings = 0;
        Debug.Log("Кол-во зданий уже открытых: " + countOfActiveBuildings);
    }
}
