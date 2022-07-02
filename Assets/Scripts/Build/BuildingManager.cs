using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    // �ʿ��� ������Ʈ
    [SerializeField]
    private BuildingData buildingData;
    private Inventory theInventory;

    // Start is called before the first frame update
    void Start()
    {
        theInventory = FindObjectOfType<Inventory>();
    }

    // @@ �Լ��� ���� ���� �ʿ� (���� �������� üũ�ϴ� ����� �ϴ� �Լ��� ������, �Լ��� ��ȣ) @@
    // �κ��丮�� �ʿ��� ��ᰡ ��� ������ ��� ����Ʈ ����, �ƴϸ� null ����
    private List<BuildingData.Items> CheckBuild(Item _building)
    {
        List<BuildingData.Items> materials = buildingData.GetBuildingMaterialsData(_building);  // �ش� ���๰�� ����µ� �ʿ��� ��� ����Ʈ �޾ƿ���

        foreach (BuildingData.Items material in materials)  // ���, ����� ���� Ȯ�� �۾�
            if (material.num < theInventory.GetItemCount(material.item))    // �κ��丮�� ����� ������ �ʿ� �������� ���ٸ� ����� �Ұ���
                return null;

        return materials;   // ����� �����ϸ� ��� ����Ʈ ����
    }

    // @@ �Լ��� ���� ���� �ʿ� @@
    // ���๰ ����� ���� ���� ����
    public bool MakeNewBuilding(Item _building)
    {
        List<BuildingData.Items> materials = CheckBuild(_building);

        if (materials == null)  // �κ��丮�� �����ϴ� �����۵�δ� _building ����� �Ұ���
        {
            Debug.Log(_building.itemName + " �Ǽ� �Ұ�, �ش� �ǹ� ��Ȱ��ȭ Ȥ�� �巡�׵�� �� �Ұ��� ��� ����");
            return false;
        }

        // �κ��丮�� ��� ������ �Һ�
        foreach (BuildingData.Items material in materials)
            theInventory.ConsumeItem(material.item, material.num);
        Debug.Log(_building.itemName + " �Ǽ� ����, �ش� �ǹ� Ȱ��ȭ Ȥ�� �巡�׵�� �� �Ǽ� ���� ��Ű��");
        // TODO : ������ ���๰ ����(name, location) �����ϱ�
        return true;
    }
}
