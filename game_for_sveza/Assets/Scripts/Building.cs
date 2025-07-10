using System;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] private string name;
    //[SerializeField] private GameObject dataSaverObject;
    private int woodXPPerSecond = 1;
    private bool isNotCalledCourutine = true;
    public bool isOpened { get; private set; }
    public int price;
    public DataSaver dataSaver;
    public Sprite openedSprite;
    public Sprite lockedSprite;
    private SpriteRenderer spriteRenderer;
    public GameManager gameManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (price == 0 && !isOpened)
        {
            ChangeStatus();
        }
        UpdateVisual();
        //if (isOpened)
        //{
        //    woodXPPerSecond++;
        //    InvokeRepeating("GenerateXP", 1f, 1f);
        //}

    }

    private void Awake()
    {
        gameManager = gameManager.GetComponent<GameManager>();
        //dataSaver = dataSaverObject.GetComponent<DataSaver>();
        //dataSaver = FindObjectOfType<DataSaver>();
    }

    public string GetName()
    {
        return name;
    }
    private void GenerateXP()
    {
        if (isOpened)
        {
            GameManager.Instance.AddWoodXP(woodXPPerSecond);
        }
    }
    private void UpdateVisual()
    {
        if (isOpened && isNotCalledCourutine)
        {
            isNotCalledCourutine = false;
            Debug.Log("Вызвана корутина!");
            InvokeRepeating("GenerateXP", 1f, 1f);
        }

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = isOpened ? openedSprite : lockedSprite;

        if (TryGetComponent<Animator>(out var animator))
        {
            animator.enabled = isOpened;
            animator.SetBool("isActive", isOpened);
        }
    }

    public bool ChangeStatus(bool isLoaded = false)
    {
        if (isLoaded)
        {
            isOpened = true;
            //dataSaver.countOfActiveBuildings++;
            UpdateVisual();
            return true;
        }
        else if (gameManager.woodXP >= price)
        {
            isOpened = true;
            gameManager.woodXP -= price;
            dataSaver.woodXP = (gameManager.woodXP);
            UpdateVisual();
            dataSaver.countOfActiveBuildings++;
            Debug.Log("COAB: " + dataSaver.countOfActiveBuildings);
            SoundManager.PlaySound(SoundType.PURCHASE);
            return true;
        }
        else
        { 
            SoundManager.PlaySound(SoundType.FAIL, 1); 
        }
        return false;
    }
}
