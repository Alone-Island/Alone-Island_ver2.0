using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    private struct ItemDictionary
    {
        public Item item { get; set; }      // K : 아이템
        public List<Items> materials { get; set; }

        public ItemDictionary(Item _item, List<Items> _materials)
        {
            this.item = _item;
            this.materials = _materials;
        }
    }

    private struct Items
    {
        public int Id { get; set; }      // K : 아이템 id
        public int Num { get; set; }      // K : 아이템 갯수

        public Items(int _id, int _num)
        {
            this.Id = _id;
            this.Num = _num;
        }
    }

    private Dictionary<int, ItemDictionary> itemData;       // K : 대화 데이터를 저장하는 dictionary 변수

    void Awake()
    {
        itemData = new Dictionary<int, ItemDictionary>();
        GenerateData(itemData);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateData(Dictionary<int, ItemDictionary> itemData)
    {
        itemData.Add(0, new ItemDictionary(new Item("knife", Item.ItemType.Equipment), new List<Items> {new Items(1, 1), new Items(2, 2) } ));
        itemData.Add(1, new ItemDictionary(new Item("strawerry", Item.ItemType.Used), null) );
    }

    public List<Tuple<int, int>> GetItemMaterialsData(int id)
    {
        List<Tuple<int, int>> materials = new() { };
        for (int i = 0; i < itemData[id].materials.Count; i++)
        {
            materials.Add(Tuple.Create<int, int>(itemData[id].materials[i].Id, itemData[id].materials[i].Num));
        }
        return materials;
    }

    public Item GetItemData(int id)
    {
        return itemData[id].item;
    }
}
