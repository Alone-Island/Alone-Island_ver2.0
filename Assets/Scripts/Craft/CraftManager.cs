using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    // 필요한 컴포넌트
    [SerializeField]
    private static CraftManager _instance;

    public ItemData ItemData;
    private Inventory Inventory;

    public GameObject CraftContent;
    public GameObject CraftComplete;
    public List<ItemData.ItemDictionary> itemData;

    // Start is called before the first frame update
    private void Start()
    {
        Inventory = FindObjectOfType<Inventory>();
        ItemData = FindObjectOfType<ItemData>();

        //ItemData.GenerateData();

        itemData = ItemData.GenerateData();
        // J : 공예 데이터 추가 (예시)
        //itemData = ItemData.itemData;

       
    }

    private void Update()
    {
    }
    public CraftManager Instance()
    {
        Init();
        return _instance;
    }
    private void Init()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<CraftManager>();
        }
    }

    // K : 인벤토리에 필요한 재료가 모두 있으면 재료 리스트 리턴, 아니면 null 리턴
    public Boolean CheckCanMakeItem(List<ItemData.Items> materials) {
        //List<ItemData.Items> materials = ItemData.GetItemMaterialsData(_item);  // J : 아이템을 만드는데 필요한 재료 리스트 받아오기

        foreach (ItemData.Items material in materials)
        { // J : 재료 + 재료의 개수
            if (material.num > Inventory.GetItemCount(material.item))    // J : 인벤토리에 재료의 개수가 필요 개수보다 적다면 만들기 불가능
                return false;
        }

        return true;   // J : 만들기 가능하면 재료 리스트 리턴
    }

    // K : 아이템 만들기 성공 여부 리턴
    public bool MakeNewItem(ItemData.ItemDictionary _item) {
        if (!CheckCanMakeItem(_item.materials))  // J : 인벤토리에 존재하는 아이템들로는 _item 만들기 불가능
        {
            Debug.Log(_item.item.name + " 획득 실패");
            return false;
        }

        // J : 인벤토리의 재료 아이템 소비
        foreach (ItemData.Items material in _item.materials)
            Inventory.ConsumeItem(material.item, material.num);
        Inventory.AcquireItem(_item.item);    // K : 인벤토리의 슬롯에 아이템 추가
        Debug.Log(_item.item.name + " 획득 성공");

        return true;
    }
}
