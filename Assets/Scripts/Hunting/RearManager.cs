using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // J : TextMeshPro

public class RearManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnPosition;              // J : ������ ������ ��ġ
    private Dictionary<Item, int> itemList;     // J : �ķ� ������ ����Ʈ
    private Item dropItem;                      // J : �÷��̾ ����� �ķ� ������
    private GameObject animalObject;            // J : ������ ���� ������Ʈ
    private GameObject foodObject;              // J : ������ ���� ������Ʈ
    private bool isDropFood;                    // J : ������ ����Ʈ�ȴ��� ����

    // �ʿ��� ������Ʈ
    [SerializeField]
    private GameObject Content;  // J : ��ũ�Ѻ��� Content ������Ʈ
    private Inventory theInventory;
    private GameObject prefab;  // J : ������ ������ ��� ������ ������Ʈ
    [SerializeField]
    private LayerMask itemLayerMask;    // J : ������ Item ���̾ ������ ������Ʈ(����) ����

    // Start is called before the first frame update
    void Start()
    {
        // J : ������Ʈ �ҷ�����
        theInventory = FindObjectOfType<Inventory>();
        prefab = Resources.Load("Prefabs/UI/ItemInfo") as GameObject;

        SetFoodItemList();  // J : ���� ����Ʈ ����
        animalObject = HuntingManager.SpawnAnimal(Resources.Load("Prefabs/Animals/" + DataController.Instance.gameData.encounterAnimal.englishName), spawnPosition);   // J : HunitngManager�� �Լ��� ���� ����
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
        if (!isDropFood && theInventory.ConsumeItem(obj.GetComponent<ItemInfo>().item))    // J : �������� 1�� �̻� ������
        {
            dropItem = obj.GetComponent<ItemInfo>().item;
            itemList[dropItem] -= 1;   // J : ������ ����Ʈ���� ���� ������Ʈ
            // J : ȭ��, ItemInfo ���� ����
            obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = itemList[dropItem].ToString();
            obj.GetComponent<ItemInfo>().count = itemList[dropItem];

            // J : ���� ����Ʈ����
            Vector3 spawnPosition = GameObject.Find("Player").transform.position;
            spawnPosition.x += GameObject.Find("Player").transform.localScale.x;
            foodObject = Instantiate(dropItem.itemPrefab, spawnPosition, Quaternion.identity);    // J : ���� ������Ʈ ����
            foodObject.GetComponent<Rigidbody2D>().gravityScale = 1;  // J : Ⱦ��ũ���̹Ƿ� �߷� ����
            isDropFood = true;  // J : ������ �ϳ��� ����Ʈ������

            StartCoroutine("AnimalGoToFood");   // J : ������ ������ ���� �̵�
        }
    }

    // J : ������ ������ ���� �̵�
    IEnumerator AnimalGoToFood()
    {
        Vector3 destination = foodObject.transform.position;
        while (true)
        {
            Vector3 dir = new Vector3(destination.x - animalObject.transform.position.x, 0, 0);
            animalObject.transform.position += dir * 1 * Time.deltaTime;

            if (AnimalCheckFood(dir, 1f))
                break;

            yield return null;
        }
        RearResult();
    }

    private void RearResult()
    {
        if (CheckPreferFood() && SuccessOrFail())  // J : �÷��̾ ����Ʈ�� ������ ������ ��ȣ�ϴ� ���� + ����̱� ����
        {
            DataController.Instance.gameData.animalInfoList.Add(new AnimalInfo(DataController.Instance.gameData.encounterAnimal.englishName));    // J : ���̾�̽��� ���� ������ ����
            Debug.Log("����̱� ����");
        }
        else
        {
            Debug.Log("����̱� ����");
        }
    }

    // J : ����̱� ���� ���� ����
    private bool SuccessOrFail()
    {
        float rearRate = animalObject.GetComponent<AnimalAction>().animal.rearRate;  // J : ������ ����� Ȯ��

        System.Random rand = new System.Random();
        if (rand.NextDouble() <= rearRate)
            return true;
        else
            return false;
    }

    // J : ���� �տ� �������� �ִ��� Ȯ��
    private bool AnimalCheckFood(Vector3 dir, float range)
    {
        // J : ���� �տ� ���� ���� ���� �ִ� ���� ������Ʈ�� ������ hitInfo�� ����
        Debug.DrawRay(animalObject.transform.position, dir * range, Color.green);   // J : ������ ���� ���� ���� ǥ��
        RaycastHit2D hitInfo = Physics2D.Raycast(animalObject.transform.position, dir, range, itemLayerMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.transform.tag == "Item")    // J : ������Ʈ�� tag�� Item
                return true;
            else
                return false;
        }
        return false;
    }

    // J : �÷��̾ ����Ʈ�� ������ ������ ��ȣ �������� Ȯ��
    private bool CheckPreferFood()
    {
        List<FoodItem.FoodType> preferFoods = DataController.Instance.gameData.encounterAnimal.preferFoods; // J : ������ �����ϴ� ���� ����
        if (preferFoods.Contains(((FoodItem)dropItem).foodType))    // J : ����� ������ ������ �����ϴ� �����̸�
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
