using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{

    [SerializeField]
    private Inventory theInventory;
    [SerializeField]
    private ItemData itemData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<Tuple<int, string, int>> CheckCanMakeThisItem(int id)
    {
        List<Tuple<int, string, int>> materials = itemData.GetItemMaterialsData(id);
        for (int i = 0; i < materials.Count; i++)
        {
            Item item = itemData.GetItemData(id);
            int count = theInventory.GetItemCount(item.name); // K : 모든 아이템을 가져오는 함수 or 특정 item이 몇개 있는지 알려주는 함수 필요함
            if (count < materials[i].Item3)
            {
                return null;
            }
        }
        return materials;
    }

    public bool MakeNewItem(int id)
    {
        List<Tuple<int, string, int>> materials = CheckCanMakeThisItem(id);
        Item newItem = itemData.GetItemData(id);
        if (materials == null)
        {
            Debug.Log(newItem.itemName + " 획득 실패");
            return false;
        }

        for (int i = 0; i < materials.Count; i++)
        {
            // materials[i].item1 해당 아이템 인벤토리에서 -count 하는 함수, - materials[i].Item3
            theInventory.ConsumeItem(materials[i].Item2, materials[i].Item3);
        }

        // K : 아이템 인벤토리 추가
        Debug.Log(newItem.itemName + " 획득 성공");
        theInventory.AcquireItem(newItem);    // J : 인벤토리의 슬롯에 아이템 추가


        return true;
    }
}
