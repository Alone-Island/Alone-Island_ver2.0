using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // J : TextMeshPro

public class RearManager : MonoBehaviour
{
    private GameObject prefab;  // J : ������ ������ ��� ������ ������Ʈ
    private Dictionary<Item, int> itemList;     // J : �ķ� ������ ����Ʈ
    
    // �ʿ��� ������Ʈ
    [SerializeField]
    private GameObject Content;  // J : ��ũ�Ѻ��� Content ������Ʈ
    private Inventory theInventory;

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
        itemList = theInventory.GetTypeItemList(Item.ItemType.Used); // J : �ķ� ������ ����Ʈ �޾ƿ���

        foreach (KeyValuePair<Item, int> _item in itemList)
        {
            GameObject obj = Instantiate(prefab);   // J : ������ ����
            obj.transform.SetParent(Content.transform); // J : Content ������Ʈ�� �ڽ� ������Ʈ
            obj.transform.localScale = new Vector3(1, 1, 1);

            // J : ������ ���� ȭ�鿡 ǥ��
            obj.transform.Find("ItemImage").GetComponent<Image>().sprite = _item.Key.itemImage;
            obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = _item.Key.itemName;
            obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = _item.Value.ToString();

            // J : ItemInfo ��ũ��Ʈ�� ����
            obj.GetComponent<ItemInfo>().item = _item.Key;
            obj.GetComponent<ItemInfo>().count = _item.Value;
        }
    }

    // J : �÷��̾� �տ� ���� ����Ʈ����
    public void DropFood(Item item, int count)
    {
        Debug.Log("DropFood" + item.itemName + count.ToString());
    }
}
