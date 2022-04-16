using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public struct ItemDictionary
    {
        public Item item;   // J : 만들고 싶은 아이템
        public List<Items> materials;   // K : item을 만드는데 필요한 재료 데이터

        public ItemDictionary(Item _item, List<Items> _materials)
        {
            item = _item;
            materials = _materials;
        }
    }

    public struct Items
    {
        public Item item;   // J : 필요한 재료 아이템
        public int num { get; set; }      // K : 아이템 갯수

        public Items(Item _item, int _num)
        {
            item = _item;
            num = _num;
        }
    }

    private List<ItemDictionary> itemData;       // K : 공예 데이터를 저장하는 dictionary 변수

    void Awake()
    {
        GenerateData(itemData);
    }

    void GenerateData(List<ItemDictionary> itemData)
    {
        itemData = new List<ItemDictionary>();
        // J : 공예 데이터 추가 (예시)
        itemData.Add(new ItemDictionary(
            Resources.Load<Item>("Item/Equipment/Shovel"),
            new List<Items> {
                new Items(Resources.Load<Item>("Item/Food/Apple"), 1),
                new Items(Resources.Load<Item>("Item/Food/Banana"), 2)
            }));
        itemData.Add(new ItemDictionary(
            Resources.Load<Item>("Item/Equipment/Pork"),
            new List<Items> {
                new Items(Resources.Load<Item>("Item/Food/Carrot"), 2)
            }));
    }

    // K : 아이템 만들기에 필요한 재료 데이터 리턴
    public List<Items> GetItemMaterialsData(Item _item)
    {
        foreach (ItemDictionary dict in itemData)
            if (dict.item== _item)
                return dict.materials;
        return null;
    }
}
