using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class store_controller : MonoBehaviour
{
    public bag storeBag; // 商店數據
    public GameObject slot_grid; // 用於存放物品槽的 UI 容器
    public GameObject slot_prefab; // 商店物品槽的預製件
    public Text informationText;
    public Text price_Text;
    private List<GameObject> slots = new List<GameObject>(); // 保存所有生成的物品槽

    void Start()
    {
        if (storeBag != null)
        {
            InitializeStore();
        }
        else
        {
            Debug.LogError("storeBag 未設定，請在 Inspector 中指定一個 store_bag！");
        }
    }

    private void InitializeStore()
    {
        foreach (item storeItem in storeBag.itemlist)
        {
            GameObject newSlot = Instantiate(slot_prefab, slot_grid.transform);
            store_slot slotComponent = newSlot.GetComponent<store_slot>();

            if (slotComponent != null)
            {
                slotComponent.SetupSlot(storeItem,informationText,price_Text);
                slots.Add(newSlot);
            }
            else
            {
                Debug.LogError("slot_prefab 缺少 store_slot 組件！");
            }
        }
    }
}
