using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // J : TextMeshPro

public class RearManager : MonoBehaviour
{
    private GameObject prefab;  // J : 아이템 정보를 담는 프리팹 오브젝트
    private Dictionary<Item, int> itemList;     // J : 식량 아이템 리스트
    
    // 필요한 컴포넌트
    [SerializeField]
    private GameObject Content;  // J : 스크롤뷰의 Content 오브젝트
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
        itemList = theInventory.GetTypeItemList(Item.ItemType.Used); // J : 식량 아이템 리스트 받아오기

        foreach (KeyValuePair<Item, int> _item in itemList)
        {
            GameObject obj = Instantiate(prefab);   // J : 프리팹 복제
            obj.transform.SetParent(Content.transform); // J : Content 오브젝트의 자식 오브젝트
            obj.transform.localScale = new Vector3(1, 1, 1);

            // J : 아이템 정보 화면에 표시
            obj.transform.Find("ItemImage").GetComponent<Image>().sprite = _item.Key.itemImage;
            obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = _item.Key.itemName;
            obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = _item.Value.ToString();

            // J : ItemInfo 스크립트에 저장
            obj.GetComponent<ItemInfo>().item = _item.Key;
            obj.GetComponent<ItemInfo>().count = _item.Value;
        }
    }

    // J : 플레이어 앞에 음식 떨어트리기
    public void DropFood(Item item, int count)
    {
        Debug.Log("DropFood" + item.itemName + count.ToString());
    }
}
