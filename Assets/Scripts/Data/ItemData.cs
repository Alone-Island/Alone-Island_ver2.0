using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public struct ItemDictionary
    {
        public Item item;   // J : ����� ���� ������
        public List<Items> materials;   // K : item�� ����µ� �ʿ��� ��� ������

        public ItemDictionary(Item _item, List<Items> _materials)
        {
            item = _item;
            materials = _materials;
        }
    }

    public struct Items
    {
        public Item item;   // J : �ʿ��� ��� ������
        public int num { get; set; }      // K : ������ ����

        public Items(Item _item, int _num)
        {
            item = _item;
            num = _num;
        }
    }

    private List<ItemDictionary> itemData;       // K : ���� �����͸� �����ϴ� dictionary ����

    void Awake()
    {
        GenerateData(itemData);
    }

    void GenerateData(List<ItemDictionary> itemData)
    {
        itemData = new List<ItemDictionary>();
        // J : ���� ������ �߰� (����)
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

    // K : ������ ����⿡ �ʿ��� ��� ������ ����
    public List<Items> GetItemMaterialsData(Item _item)
    {
        foreach (ItemDictionary dict in itemData)
            if (dict.item== _item)
                return dict.materials;
        return null;
    }
}
