using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-2/
public class Inventory : MonoBehaviour
{
    private bool inventoryActivated = false;    // J : 현재 인벤토리 창의 상태 (활성화/비활성화)

    // J : 필요한 컴포넌트
    [SerializeField]
    private GameObject inventoryImage;  // J : 인벤토리 이미지

    // Update is called once per frame
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
}
