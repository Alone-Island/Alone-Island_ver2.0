using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // J : TextMeshPro

public class RearManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnPosition;  // J : ������ ������ ��ġ
    private Dictionary<Item, int> itemList;     // J : �ķ� ������ ����Ʈ
    private Item dropItem;  // J : �÷��̾ ����� �ķ� ������

    // �ʿ��� ������Ʈ
    [SerializeField]
    private GameObject Content;  // J : ��ũ�Ѻ��� Content ������Ʈ
    private Inventory theInventory;
    private GameObject prefab;  // J : ������ ������ ��� ������ ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        // J : ������Ʈ �ҷ�����
        theInventory = FindObjectOfType<Inventory>();
        prefab = Resources.Load("Prefabs/ItemInfo") as GameObject;

        SetFoodItemList();  // J : ���� ����Ʈ ����
        HuntingManager.SpawnAnimal(Resources.Load("Prefabs/" + GameData.encounterAnimal.englishName), spawnPosition);   // J : HunitngManager�� �Լ��� ���� ����
    }

    // J : ���� ����Ʈ ����
    private void SetFoodItemList()
    {
        itemList = theInventory.GetTypeItemList(Item.ItemType.Food); // J : �ķ� ������ ����Ʈ �޾ƿ���

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
    public void DropFood(GameObject obj)
    {
        if (theInventory.ConsumeItem(obj.GetComponent<ItemInfo>().item))    // J : �������� 1�� �̻� ������
        {
            dropItem = obj.GetComponent<ItemInfo>().item;
            itemList[dropItem] -= 1;   // J : ������ ����Ʈ���� ���� ������Ʈ
            // J : ȭ��, ItemInfo ���� ����
            obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = itemList[dropItem].ToString();
            obj.GetComponent<ItemInfo>().count = itemList[dropItem];

            // J : ���� ����Ʈ����
            Vector3 spawnPosition = GameObject.Find("Player").transform.position;
            spawnPosition.x += GameObject.Find("Player").transform.localScale.x;
            GameObject foodObject = Instantiate(dropItem.itemPrefab, spawnPosition, Quaternion.identity);    // J : ���� ������Ʈ ����
            foodObject.GetComponent<Rigidbody2D>().gravityScale = 1;  // J : Ⱦ��ũ���̹Ƿ� �߷� ����

            checkPreferFood();
        }
    }

    private void checkPreferFood()
    {
        List<FoodItem.FoodType> preferFoods = GameData.encounterAnimal.preferFoods; // J : ������ �����ϴ� ���� ����
        if (preferFoods.Contains(((FoodItem)dropItem).foodType))    // J : ����� ������ ������ �����ϴ� �����̸�
        {
            Debug.Log("����̱� ���� Ȯ�� ����");
        }
        else
        {
            Debug.Log("����̱� ����");
        }
    }
}
