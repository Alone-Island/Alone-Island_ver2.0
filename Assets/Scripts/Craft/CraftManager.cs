using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    // �ʿ��� ������Ʈ
    [SerializeField]
    public ItemData ItemData;
    private Inventory Inventory;

    public GameObject CraftContent;
    public GameObject CraftComplete;
    public List<ItemData.ItemDictionary> itemData;

    // Start is called before the first frame update
    void Start()
    {
        Inventory = FindObjectOfType<Inventory>();
        ItemData = FindObjectOfType<ItemData>();
        //CraftContent = GameObject.Find("Content");

        itemData = new List<ItemData.ItemDictionary>();
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

        for (int i = 0; i < itemData.Count; i++)
        {
            ItemData.ItemDictionary item = itemData[i];
            GameObject craftItemList = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Craft/CraftItemList") as GameObject) as GameObject;
            craftItemList.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = item.item.itemImage;
            craftItemList.transform.SetParent(CraftContent.transform, false);

            for (int j = 0; j < item.materials.Count; j++)
            {
                GameObject material = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Craft/Material") as GameObject) as GameObject;
                material.transform.SetParent(craftItemList.transform.GetChild(2), false);

                material.transform.GetChild(0).GetComponent<Image>().sprite = item.materials[j].item.itemImage;
                material.transform.GetChild(2).GetComponent<Text>().text = item.materials[j].num.ToString();

                if (j < item.materials.Count - 1)
                {
                    GameObject addMaterial = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Craft/AddMaterial") as GameObject) as GameObject;
                    addMaterial.transform.SetParent(craftItemList.transform.GetChild(2), false);
                }
            }

            if (CheckCanMakeItem(item.materials))
            {
                craftItemList.GetComponent<Button>().enabled = false;
            } else
            {
                craftItemList.GetComponent<Button>().enabled = true;
            }

            craftItemList.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (MakeNewItem(item))
                {
                    CraftComplete.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = item.item.itemImage;
                    CraftComplete.SetActive(true);
                }
            });
        }

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (ItemData != null)
        {
            
        }
    }

    // K : �κ��丮�� �ʿ��� ��ᰡ ��� ������ ��� ����Ʈ ����, �ƴϸ� null ����
    private Boolean CheckCanMakeItem(List<ItemData.Items> materials) {
        //List<ItemData.Items> materials = ItemData.GetItemMaterialsData(_item);  // J : �������� ����µ� �ʿ��� ��� ����Ʈ �޾ƿ���

        foreach (ItemData.Items material in materials)
        { // J : ��� + ����� ����
            if (material.num > Inventory.GetItemCount(material.item))    // J : �κ��丮�� ����� ������ �ʿ� �������� ���ٸ� ����� �Ұ���
                return false;
        }

        return true;   // J : ����� �����ϸ� ��� ����Ʈ ����
    }

    // K : ������ ����� ���� ���� ����
    public bool MakeNewItem(ItemData.ItemDictionary _item) {
        if (!CheckCanMakeItem(_item.materials))  // J : �κ��丮�� �����ϴ� �����۵�δ� _item ����� �Ұ���
        {
            Debug.Log(_item.item.name + " ȹ�� ����");
            return false;
        }

        // J : �κ��丮�� ��� ������ �Һ�
        foreach (ItemData.Items material in _item.materials)
            Inventory.ConsumeItem(material.item, material.num);
        Inventory.AcquireItem(_item.item);    // K : �κ��丮�� ���Կ� ������ �߰�
        Debug.Log(_item.item.name + " ȹ�� ����");

        return true;
    }
}
