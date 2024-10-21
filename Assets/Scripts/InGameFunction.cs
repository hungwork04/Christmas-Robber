using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameFunction : MonoBehaviour
{
    public List<GameObject> storeUI;
    public GameObject StoreUI;
    public GameObject store;
    public EndGameUI endGameUI;
    public float countdownTime = 30f;
    [SerializeField] protected TextMeshProUGUI countdownText;

    public static bool runOutOfTime=false;

    private void Start()
    {
        StartCoroutine(CountdownRoutine());
        endGameUI.gameObject.SetActive(false);
    }
    public void loadHomeScene()
    {
        SceneManager.LoadScene(0);
    }
    public void turnOnStore()
    {
        Time.timeScale = 0f;
        if (storeUI.Count >= 1)
        {
            storeUI[0].SetActive(true);
            return;
        }else if (storeUI.Count == 0)
        {
        GameObject newstore= Instantiate(store,StoreUI.transform);
        storeUI.Add(newstore);
        }
    }
    
    IEnumerator CountdownRoutine()
    {
        float currentTime = countdownTime;

        while (currentTime >= 0)
        {
            countdownText.text = currentTime.ToString() + "s";
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        runOutOfTime = true;
        endGameUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

}
