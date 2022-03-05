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
            int count = 0; // K : 모든 아이템을 가져오는 함수 or 특정 item이 몇개 있는지 알려주는 함수 필요함
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
            // materials[i].item1 해당 아이템 인벤토리에서 -count 하는 함수
        }

        // K : 아이템 인벤토리 추가
        Item newItem = itemData.GetItemData(id);
        //Inventory.AcquireItem(newItem, 1);

        return true;
    }
}
