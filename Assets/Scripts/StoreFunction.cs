using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreFunction : MonoBehaviour
{
    public static int totalScore = 0;

    public GameObject StoreUIPre;
    public List<ItemTrade> itemTrades = new List<ItemTrade>();
    public TextMeshProUGUI score;

    public GameObject exchangeScene;

    public Button exchangePointbtn;
    public clawMovement clawMovement;
    public void Awake()
    {
        clawMovement =FindObjectOfType<clawMovement>();
    }
    private void Start()
    {
        exchangeScene.SetActive(false);
        if(exchangePointbtn!=null)  
        exchangePointbtn.onClick.AddListener(exChangePointScene);
    }
    public void exChangePointScene()
    {
        exchangeScene.gameObject.SetActive(true);
    }
    public void turnOff()
    {
        StoreUIPre.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private void OnEnable()
    {
        updateScore();
    }
    public void updateScore()
    {
        score.text="Point:"+totalScore.ToString();
    }
    private void OnDisable()
    {
        if (clawMovement != null)
        {
            clawMovement.gameObject.SetActive(true);
            if (InGameFunction.runOutOfTime==true)
            {
                clawMovement.gameObject.SetActive(false);
            }
        }

    }
}
