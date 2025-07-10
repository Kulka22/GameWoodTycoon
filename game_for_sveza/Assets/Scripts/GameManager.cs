using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private DataSaver dataSaver;
    public int woodXP = 0;
    public TextMeshProUGUI woodXPText; // UI-элемент для отображения опыта
    public BuildingManager buildingManager;

    private void Awake()
    {
        
    }

    private void Start()
    {
        dataSaver = FindObjectOfType<DataSaver>();
        woodXP = dataSaver.woodXP;
        if (Instance == null) Instance = this;
        //Debug.Log("START XP: " + dataSaver.woodXP);
        UpdateUI();
    }

    public void AddWoodXP(int amount)
    {
        woodXP += amount;
        UpdateUI();
        //Debug.Log("ТЕКУЩИЙ XP: " +  woodXP);
        dataSaver.woodXP = woodXP;
    }

    void UpdateUI()
    {
        woodXPText.text = woodXP.ToString();
    }
}
