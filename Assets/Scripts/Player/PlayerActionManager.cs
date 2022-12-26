using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-1/
public class PlayerActionManager : MonoBehaviour
{
    [SerializeField]
    private float range;    // J : �������� ���� ���� ����

    private bool pickupActivated = false;  // J : ������ ���� ���� ����
    private bool huntActivated = false;  // J : ��� ���� ����
    private bool tameActivated = false;  // N : ���� ���� ����

    private RaycastHit2D hitInfo; // J : �浹ü�� ����
    private GameObject tameNoticeObj;   // J : ����̱� �˸� ������Ʈ

    [SerializeField]
    private LayerMask itemLayerMask;    // J : Item ���̾ ������ ������Ʈ�� �����ؾ� ��
    [SerializeField]
    private LayerMask animalLayerMask;    // J : animal ���̾ ������ ������Ʈ�� �����ؾ� ��
    [SerializeField]
    private LayerMask myAnimalLayerMask;    // N : MyAnimal ���̾ ������ ������Ʈ��
    [SerializeField]
    private LayerMask portalLayerMask;      // J : ��Ż ���̾� ����

    // �ʿ��� ���ҽ�
    private GameObject tameNotice;  // J : ����̱� �˸�

    // �ʿ��� ������Ʈ
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

        DontDestroyOnLoad(gameObject);      // �÷��̾� ����
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
        Debug.DrawRay(transform.position, thePlayerMove.dirVec * range, Color.green);   // J : ������ ���� ���� ���� ǥ��
        TryAction();
    }

    // N :
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Work")
        {
            if (collision.gameObject.name == "Craft")
            {
                Debug.Log("���� ��ư");
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

    // J : Ư�� �ൿ �õ�
    private void TryAction()
    {
        CheckAnimal();      // J : �÷��̾� �տ� ������ �ִ��� Ȯ��
        CanHunt();          // J : ��� �����ϸ� ����ϱ�

        CheckMyAnimal();    // J : �÷��̾� �տ� ����� ������ �ִ��� Ȯ��
        
        // J : EŰ�� ������ ��
        if (Input.GetKeyDown(KeyCode.E))
        {
            CanTame();      // J : ������ ��ȣ�ۿ� �����ϸ� ��ȣ�ۿ� (hitInfo ������ ���� �ݵ�� CheckMyAnimal ���� ȣ��)

            CheckItem();    // J : �÷��̾ �ֿ� �� �ִ� �������� �ִ��� Ȯ��
            CanPickUp();    // J : �������� �ֿ� �� ������ �ݱ�

            TryPortal();    // J : ��Ż �̿�
        }
    }

    // J : �÷��̾� �տ� ������ �ִ��� Ȯ��
    private void CheckAnimal()
    {
        // J : �÷��̾��� �տ� ���� ���� ���� �ִ� ���� ������Ʈ�� ������ hitInfo�� ����
        hitInfo = Physics2D.Raycast(transform.position, thePlayerMove.dirVec, range, animalLayerMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.transform.tag == "Animal")    // J : ������Ʈ�� tag�� Animal
            {
                huntActivated = true;
            }
            else
                huntActivated = false;
        }
    }

    // N : My Animal�� �ִ��� üũ
    private bool CheckMyAnimal()
    {
        hitInfo = Physics2D.Raycast(transform.position, thePlayerMove.dirVec, range, myAnimalLayerMask);

        if (hitInfo.collider != null) // J : ���� ����
        {
            if (!tameActivated)
            {
                if (tameNoticeObj == null) SpawnTameNotice();
                tameActivated = true;
            }
        }
        else    // J : ���� �Ұ�
        {
            // J : ���� ����̱� �˸� ������Ʈ ����
            if (tameNoticeObj != null)
            {
                Destroy(tameNoticeObj);
                tameNoticeObj = null;
            }
            tameActivated = false;
        }

        return tameActivated;
    }

    // J : ��Ż �̿�
    private void TryPortal()
    {
        // J : ��Ż ������Ʈ �����ϱ�
        hitInfo = Physics2D.Raycast(transform.position, thePlayerMove.dirVec, range, portalLayerMask);

        if (hitInfo.collider != null) // J : ��Ż �̿� ����
        {
            SceneManager.LoadScene(hitInfo.transform.GetComponent<Portal>().GetSceneBuildIdx()); // J : ��Ż�� ����� ���� �ε����� ������ �̵�
        }
    }

    // https://jinsdevlog.tistory.com/27 ����
    // J : ����̱� �˸� ������Ʈ�� ĵ������ ����
    private void SpawnTameNotice()
    {
        Camera camera = FindObjectOfType<Camera>();
        Canvas canvas = FindObjectOfType<Canvas>();
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        Vector2 ViewportPosition = camera.WorldToViewportPoint(hitInfo.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));

        // J : �˸� �ߺ� ������ ���� Ŭ���� ������ ���� (���߿� �ߺ� ���� �ڵ� �߰��ϱ�)
        tameNoticeObj = Instantiate(tameNotice, Vector2.zero, Quaternion.identity, canvas.transform);
        tameNoticeObj.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
    }

    // J : �÷��̾ �ֿ� �� �ִ� �������� �ִ��� Ȯ��
    private void CheckItem()
    {
        // J : �÷��̾��� �տ� ���� ���� ���� �ִ� ���� ������Ʈ�� ������ hitInfo�� ����
        hitInfo = Physics2D.Raycast(transform.position, thePlayerMove.dirVec, range, itemLayerMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.transform.tag == "Item")    // J : ������Ʈ�� tag�� Item
            {
                pickupActivated = true;
            }
            else
                pickupActivated = false;
        }
    }

    // J : ��� �����ϸ� ��� ������� ��ȯ
    private void CanHunt()
    {
        if (huntActivated)    // J : ��� ���� ����
        {
            huntActivated = false;
            Debug.Log(hitInfo.transform.gameObject.name + "��(��) ������!");
            DataController.Instance.gameData.encounterAnimal = hitInfo.transform.GetComponent<AnimalAction>().animal;   // J : ���� �����Ϳ� ����ģ ���� ����
            SceneManager.LoadScene("EncounterAnimal");
        }
    }

    // J : �������� �ֿ� �� ������ �ݱ�
    private void CanPickUp()
    {
        if (pickupActivated)    // J : �������� �ֿ� �� �ִ� ����
        {
            Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ��");
            theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);    // J : �κ��丮�� ���Կ� ������ �߰�
            Destroy(hitInfo.transform.gameObject);  // J : �ֿ����Ƿ� ������Ʈ ����
            pickupActivated = false;
        }
    }

    // N : �����ϱ�
    private void CanTame()
    {
        if (!tameActivated)
            return;

        Debug.Log(hitInfo.transform.gameObject.name + " �Ⱦ��ֱ� / ���ٵ�� / �����ֱ�");

        if (theTamingManager == null)
            theTamingManager = FindObjectOfType<TamingManager>();
        theTamingManager.GrowMyAnimal(hitInfo.transform.gameObject);    // J : ���Ƿ� ���嵵 ����ġ ����
        tameActivated = false;
    }
}