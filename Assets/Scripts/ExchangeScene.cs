using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeScene : MonoBehaviour
{
    public Button turnoffBtn;
    public Button Exchangebtn;
    public StoreFunction storeFunction;

    public TextMeshProUGUI yourPoint;
    public TextMeshProUGUI codeText;
    public Button copybtn;
    private List<string> codeList = new List<string>();

    private void Awake()
    {
        if (storeFunction != null) return;
        storeFunction = FindObjectOfType<StoreFunction>();
    }

    
    public void AddCode(string code)
    {
        codeList.Add(code);
    }
    public string GetRandomCode()
    {
        if (codeList.Count == 0)
        {
            Debug.LogWarning("List is empty!");
            return null; // Hoặc trả về giá trị mặc định
        }

        int randomIndex = Random.Range(0, codeList.Count); // Chọn một chỉ số ngẫu nhiên
        return codeList[randomIndex];
    }

    private void Start()
    {
        turnoffBtn.onClick.AddListener(turnoff);
        Exchangebtn.onClick.AddListener(exchange);
        copybtn.onClick.AddListener(CopyCodeToClipboard);

        AddCode("sPlg0EoiYe");
        AddCode("MYLo9uurVN");
        AddCode("Nrife3lucq");

    }
    private void Update()
    {
        yourPoint.text = StoreFunction.totalScore.ToString() + "pts";
    }
    public void turnoff()
    {
        this.gameObject.SetActive(false);
    }
    public void exchange()
    {
        if (StoreFunction.totalScore < 2000) return;
        StoreFunction.totalScore -= 2000;
        storeFunction.updateScore();
        codeText.text = GetRandomCode();
    }
    public void CopyCodeToClipboard()
    {
        
        if (!string.IsNullOrEmpty(codeText.text))
        {
            GUIUtility.systemCopyBuffer = codeText.text; // Copy vào clipboard
            Debug.Log("code: "+ GUIUtility.systemCopyBuffer);
        }
    }
}
