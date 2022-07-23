using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // J : TextMeshPro

public class RearManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnPosition;              // J : 동물이 스폰될 위치
    private Dictionary<Item, int> itemList;     // J : 식량 아이템 리스트
    private Item dropItem;                      // J : 플레이어가 드롭한 식량 아이템
    private GameObject animalObject;            // J : 스폰한 동물 오브젝트
    private GameObject foodObject;              // J : 스폰한 음식 오브젝트
    private bool isDropFood;                    // J : 음식을 떨어트렸는지 여부

    // 필요한 컴포넌트
    [SerializeField]
    private GameObject Content;  // J : 스크롤뷰의 Content 오브젝트
    private Inventory theInventory;
    private GameObject prefab;  // J : 아이템 정보를 담는 프리팹 오브젝트
    [SerializeField]
    private LayerMask itemLayerMask;    // J : 동물이 Item 레이어를 가지는 오브젝트(음식) 감지

    // Start is called before the first frame update
    void Start()
    {
        // J : 컴포넌트 불러오기
        theInventory = FindObjectOfType<Inventory>();
        prefab = Resources.Load("Prefabs/UI/ItemInfo") as GameObject;

        SetFoodItemList();  // J : 음식 리스트 나열
        animalObject = HuntingManager.SpawnAnimal(Resources.Load("Prefabs/Animals/" + DataController.Instance.gameData.encounterAnimal.englishName), spawnPosition);   // J : HunitngManager의 함수로 동물 스폰
    }

    // J : 음식 리스트 나열
    private void SetFoodItemList()
    {
        itemList = theInventory.GetTypeItemList(Item.ItemType.Food); // J : 식량 아이템 리스트 받아오기

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
        if (!isDropFood && theInventory.ConsumeItem(obj.GetComponent<ItemInfo>().item))    // J : 아이템이 1개 이상 있으면
        {
            dropItem = obj.GetComponent<ItemInfo>().item;
            itemList[dropItem] -= 1;   // J : 아이템 리스트에서 개수 업데이트
            // J : 화면, ItemInfo 에서 갱신
            obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = itemList[dropItem].ToString();
            obj.GetComponent<ItemInfo>().count = itemList[dropItem];

            // J : 음식 떨어트리기
            Vector3 spawnPosition = GameObject.Find("Player").transform.position;
            spawnPosition.x += GameObject.Find("Player").transform.localScale.x;
            foodObject = Instantiate(dropItem.itemPrefab, spawnPosition, Quaternion.identity);    // J : 음식 오브젝트 스폰
            foodObject.GetComponent<Rigidbody2D>().gravityScale = 1;  // J : 횡스크롤이므로 중력 적용
            isDropFood = true;  // J : 음식을 하나만 떨어트리도록

            StartCoroutine("AnimalGoToFood");   // J : 동물이 음식을 향해 이동
        }
    }

    // J : 동물이 음식을 향해 이동
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
        if (CheckPreferFood() && SuccessOrFail())  // J : 플레이어가 떨어트린 음식이 동물이 선호하는 음식 + 길들이기 성공
        {
            DataController.Instance.gameData.animalInfoList.Add(new AnimalInfo(DataController.Instance.gameData.encounterAnimal.englishName));    // J : 파이어베이스에 동물 데이터 저장
            Debug.Log("길들이기 성공");
        }
        else
        {
            Debug.Log("길들이기 실패");
        }
    }

    // J : 길들이기 성공 여부 리턴
    private bool SuccessOrFail()
    {
        float rearRate = animalObject.GetComponent<AnimalAction>().animal.rearRate;  // J : 동물을 길들일 확률

        System.Random rand = new System.Random();
        if (rand.NextDouble() <= rearRate)
            return true;
        else
            return false;
    }

    // J : 동물 앞에 아이템이 있는지 확인
    private bool AnimalCheckFood(Vector3 dir, float range)
    {
        // J : 동물 앞에 일정 범위 내에 있는 게임 오브젝트의 정보를 hitInfo에 저장
        Debug.DrawRay(animalObject.transform.position, dir * range, Color.green);   // J : 아이템 습득 가능 범위 표시
        RaycastHit2D hitInfo = Physics2D.Raycast(animalObject.transform.position, dir, range, itemLayerMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.transform.tag == "Item")    // J : 오브젝트의 tag가 Item
                return true;
            else
                return false;
        }
        return false;
    }

    // J : 플레이어가 떨어트린 음식이 동물의 선호 음식인지 확인
    private bool CheckPreferFood()
    {
        List<FoodItem.FoodType> preferFoods = DataController.Instance.gameData.encounterAnimal.preferFoods; // J : 동물이 좋아하는 음식 유형
        if (preferFoods.Contains(((FoodItem)dropItem).foodType))    // J : 드롭한 음식이 동물이 좋아하는 유형이면
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
