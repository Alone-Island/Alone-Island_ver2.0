using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    private struct ItemDictionary
    {
        //public Item item { get; set; }      // K : 아이템
        public string name { get; set; }      // K : 아이템 이름
        public Item.ItemType type { get; set; }      // K : 아이템 타입
        public List<Items> materials { get; set; }

        public ItemDictionary(string _name, Item.ItemType _type, List<Items> _materials)
        {
            //this.item = _item;
            this.name = _name;
            this.type = _type;
            this.materials = _materials;
        }
    }

    private struct Items
    {
        public int Id { get; set; }      // K : 아이템 id
        public string Name { get; set; }      // K : 아이템 id
        public int Num { get; set; }      // K : 아이템 갯수

        public Items(int _id, string _name, int _num)
        {
            this.Id = _id;
            this.Name = _name;
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
        itemData.Add(0, new ItemDictionary("knife", Item.ItemType.Equipment, new List<Items> {new Items(1, "branch", 1), new Items(2, "rock", 2) } ));
        itemData.Add(1, new ItemDictionary("strawerry", Item.ItemType.Used, null) );
    }

    public List<Tuple<int, string, int>> GetItemMaterialsData(int id)
    {
        List<Tuple<int, string, int>> materials = new List<Tuple<int, string, int>>();
        for (int i = 0; i < itemData[id].materials.Count; i++)
        {
            materials.Add(Tuple.Create<int, string, int>(itemData[id].materials[i].Id, itemData[id].materials[i].Name, itemData[id].materials[i].Num));
        }
        return materials;
    }

    public Item GetItemData(int id)
    {
        return new Item(itemData[id].name, itemData[id].type);
    }

    public List<Tuple<int, string>> GetItems()
    {
        List<Tuple<int, string>> itemsData = new List<Tuple<int, string>>();

        for (int i = 0; i < itemData.Count; i++)
        {
            itemsData.Add(Tuple.Create<int, string>(i, itemData[i].name));
        }
        return itemsData;
    }
}
