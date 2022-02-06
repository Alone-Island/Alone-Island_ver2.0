using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-1/
public class PlayerActionManager : MonoBehaviour
{
    [SerializeField]
    private float range;    // J : �������� �ֿ� �� �ִ� ����

    private bool pickupActivated = false;  // J : ������ ���� ���� ����

    private RaycastHit hitInfo; // J : �浹ü�� ����

    [SerializeField]
    private LayerMask layerMask;    // J : Item ���̾ ������ ������Ʈ�� �����ؾ� ��


    // Update is called once per frame
    void Update()
    {
        TryAction();
    }

    // J : Ư�� �ൿ �õ�
    private void TryAction()
    {
        // J : EŰ�� ������ ��
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();    // J : �÷��̾ �ֿ� �� �ִ� �������� �ִ��� Ȯ��
            CanPickUp();    // J : �������� �ֿ� �� ������ �ݱ�
        }
    }

    // J : �÷��̾ �ֿ� �� �ִ� �������� �ִ��� Ȯ��
    private void CheckItem()
    {
        // J : �÷��̾��� �տ� ���� ���� ���� �ִ� ���� ������Ʈ�� ������ hitInfo�� ����
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")    // J : ������Ʈ�� tag�� Item
            {
                pickupActivated = true;
            }
            else
                pickupActivated = false;
        }
    }

    // J : �������� �ֿ� �� ������ �ݱ�
    private void CanPickUp()
    {
        if (pickupActivated)    // J : �������� �ֿ� �� �ִ� ����
        {
            Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "�� ȹ��");
            // J : �κ��丮�� ������ �߰��ϴ� �Լ�
            Destroy(hitInfo.transform.gameObject);  // J : �ֿ����Ƿ� ������Ʈ ����
        }
    }
}
