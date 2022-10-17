using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    // �ʿ��� ������Ʈ
    [SerializeField]
    private static BuildingManager _instance;

    private BuildingData BuildingData;
    private Inventory Inventory;

    // public GameObject BuildingContent;
    public GameObject BuildingFail;
    public Dictionary<string, BuildingData.Building> buildingData;

    // Start is called before the first frame update
    void Start()
    {
        Inventory = FindObjectOfType<Inventory>();
        BuildingData = FindObjectOfType<BuildingData>();

        buildingData = BuildingData.GenerateData();
    }

    public BuildingManager Instance()
    {
        Init();
        return _instance;
    }

    private void Init()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<BuildingManager>();
        }
    }



    // @@ �Լ��� ���� ���� �ʿ� (���� �������� üũ�ϴ� ����� �ϴ� �Լ��� ������, �Լ��� ��ȣ) @@
    // �κ��丮�� �ʿ��� ��ᰡ ��� ������ ��� ����Ʈ ����, �ƴϸ� null ����
    public bool CheckHaveBuildingMaterials(List<BuildingData.Items> materials)
    {
        foreach (BuildingData.Items material in materials)  // ���, ����� ���� Ȯ�� �۾�
        {
            if (material.num > Inventory.GetItemCount(material.item))    // �κ��丮�� ����� ������ �ʿ� �������� ���ٸ� ����� �Ұ���
                return false;
        }
            
        return true;   // ����� �����ϸ� true ����
    }

    // @@ �Լ��� ���� ���� �ʿ� @@
    // ���๰ ����� ���� ���� ����
    public bool MakeNewBuilding(BuildingData.Building _building)
    {
        if (!CheckHaveBuildingMaterials(_building.materials))  // �κ��丮�� �����ϴ� �����۵�δ� _building ����� �Ұ���
        {
            Debug.Log(_building.building.name + " �Ǽ� �Ұ�, �ش� �ǹ� �׸� ȸ��ó��, Ŭ�� ��Ȱ��ȭ");
            return false;
        }

        /*
        // �κ��丮�� ��� ������ �Һ�
        foreach (BuildingData.Items material in _building.materials)
            Inventory.ConsumeItem(material.item, material.num);
        */
        Debug.Log(_building.building.name + " �Ǽ� ����, �ش� �ǹ� Ȱ��ȭ, �巡�׵�� ����");
        // TODO : ������ ���๰ ����(name, location) �����ϱ�
        return true;
    }


    // ���๰ �巡�׾ص�� �� �Ǽ� ���� �� �ʿ��ߴ� ���� �Һ�, �Һ� �����ϸ� true ����
    public bool FinalConsume(BuildingData.Building _building)
    {
        // �κ��丮�� ��� ������ �Һ�
        foreach (BuildingData.Items material in _building.materials)
            Inventory.ConsumeItem(material.item, material.num);
        Debug.Log(_building.building.name + " �Ǽ� ����, ��� ���� �Ϸ�");

        return true;
    }
}
