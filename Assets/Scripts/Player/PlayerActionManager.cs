using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-1/
public class PlayerActionManager : MonoBehaviour
{
    [SerializeField]
    private float range;    // J : 아이템을 주울 수 있는 범위

    private bool pickupActivated = false;  // J : 아이템 습득 가능 여부

    private RaycastHit hitInfo; // J : 충돌체의 정보

    [SerializeField]
    private LayerMask layerMask;    // J : Item 레이어를 가지는 오브젝트만 습득해야 함


    // Update is called once per frame
    void Update()
    {
        TryAction();
    }

    // J : 특정 행동 시도
    private void TryAction()
    {
        // J : E키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();    // J : 플레이어가 주울 수 있는 아이템이 있는지 확인
            CanPickUp();    // J : 아이템을 주울 수 있으면 줍기
        }
    }

    // J : 플레이어가 주울 수 있는 아이템이 있는지 확인
    private void CheckItem()
    {
        // J : 플레이어의 앞에 일정 범위 내에 있는 게임 오브젝트의 정보를 hitInfo에 저장
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")    // J : 오브젝트의 tag가 Item
            {
                pickupActivated = true;
            }
            else
                pickupActivated = false;
        }
    }

    // J : 아이템을 주울 수 있으면 줍기
    private void CanPickUp()
    {
        if (pickupActivated)    // J : 아이템을 주울 수 있는 상태
        {
            Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "를 획득");
            // J : 인벤토리에 아이템 추가하는 함수
            Destroy(hitInfo.transform.gameObject);  // J : 주웠으므로 오브젝트 삭제
        }
    }
}
