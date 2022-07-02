using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    // 필요한 컴포넌트
    [SerializeField]
    private BuildingData buildingData;
    private Inventory theInventory;

    // Start is called before the first frame update
    void Start()
    {
        theInventory = FindObjectOfType<Inventory>();
    }

    // @@ 함수명 추후 변경 필요 (건축 가능한지 체크하는 기능을 하는 함수가 여러개, 함수명 모호) @@
    // 인벤토리에 필요한 재료가 모두 있으면 재료 리스트 리턴, 아니면 null 리턴
    private List<BuildingData.Items> CheckBuild(Item _building)
    {
        List<BuildingData.Items> materials = buildingData.GetBuildingMaterialsData(_building);  // 해당 건축물을 만드는데 필요한 재료 리스트 받아오기

        foreach (BuildingData.Items material in materials)  // 재료, 재료의 개수 확인 작업
            if (material.num < theInventory.GetItemCount(material.item))    // 인벤토리에 재료의 개수가 필요 개수보다 적다면 만들기 불가능
                return null;

        return materials;   // 만들기 가능하면 재료 리스트 리턴
    }

    // @@ 함수명 추후 변경 필요 @@
    // 건축물 만들기 가능 여부 리턴
    public bool MakeNewBuilding(Item _building)
    {
        List<BuildingData.Items> materials = CheckBuild(_building);

        if (materials == null)  // 인벤토리에 존재하는 아이템들로는 _building 만들기 불가능
        {
            Debug.Log(_building.itemName + " 건설 불가, 해당 건물 비활성화 혹은 드래그드랍 시 불가능 모달 띄우기");
            return false;
        }

        // 인벤토리의 재료 아이템 소비
        foreach (BuildingData.Items material in materials)
            theInventory.ConsumeItem(material.item, material.num);
        Debug.Log(_building.itemName + " 건설 가능, 해당 건물 활성화 혹은 드래그드랍 시 건설 성공 시키기");
        // TODO : 지어진 건축물 정보(name, location) 저장하기
        return true;
    }
}
