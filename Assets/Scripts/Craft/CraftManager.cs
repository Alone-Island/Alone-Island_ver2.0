using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    // �ʿ��� ������Ʈ
    [SerializeField]
    private ItemData itemData;
    private Inventory theInventory;

    // Start is called before the first frame update
    void Start()
    {
        theInventory = FindObjectOfType<Inventory>();
        itemData = FindObjectOfType<ItemData>();

        
    }

    // K : �κ��丮�� �ʿ��� ��ᰡ ��� ������ ��� ����Ʈ ����, �ƴϸ� null ����
    private List<ItemData.Items> CheckMakeItem(Item _item) {
        List<ItemData.Items> materials = itemData.GetItemMaterialsData(_item);  // J : �������� ����µ� �ʿ��� ��� ����Ʈ �޾ƿ���

        foreach (ItemData.Items material in materials)  // J : ��� + ����� ����
            if (material.num < theInventory.GetItemCount(material.item))    // J : �κ��丮�� ����� ������ �ʿ� �������� ���ٸ� ����� �Ұ���
                return null;

        return materials;   // J : ����� �����ϸ� ��� ����Ʈ ����
    }

    // K : ������ ����� ���� ���� ����
    public bool MakeNewItem(Item _item) {
        List<ItemData.Items> materials = CheckMakeItem(_item);

        if (materials == null)  // J : �κ��丮�� �����ϴ� �����۵�δ� _item ����� �Ұ���
        {
            Debug.Log(_item.itemName + " ȹ�� ����");
            return false;
        }

        // J : �κ��丮�� ��� ������ �Һ�
        foreach (ItemData.Items material in materials)
            theInventory.ConsumeItem(material.item, material.num);
        theInventory.AcquireItem(_item);    // K : �κ��丮�� ���Կ� ������ �߰�
        Debug.Log(_item.itemName + " ȹ�� ����");

        return true;
    }
}
