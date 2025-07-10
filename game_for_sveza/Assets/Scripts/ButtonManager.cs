using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject buildingManagerObject;
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject dataSaverObject;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private messageManager message;
    protected DataSaver dataSaver;
    protected BuildingManager buildingManager;
    protected Building[] buildings;
    protected Button[] buttons;
    protected BuildingButton[] buildingButtons;

    void Start()
    {
        dataSaver = dataSaverObject.GetComponent<DataSaver>();
        buildingManager = buildingManagerObject.GetComponent<BuildingManager>();
        buildings = buildingManager.GetBuildings();

        CreateButtons();

        buttons = contentParent.GetComponentsInChildren<Button>();
        buildingButtons = contentParent.GetComponentsInChildren<BuildingButton>();
    }
    void Update()
    {
        CheckButtons();
    }
    private void CreateButtons()
    {
        bool status = true;
        Debug.Log("CB BL: " + buildings.Length);
        for (int i = 0; i < buildings.Length; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, contentParent);

            BuildingButton buildingBtn = newButton.GetComponent<BuildingButton>();
            Button btnComponent = newButton.GetComponent<Button>();
            Building building = buildingManager.buildings[i];
            buildingBtn.titleText.text = building.GetName();
            if (status)
            {
                btnComponent.interactable = true;
                if (building.isOpened)
                {
                    buildingBtn.xpText.color = Color.black;
                    buildingBtn.xpText.text = "Узнать";
                }
                else
                {
                    buildingBtn.xpText.text = building.price.ToString();
                    if (building.price <= dataSaver.woodXP)
                    {
                        buildingBtn.xpText.color = Color.green;
                    }
                    else
                    {
                        buildingBtn.xpText.color = Color.red;
                    }
                    status = false;
                }
            }
            else
            {
                btnComponent.interactable = false;
                buildingBtn.xpText.text = building.price.ToString();
                buildingBtn.xpText.color = Color.red;
            }
            int buttonIndex = i;
            btnComponent.onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }

    private void OnButtonClick(int buttonIndex)
    {
        if (buildings[buttonIndex].isOpened)
        {
            message.makeMessage(buttonIndex);
        }
        else
        {
            buildings[buttonIndex].ChangeStatus();
        }
    }

    private void CheckButtons()
    {
        for (int i = 0; i < buildings.Length; i++)
        {
            Button btnComponent = buttons[i];

            BuildingButton buildingBtn = buildingButtons[i];
            Building building = buildingManager.buildings[i];

            // buildingBtn.titleText = "Имя"
            if (!(buildingBtn.xpText.text == ""))
            {
                if (building.isOpened)
                {
                    buildingBtn.xpText.color = Color.black;
                    buildingBtn.xpText.text = "Узнать";
                }
                else
                {
                    btnComponent.interactable = true;
                    if (building.price <= dataSaver.woodXP)
                    {
                        buildingBtn.xpText.color = Color.green;
                    }
                    else
                    {
                        buildingBtn.xpText.color = Color.red;
                    }
                    break;
                }
            }
        }
    }
}
