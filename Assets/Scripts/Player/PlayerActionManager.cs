using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-1/
public class PlayerActionManager : MonoBehaviour
{
    [SerializeField]
    private float range;    // J : 아이템을 습득 가능 범위

    private bool pickupActivated = false;  // J : 아이템 습득 가능 여부
    private bool huntActivated = false;  // J : 사냥 가능 여부
    private bool tameActivated = false;  // N : 교감 가능 여부

    private RaycastHit2D hitInfo; // J : 충돌체의 정보

    [SerializeField]
    private LayerMask itemLayerMask;    // J : Item 레이어를 가지는 오브젝트만 습득해야 함
    [SerializeField]
    private LayerMask animalLayerMask;    // J : animal 레이어를 가지는 오브젝트만 습득해야 함
    [SerializeField]
    private LayerMask myAnimalLayerMask;    // N : MyAnimal 레이어를 가지는 오브젝트만

    // 필요한 컴포넌트
    private Inventory theInventory;
    private PlayerMove thePlayerMove;
    private CraftManager theCraftManager;   // K

    public static PlayerActionManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);      // 플레이어 유지
    }

    private void Start()
    {
        thePlayerMove = GetComponent<PlayerMove>();
        theInventory = FindObjectOfType<Inventory>();
        theCraftManager = FindObjectOfType<CraftManager>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, thePlayerMove.dirVec * range, Color.green);   // J : 아이템 습득 가능 범위 표시
        TryAction();
    }

    // N :
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Potal")
        {
            if(collision.gameObject.name== "ToFarm")
            {
                Debug.Log("밭으로");
                SceneManager.LoadScene("Farm");
            }
            else if (collision.gameObject.name == "ToForest")
            {
                Debug.Log("숲으로");
                SceneManager.LoadScene("TestJ_hunt");
            }
            else if (collision.gameObject.name == "ToBeach")
            {
                Debug.Log("해변으로 / 씬 없음");
                SceneManager.LoadScene("Beach");
            }
            else if (collision.gameObject.name == "ToGrassland")
            {
                Debug.Log("초원으로");
                SceneManager.LoadScene("Taming");
            }
            else if (collision.gameObject.name == "ToLabInSide")
            {
                Debug.Log("연구실 안으로");
                SceneManager.LoadScene("TestK_DoctorLab");
            }
            else if (collision.gameObject.name == "ToLabOutSide")
            {
                Debug.Log("연구실 밖으로");
                SceneManager.LoadScene("TestK_Start");
            }
            else if (collision.gameObject.name == "ToMain")
            {
                Debug.Log("메인 화면");
                SceneManager.LoadScene("TestK_Start");
            }
        }
        else if (collision.gameObject.tag == "Work")
        {
            if (collision.gameObject.name == "Craft")
            {
                Debug.Log("공예 버튼");
                theCraftManager.CraftButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Work")
        {
            if (collision.gameObject.name == "Craft")
            {
                theCraftManager.CraftButton.SetActive(false);
            }
        }
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

        if (CheckMyAnimal())
        {
            CanTame();
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

    // N : My Animal이 있는지 체크
    private bool CheckMyAnimal()
    {
        hitInfo = Physics2D.Raycast(transform.position, thePlayerMove.dirVec, range, myAnimalLayerMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.transform.tag == "Animal")    // N : 오브젝트가 MyAnimal
            {
                tameActivated = true;               // 교감 가능
            }
            else
                tameActivated = false;              // 교감 불가
        }

        return tameActivated;
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
            huntActivated = false;
            Debug.Log(hitInfo.transform.gameObject.name + "을(를) 만났다!");
            DataController.Instance.gameData.encounterAnimal = hitInfo.transform.GetComponent<AnimalAction>().animal;   // J : 게임 데이터에 마주친 동물 저장
            SceneManager.LoadScene("EncounterAnimal");
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

    // N : 교감하기
    private void CanTame()
    {
        if (tameActivated)
        {
            Debug.Log(hitInfo.transform.gameObject.name + " 안아주기 / 쓰다듬기 / 먹이주기");
            tameActivated = false;
        }
    }
}
