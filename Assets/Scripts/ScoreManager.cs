
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    /*    [SerializeField] private TextMeshProUGUI scoreTextPro; // Kéo thả Text UI vào đây*/

    [SerializeField] public static int elf_count = 0;
    [SerializeField] public static int food_count = 0;
    [SerializeField] public static int gift_count = 0;
    [SerializeField] public static int toy_count = 0;

    public TextMeshProUGUI elf;
    public TextMeshProUGUI food;
    public TextMeshProUGUI gift;
    public TextMeshProUGUI toy;


    public StoreFunction storeFunction;
    private void Awake()
    {
        storeFunction = FindObjectOfType<StoreFunction>();
    }

    private void Update()
    {
        elf.text=elf_count.ToString();
        food.text=food_count.ToString();
        gift.text=gift_count.ToString();
        toy.text=toy_count.ToString();
    }
    public void upDateItemSOMaxQuantity()
    {
        if(storeFunction.itemTrades.Count<=0) return;
        for (int i = 0; i < storeFunction.itemTrades.Count; i++)
        {
            if (storeFunction.itemTrades[i].item.name == "elf")
            {
                storeFunction.itemTrades[i].item.MaxQuan = elf_count;
            }
            if (storeFunction.itemTrades[i].item.name == "gift")
            {
                storeFunction.itemTrades[i].item.MaxQuan = gift_count;
            }
            if (storeFunction.itemTrades[i].item.name == "toy")
            {
                storeFunction.itemTrades[i].item.MaxQuan = toy_count;
            }
            if (storeFunction.itemTrades[i].item.name == "food")
            {
                storeFunction.itemTrades[i].item.MaxQuan = food_count;
            }
        }
    }
    public void upDateALLcount()
    {
        for (int i = 0; i < storeFunction.itemTrades.Count; i++)
        {
            if (storeFunction.itemTrades[i].item.name == "elf")
            {
                elf_count = storeFunction.itemTrades[i].item.MaxQuan ;
            }
            if (storeFunction.itemTrades[i].item.name == "gift")
            {
                gift_count = storeFunction.itemTrades[i].item.MaxQuan;
            }
            if (storeFunction.itemTrades[i].item.name == "toy")
            {
                toy_count = storeFunction.itemTrades[i].item.MaxQuan;
            }
            if (storeFunction.itemTrades[i].item.name == "food")
            {
                food_count = storeFunction.itemTrades[i].item.MaxQuan;
            }
        }
    }
}