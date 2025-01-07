using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class store_controller : MonoBehaviour
{
    public bag storeBag; // 商店數據
    public GameObject slot_grid; // 用於存放物品槽的 UI 容器
    public GameObject slot_prefab; // 商店物品槽的預製件
    public Text informationText;
    public Text price_Text;
    public Text player_money_Text;
    public Button nextPageButton; // 下一頁按鈕
    public Button prevPageButton; // 上一頁按鈕
    public Button buy_btn;
    public player1 player;
    public bag player_bag;

    private List<GameObject> slots = new List<GameObject>(); // 保存當前頁的物品槽
    private int itemsPerPage = 18; // 每頁顯示的物品數量
    private int currentPage = 0; // 當前頁碼
    private int totalPages = 0; // 總頁數
    private item selectedItem;
    void Start()
    {
        player_money_Text.text=player.money.ToString();
        totalPages = Mathf.CeilToInt((float)storeBag.itemlist.Count / itemsPerPage); // 計算總頁數
        InitializePage();

        // 綁定按鈕事件
        nextPageButton.onClick.AddListener(NextPage);
        prevPageButton.onClick.AddListener(PreviousPage);
        buy_btn.onClick.AddListener(Buy);

        UpdateButtonState();
    }
    private void Update()
    {
        buy_btn.interactable=player.money>int.Parse(price_Text.text);
    }

    private void InitializePage()
    {
        // 清空當前頁的槽
        foreach (var slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();

        // 計算當前頁顯示的物品範圍
        int startIndex = currentPage * itemsPerPage;
        int endIndex = Mathf.Min(startIndex + itemsPerPage, storeBag.itemlist.Count);

        // 生成當前頁的物品槽
        for (int i = startIndex; i < endIndex; i++)
        {
            GameObject newSlot = Instantiate(slot_prefab, slot_grid.transform);
            store_slot slotComponent = newSlot.GetComponent<store_slot>();

            slotComponent.SetupSlot(storeBag.itemlist[i], informationText, price_Text);
            slots.Add(newSlot);
        }
    }

    private void NextPage()
    {
        if (currentPage < totalPages - 1)
        {
            currentPage++;
            InitializePage();
            UpdateButtonState();
        }
    }

    private void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            InitializePage();
            UpdateButtonState();
        }
    }
    private void Buy()
    {
        int has;
        if (selectedItem == null)
        {
            Debug.LogWarning("沒有選中商品！");
            return;
        }

        int itemPrice = selectedItem.price;

        // 檢查玩家金錢是否足夠
        if (player.money >= itemPrice)
        {
            // 將商品加入玩家背包
            foreach(item item in player_bag.itemlist){
                if(item!=null && item.item_name==selectedItem.item_name){
                    item.held += 1;
                    Debug.Log($"購買成功: {selectedItem.item_name}");
                    bag_controller.change();
                    // 扣除金錢
                    player.money -= itemPrice;
                    player_money_Text.text = player.money.ToString();
                    return;
                }
            }
            // 如果玩家背包沒有該物品，添加新物品
            for(int i=0;i<16;i++){
                if(player_bag.itemlist[i]==null){
                    player_bag.itemlist[i]=selectedItem;
                    Debug.Log($"購買成功: {selectedItem.item_name}");
                    bag_controller.change();
                    // 扣除金錢
                    player.money -= itemPrice;
                    player_money_Text.text = player.money.ToString();
                    return;
                }
            }
            Debug.Log("背包已滿");
        }
        else
        {
            Debug.LogWarning("金錢不足！");
        }
    }
    public void SetSelectedItem(item selected)
    {
        selectedItem = selected;

        // 更新信息和價格顯示
        informationText.text = selected.iteminfo;
        price_Text.text = selected.price.ToString();
    }

    private void UpdateButtonState()
    {
        // 根據當前頁更新按鈕狀態
        prevPageButton.interactable = currentPage > 0;
        nextPageButton.interactable = currentPage < totalPages - 1;
    }

}
