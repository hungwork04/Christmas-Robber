using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndGameUI : MonoBehaviour
{
    public Button homebtn;
    public Button storebtn;
    public Button playagainbtn;
    public InGameFunction InGameFunction;
    public clawMovement clawMovement;
    private void Awake()
    {
        InGameFunction =FindObjectOfType<InGameFunction>();
        if (clawMovement == null)
            clawMovement = FindObjectOfType<clawMovement>();
    }
    private void Start()
    {
        homebtn.onClick.AddListener(loadHome);
        storebtn.onClick.AddListener(InGameFunction.turnOnStore);
        playagainbtn.onClick.AddListener(loadPlayScene);
    }
    public void loadHome()
    {
        SceneManager.LoadScene(0);
    }
    public void loadPlayScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    private void OnDisable()
    {
        InGameFunction.runOutOfTime = false;
        Time.timeScale = 1f;

    }
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
}
