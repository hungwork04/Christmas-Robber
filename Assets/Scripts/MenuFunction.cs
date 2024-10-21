using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFunction : MonoBehaviour
{
    public Button playbtn;
    public Button storebtnmenu;
    public Button howbtn;

    public List<GameObject> storeUI;
    public GameObject StoreUI;
    public GameObject store;
    private void Awake()
    {
        playbtn = transform.Find("playbtn").GetComponent<Button>();
        storebtnmenu =transform.Find("storebtn").GetComponent <Button>();
        howbtn=transform.Find("howbtn").GetComponent<Button>();
    }
    private void Start()
    {
        playbtn.onClick.AddListener(playGame);
        storebtnmenu.onClick.AddListener(storeGame);
    }
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
    public void storeGame()
    {
        if (storeUI.Count >= 1)
        {
            storeUI[0].SetActive(true);
            return;
        }
        else if (storeUI.Count == 0)
        {
            GameObject newstore = Instantiate(store, StoreUI.transform);
            storeUI.Add(newstore);
        }
    }
}
