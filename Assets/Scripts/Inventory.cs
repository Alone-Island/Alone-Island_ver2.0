using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-2/
// 인벤토리창 관리
public class Inventory : MonoBehaviour
{
    private bool inventoryActivated = false;    // J : 현재 인벤토리 창의 상태 (활성화/비활성화)

    // J : 필요한 컴포넌트
    [SerializeField]
    private GameObject inventoryImage;  // J : 인벤토리 이미지
    [SerializeField]
    private GameObject slotsParent;     // J : 슬롯들의 부모 오브젝트 (Grid Setting)

    private Slot[] slots;   // J : 슬롯들 배열

    private void Start()
    {
        // J : 자식 오브젝트(슬롯)의 Slot 컴포넌트들을 가져옴
        slots=slotsParent.GetComponentsInChildren<Slot>();
    }

    void Update()
    {
        TryOpenInventory();
    }

    // J : 인벤토리창 조작 시도
    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;
            if (inventoryActivated)
                OpenInventory();
            else
                CloseInventory();
        }

    }

    // J : 인벤토리 열기
    private void OpenInventory()
    {
        inventoryImage.SetActive(true); // J : 인벤토리 이미지 활성화
    }

    // J : 인벤토리 닫기
    private void CloseInventory()
    {
        inventoryImage.SetActive(false);     // J : 인벤토리 이미지 비활성화
    }

    public void AcquireItem(Item _item, int _count=1)
    {
        // J : 장비 아이템이 아닌 경우
        if (_item.itemType!= Item.ItemType.Equipment)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                // J : 슬롯에 이미 있는 아이템과 동일하다면 개수 업데이트
                if ((slots[i].item != null) && (slots[i].item.itemName==_item.itemName))
                {
                    slots[i].SetSlotCount(_count);
                    return;
                }
            }
        }

        // J : 장비 아이템이거나 슬롯에 존재하지 않는 새로운 아이템인 경우
        for (int i = 0; i < slots.Length; i++)
        {
            // J : 아이템이 들어있지 않은 슬롯에 추가
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }
}
