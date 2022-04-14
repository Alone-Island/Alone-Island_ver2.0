using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // J : TextMeshPro

public class RearManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Content;  // J : 스크롤뷰의 Content 오브젝트
    private Inventory theInventory;

    private GameObject prefab;  // J : 아이템 정보를 담는 프리팹 오브젝트

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
        Dictionary<Item, int> itemList = theInventory.GetTypeItemList(Item.ItemType.Used); // J : 식량 아이템 리스트 받아오기
        Debug.Log(itemList.Count);
        foreach (KeyValuePair<Item, int> item in itemList)
        {
            GameObject obj = Instantiate(prefab);   // J : 프리팹 복제
            obj.transform.SetParent(Content.transform); // J : Content 오브젝트의 자식 오브젝트

            // J : 아이템 정보 설정
            obj.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Key.itemImage;
            obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.Key.itemName;
            obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
        }

    }
}
