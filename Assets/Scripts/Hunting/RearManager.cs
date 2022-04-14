using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // J : TextMeshPro

public class RearManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Content;  // J : ��ũ�Ѻ��� Content ������Ʈ
    private Inventory theInventory;

    private GameObject prefab;  // J : ������ ������ ��� ������ ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        theInventory = FindObjectOfType<Inventory>();
        prefab = Resources.Load("Prefabs/FoodItem") as GameObject;
        SetFoodItemList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetFoodItemList()
    {
        Dictionary<Item, int> itemList = theInventory.GetTypeItemList(Item.ItemType.Used); // J : �ķ� ������ ����Ʈ �޾ƿ���
        Debug.Log(itemList.Count);
        foreach (KeyValuePair<Item, int> item in itemList)
        {
            GameObject obj = Instantiate(prefab);   // J : ������ ����
            obj.transform.SetParent(Content.transform); // J : Content ������Ʈ�� �ڽ� ������Ʈ

            // J : ������ ���� ����
            obj.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Key.itemImage;
            obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.Key.itemName;
            obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
        }

    }
}
