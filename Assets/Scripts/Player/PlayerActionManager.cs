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

    [SerializeField]
    private LayerMask itemLayerMask;    // J : Item ���̾ ������ ������Ʈ�� �����ؾ� ��
    [SerializeField]
    private LayerMask animalLayerMask;    // J : animal ���̾ ������ ������Ʈ�� �����ؾ� ��
    [SerializeField]
    private LayerMask myAnimalLayerMask;    // N : MyAnimal ���̾ ������ ������Ʈ��

    // �ʿ��� ������Ʈ
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

        DontDestroyOnLoad(gameObject);      // �÷��̾� ����
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
        Debug.DrawRay(transform.position, thePlayerMove.dirVec * range, Color.green);   // J : ������ ���� ���� ���� ǥ��
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
                Debug.Log("������");
                SceneManager.LoadScene("Farm");
            }
            else if (collision.gameObject.name == "ToForest")
            {
                Debug.Log("������");
                SceneManager.LoadScene("TestJ_hunt");
            }
            else if (collision.gameObject.name == "ToBeach")
            {
                Debug.Log("�غ����� / �� ����");
                SceneManager.LoadScene("Beach");
            }
            else if (collision.gameObject.name == "ToGrassland")
            {
                Debug.Log("�ʿ�����");
                SceneManager.LoadScene("Taming");
            }
            else if (collision.gameObject.name == "ToLabInSide")
            {
                Debug.Log("������ ������");
                SceneManager.LoadScene("TestK_DoctorLab");
            }
            else if (collision.gameObject.name == "ToLabOutSide")
            {
                Debug.Log("������ ������");
                SceneManager.LoadScene("TestK_Start");
            }
            else if (collision.gameObject.name == "ToMain")
            {
                Debug.Log("���� ȭ��");
                SceneManager.LoadScene("TestK_Start");
            }
        }
        else if (collision.gameObject.tag == "Work")
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
        CheckAnimal();
        CanHunt();
        // J : EŰ�� ������ ��
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();    // J : �÷��̾ �ֿ� �� �ִ� �������� �ִ��� Ȯ��
            CanPickUp();    // J : �������� �ֿ� �� ������ �ݱ�
        }

        if (CheckMyAnimal())
        {
            CanTame();
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
        if (hitInfo.collider != null)
        {
            if (hitInfo.transform.tag == "Animal")    // N : ������Ʈ�� MyAnimal
            {
                tameActivated = true;               // ���� ����
            }
            else
                tameActivated = false;              // ���� �Ұ�
        }

        return tameActivated;
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
        if (tameActivated)
        {
            Debug.Log(hitInfo.transform.gameObject.name + " �Ⱦ��ֱ� / ���ٵ�� / �����ֱ�");
            tameActivated = false;
        }
    }
}
