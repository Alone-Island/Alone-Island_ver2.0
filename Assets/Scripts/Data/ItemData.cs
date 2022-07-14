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

    public List<ItemDictionary> itemData;       // K : ���� �����͸� �����ϴ� dictionary ����

    void Awake()
    {
    }

    public List<ItemDictionary> GenerateData()
    {
        itemData = new List<ItemDictionary>();
        // J : ���� ������ �߰� (����)
        itemData.Add(new ItemData.ItemDictionary(
            Resources.Load<Item>("Item/Equipment/Shovel"),
            new List<ItemData.Items> {
                        new ItemData.Items(Resources.Load<Item>("Item/Food/Apple"), 1),
                        new ItemData.Items(Resources.Load<Item>("Item/Food/Banana"), 2)
            }));
        itemData.Add(new ItemData.ItemDictionary(
            Resources.Load<Item>("Item/Food/Pork"),
            new List<ItemData.Items> {
                new ItemData.Items(Resources.Load<Item>("Item/Food/Carrot"), 2)
            }));
        itemData.Add(new ItemData.ItemDictionary(
            Resources.Load<Item>("Item/Food/Pork"),
            new List<ItemData.Items> {
                new ItemData.Items(Resources.Load<Item>("Item/Food/Carrot"), 2)
            }));

        return itemData;
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
