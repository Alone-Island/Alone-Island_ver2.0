using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{

    [SerializeField]
    private Inventory theInventory;
    [SerializeField]
    private ItemData itemData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<Tuple<int, string, int>> CheckCanMakeThisItem(int id)
    {
        List<Tuple<int, string, int>> materials = itemData.GetItemMaterialsData(id);
        for (int i = 0; i < materials.Count; i++)
        {
            Item item = itemData.GetItemData(id);
            int count = theInventory.GetItemCount(item.name); // K : ��� �������� �������� �Լ� or Ư�� item�� � �ִ��� �˷��ִ� �Լ� �ʿ���
            if (count < materials[i].Item3)
            {
                return null;
            }
        }
        return materials;
    }

    public bool MakeNewItem(int id)
    {
        List<Tuple<int, string, int>> materials = CheckCanMakeThisItem(id);
        Item newItem = itemData.GetItemData(id);
        if (materials == null)
        {
            Debug.Log(newItem.itemName + " ȹ�� ����");
            return false;
        }

        for (int i = 0; i < materials.Count; i++)
        {
            // materials[i].item1 �ش� ������ �κ��丮���� -count �ϴ� �Լ�, - materials[i].Item3
            theInventory.ConsumeItem(materials[i].Item2, materials[i].Item3);
        }

        // K : ������ �κ��丮 �߰�
        Debug.Log(newItem.itemName + " ȹ�� ����");
        theInventory.AcquireItem(newItem);    // J : �κ��丮�� ���Կ� ������ �߰�


        return true;
    }
}
