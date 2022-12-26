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
    private GameObject tameNoticeObj;   // J : 길들이기 알림 오브젝트

    [SerializeField]
    private LayerMask itemLayerMask;    // J : Item 레이어를 가지는 오브젝트만 습득해야 함
    [SerializeField]
    private LayerMask animalLayerMask;    // J : animal 레이어를 가지는 오브젝트만 습득해야 함
    [SerializeField]
    private LayerMask myAnimalLayerMask;    // N : MyAnimal 레이어를 가지는 오브젝트만
    [SerializeField]
    private LayerMask portalLayerMask;      // J : 포탈 레이어 감지

    // 필요한 리소스
    private GameObject tameNotice;  // J : 길들이기 알림

    // 필요한 컴포넌트
    [SerializeField] private Inventory theInventory;
    [SerializeField] private PlayerMove thePlayerMove;
    [SerializeField] private TamingManager theTamingManager;
    [SerializeField] private CraftManager theCraftManager;

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
        tameNotice = (GameObject) Resources.Load("Prefabs/UI/TameNotice");
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
        if (collision.gameObject.tag == "Work")
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
        CheckAnimal();      // J : 플레이어 앞에 동물이 있는지 확인
        CanHunt();          // J : 사냥 가능하면 사냥하기

        CheckMyAnimal();    // J : 플레이어 앞에 길들인 동물이 있는지 확인
        
        // J : E키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.E))
        {
            CanTame();      // J : 동물과 상호작용 가능하면 상호작용 (hitInfo 유지를 위해 반드시 CheckMyAnimal 직후 호출)

            CheckItem();    // J : 플레이어가 주울 수 있는 아이템이 있는지 확인
            CanPickUp();    // J : 아이템을 주울 수 있으면 줍기

            TryPortal();    // J : 포탈 이용
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

        if (hitInfo.collider != null) // J : 교감 가능
        {
            if (!tameActivated)
            {
                if (tameNoticeObj == null) SpawnTameNotice();
                tameActivated = true;
            }
        }
        else    // J : 교감 불가
        {
            // J : 기존 길들이기 알림 오브젝트 삭제
            if (tameNoticeObj != null)
            {
                Destroy(tameNoticeObj);
                tameNoticeObj = null;
            }
            tameActivated = false;
        }

        return tameActivated;
    }

    // J : 포탈 이용
    private void TryPortal()
    {
        // J : 포탈 오브젝트 감지하기
        hitInfo = Physics2D.Raycast(transform.position, thePlayerMove.dirVec, range, portalLayerMask);

        if (hitInfo.collider != null) // J : 포탈 이용 가능
        {
            SceneManager.LoadScene(hitInfo.transform.GetComponent<Portal>().GetSceneBuildIdx()); // J : 포탈에 저장된 빌드 인덱스의 씬으로 이동
        }
    }

    // https://jinsdevlog.tistory.com/27 참고
    // J : 길들이기 알림 오브젝트를 캔버스에 스폰
    private void SpawnTameNotice()
    {
        Camera camera = FindObjectOfType<Camera>();
        Canvas canvas = FindObjectOfType<Canvas>();
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        Vector2 ViewportPosition = camera.WorldToViewportPoint(hitInfo.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));

        // J : 알림 중복 방지를 위해 클래스 변수로 저장 (나중에 중복 방지 코드 추가하기)
        tameNoticeObj = Instantiate(tameNotice, Vector2.zero, Quaternion.identity, canvas.transform);
        tameNoticeObj.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
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
        if (!tameActivated)
            return;

        Debug.Log(hitInfo.transform.gameObject.name + " 안아주기 / 쓰다듬기 / 먹이주기");

        if (theTamingManager == null)
            theTamingManager = FindObjectOfType<TamingManager>();
        theTamingManager.GrowMyAnimal(hitInfo.transform.gameObject);    // J : 임의로 성장도 경험치 증가
        tameActivated = false;
    }
}