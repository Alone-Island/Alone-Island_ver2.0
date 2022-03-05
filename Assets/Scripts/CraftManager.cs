using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    private ItemData itemData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<Tuple<int, int>> CheckCanMakeThisItem(int id)
    {
        List<Tuple<int, int>> materials = itemData.GetItemMaterialsData(id);
        for (int i = 0; i < materials.Count; i++)
        {
            int count = 0; // K : ��� �������� �������� �Լ� or Ư�� item�� � �ִ��� �˷��ִ� �Լ� �ʿ���
            if (count < materials[i].Item2)
            {
                return null;
            }
        }
        return materials;
    }

    public bool MakeNewItem(int id)
    {
       List<Tuple<int, int>> materials = CheckCanMakeThisItem(id);
       if (materials == null)
        {
            return false;
        }

        for (int i = 0; i < materials.Count; i++)
        {
            // materials[i].item1 �ش� ������ �κ��丮���� -count �ϴ� �Լ�
        }

        // K : ������ �κ��丮 �߰�
        Item newItem = itemData.GetItemData(id);
        //Inventory.AcquireItem(newItem, 1);

        return true;
    }
}
