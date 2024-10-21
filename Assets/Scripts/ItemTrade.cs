using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTrade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField]private TextMeshProUGUI quantityText;
   
    public Image itemImg;
    public int quantity = 0;
    public ItemSO item;
    
    public StoreFunction store;

    public Button up;
    public Button down;

    public Transform buttontrade;

    public ScoreManager scoreManager;

    private void Awake()
    {
        store =FindObjectOfType<StoreFunction>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void Start()
    {

        quantityText.text= quantity.ToString();
        nameText.text = item.name;
        itemImg.sprite = item.sprite;
        buttontrade = this.transform.Find("Trade");
        up.onClick.AddListener(IncreaseQuantity);
        down.onClick.AddListener(DecreaseQuantity);
        buttontrade.GetComponent<Button>().onClick.AddListener(Trade);
    }

    public void Trade()
    {

        if (quantity > this.item.MaxQuan) return;
        this.item.MaxQuan-=quantity;
        if (this.item.MaxQuan <= 0)
        {
            this.item.MaxQuan = 0;
        }
        scoreManager.upDateALLcount();
        StoreFunction.totalScore += quantity * this.item.value;
        store.updateScore();
    }
    private void IncreaseQuantity()
    {
        
        quantity++; // Tăng số lượng
        UpdateQuantityText(); // Cập nhật hiển thị
    }

    private void DecreaseQuantity()
    {
        quantity--; // Giảm số lượng
        if (quantity < 0) quantity = 0; // Đảm bảo không có số lượng âm
        UpdateQuantityText(); // Cập nhật hiển thị
    }

    private void UpdateQuantityText()
    {
        quantityText.text = quantity.ToString(); // Cập nhật văn bản hiển thị
    }
    private void OnEnable()
    {
        if (this.enabled == true)
        {
            store.itemTrades.Add(this);
        }
        scoreManager.upDateItemSOMaxQuantity();
    }
}
