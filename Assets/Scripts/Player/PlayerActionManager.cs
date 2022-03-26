using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-1/
public class PlayerActionManager : MonoBehaviour
{
    [SerializeField]
    private float range;    // J : 아이템을 습득 가능 범위

    private bool pickupActivated = false;  // J : 아이템 습득 가능 여부
    private bool huntActivated = false;  // J : 사냥 가능 여부

    private RaycastHit2D hitInfo; // J : 충돌체의 정보

    [SerializeField]
    private LayerMask itemLayerMask;    // J : Item 레이어를 가지는 오브젝트만 습득해야 함
    [SerializeField]
    private LayerMask animalLayerMask;    // J : animal 레이어를 가지는 오브젝트만 습득해야 함

    // 필요한 컴포넌트
    [SerializeField]
    private Inventory theInventory;
    private PlayerMove thePlayerMove;

    private void Start()
    {
        thePlayerMove = GetComponent<PlayerMove>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, thePlayerMove.dirVec * range, Color.green);   // J : 아이템 습득 가능 범위 표시
        TryAction();
    }

    // J : 특정 행동 시도
    private void TryAction()
    {
        CheckAnimal();
        CanHunt();
        // J : E키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();    // J : 플레이어가 주울 수 있는 아이템이 있는지 확인
            CanPickUp();    // J : 아이템을 주울 수 있으면 줍기
        }
    }

    // J : 플레이어 앞에 동물이 있는지 확인
    private void CheckAnimal()
    {
        // J : 플레이어의 앞에 일정 범위 내에 있는 게임 오브젝트의 정보를 hitInfo에 저장
        hitInfo = Physics2D.Raycast(transform.position, thePlayerMove.dirVec, range, animalLayerMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.transform.tag == "Animal")    // J : 오브젝트의 tag가 Animal
            {
                huntActivated = true;
            }
            else
                huntActivated = false;
        }
    }

    // J : 플레이어가 주울 수 있는 아이템이 있는지 확인
    private void CheckItem()
    {
        // J : 플레이어의 앞에 일정 범위 내에 있는 게임 오브젝트의 정보를 hitInfo에 저장
        hitInfo = Physics2D.Raycast(transform.position, thePlayerMove.dirVec, range, itemLayerMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.transform.tag == "Item")    // J : 오브젝트의 tag가 Item
            {
                pickupActivated = true;
            }
            else
                pickupActivated = false;
        }
    }

    // J : 사냥 가능하면 사냥 장면으로 전환
    private void CanHunt()
    {
        if (huntActivated)    // J : 사냥 가능 상태
        {
            Debug.Log(hitInfo.transform.gameObject.name + "을(를) 만났다!");
            // 씬 전환
            huntActivated = false;
        }
    }

    // J : 아이템을 주울 수 있으면 줍기
    private void CanPickUp()
    {
        if (pickupActivated)    // J : 아이템을 주울 수 있는 상태
        {
            Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득");
            theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);    // J : 인벤토리의 슬롯에 아이템 추가
            Destroy(hitInfo.transform.gameObject);  // J : 주웠으므로 오브젝트 삭제
            pickupActivated = false;
        }
    }
}
