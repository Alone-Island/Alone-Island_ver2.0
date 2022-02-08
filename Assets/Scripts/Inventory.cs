using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-2/
public class Inventory : MonoBehaviour
{
    private bool inventoryActivated = false;    // J : ���� �κ��丮 â�� ���� (Ȱ��ȭ/��Ȱ��ȭ)

    // J : �ʿ��� ������Ʈ
    [SerializeField]
    private GameObject inventoryImage;  // J : �κ��丮 �̹���

    // Update is called once per frame
    void Update()
    {
        TryOpenInventory();
    }

    // J : �κ��丮â ���� �õ�
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

    // J : �κ��丮 ����
    private void OpenInventory()
    {
        inventoryImage.SetActive(true); // J : �κ��丮 �̹��� Ȱ��ȭ
    }

    // J : �κ��丮 �ݱ�
    private void CloseInventory()
    {
        inventoryImage.SetActive(false);     // J : �κ��丮 �̹��� ��Ȱ��ȭ
    }
}
