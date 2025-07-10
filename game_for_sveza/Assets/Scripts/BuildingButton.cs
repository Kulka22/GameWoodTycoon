using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI xpText;
    public Button button;

    public void SetData(string title, int xpProgress)
    {
        titleText.text = title;
        xpText.text = xpProgress.ToString();
    }
}
