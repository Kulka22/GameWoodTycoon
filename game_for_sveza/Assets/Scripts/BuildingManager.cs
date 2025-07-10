using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildingObjects;
    public Building[] buildings;
    private int countOfActiveBuildings;

    private void Awake()
    {
        countOfActiveBuildings = FindObjectOfType<DataSaver>().countOfActiveBuildings;
        //Debug.Log("КОЛ-ВО ЗДАНИЙ: " + countOfActiveBuildings);
        buildings = new Building[buildingObjects.Length];
        Debug.Log("BuildMan, COUNT OF BO: " + buildingObjects.Length);

        for (int i = 0; i < buildingObjects.Length; i++)
        {
            buildings[i] = buildingObjects[i].GetComponent<Building>();
            if (i < countOfActiveBuildings)
            {
                buildings[i].ChangeStatus(true);
            }
            Debug.Log($"Здание {i + 1} активировано");
        }
        Debug.Log("BuildMan, COUNT OF LOADED BUILDINGS: " + buildings.Length);
        //Debug.Log(buildings[4].price);
    }

    public Building[] GetBuildings()
    {
        return buildings;
    }
}
