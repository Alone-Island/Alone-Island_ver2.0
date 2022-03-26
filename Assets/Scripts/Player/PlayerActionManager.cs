using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-1/
public class PlayerActionManager : MonoBehaviour
{
    [SerializeField]
    private float range;    // J : �������� ���� ���� ����

    private bool pickupActivated = false;  // J : ������ ���� ���� ����
    private bool huntActivated = false;  // J : ��� ���� ����

    private RaycastHit2D hitInfo; // J : �浹ü�� ����

    [SerializeField]
    private LayerMask itemLayerMask;    // J : Item ���̾ ������ ������Ʈ�� �����ؾ� ��
    [SerializeField]
    private LayerMask animalLayerMask;    // J : animal ���̾ ������ ������Ʈ�� �����ؾ� ��

    // �ʿ��� ������Ʈ
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
        Debug.DrawRay(transform.position, thePlayerMove.dirVec * range, Color.green);   // J : ������ ���� ���� ���� ǥ��
        TryAction();
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
            Debug.Log(hitInfo.transform.gameObject.name + "��(��) ������!");
            // �� ��ȯ
            huntActivated = false;
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
}
