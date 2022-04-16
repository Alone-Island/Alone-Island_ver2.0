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
        prefab = Resources.Load("Prefabs/ItemInfo") as GameObject;
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
    public void DropFood(GameObject obj)
    {
        if (theInventory.ConsumeItem(obj.GetComponent<ItemInfo>().item))    // J : 아이템이 1개 이상 있으면
        {
            itemList[obj.GetComponent<ItemInfo>().item] -= 1;   // J : 아이템 리스트에서 개수 업데이트
            // J : 화면, ItemInfo 에서 갱신
            obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = itemList[obj.GetComponent<ItemInfo>().item].ToString();
            obj.GetComponent<ItemInfo>().count = itemList[obj.GetComponent<ItemInfo>().item];

            // J : 음식 떨어트리기
            Vector3 spawnPosition = GameObject.Find("Player").transform.position;
            spawnPosition.x += GameObject.Find("Player").transform.localScale.x;
            GameObject foodObject = Instantiate(obj.GetComponent<ItemInfo>().item.itemPrefab, spawnPosition, Quaternion.identity);    // J : 음식 오브젝트 스폰
            foodObject.GetComponent<Rigidbody2D>().gravityScale = 1;  // J : 횡스크롤이므로 중력 적용
        }
    }
}
