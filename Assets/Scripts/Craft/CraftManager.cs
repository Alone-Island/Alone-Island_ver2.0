using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    // 필요한 컴포넌트
    [SerializeField]
    private ItemData itemData;
    private Inventory theInventory;

    // Start is called before the first frame update
    void Start()
    {
        theInventory = FindObjectOfType<Inventory>();
        itemData = FindObjectOfType<ItemData>();

        
    }

    // K : 인벤토리에 필요한 재료가 모두 있으면 재료 리스트 리턴, 아니면 null 리턴
    private List<ItemData.Items> CheckMakeItem(Item _item) {
        List<ItemData.Items> materials = itemData.GetItemMaterialsData(_item);  // J : 아이템을 만드는데 필요한 재료 리스트 받아오기

        foreach (ItemData.Items material in materials)  // J : 재료 + 재료의 개수
            if (material.num < theInventory.GetItemCount(material.item))    // J : 인벤토리에 재료의 개수가 필요 개수보다 적다면 만들기 불가능
                return null;

        return materials;   // J : 만들기 가능하면 재료 리스트 리턴
    }

    // K : 아이템 만들기 성공 여부 리턴
    public bool MakeNewItem(Item _item) {
        List<ItemData.Items> materials = CheckMakeItem(_item);

        if (materials == null)  // J : 인벤토리에 존재하는 아이템들로는 _item 만들기 불가능
        {
            Debug.Log(_item.itemName + " 획득 실패");
            return false;
        }

        // J : 인벤토리의 재료 아이템 소비
        foreach (ItemData.Items material in materials)
            theInventory.ConsumeItem(material.item, material.num);
        theInventory.AcquireItem(_item);    // K : 인벤토리의 슬롯에 아이템 추가
        Debug.Log(_item.itemName + " 획득 성공");

        return true;
    }
}
