using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData : MonoBehaviour
{
    public struct Building
    {
        public Item building;   // �������� ���๰
        public List<Items> materials;   // ���๰�� ����µ� �ʿ��� ��� ������

        public Building(Item _building, List<Items> _materials)
        {
            building = _building;
            materials = _materials;
        }
    }

    public struct Items
    {
        public Item item;   // �ʿ��� ��� ������
        public int num { get; set; }      // �ʿ��� ��� ������ ����

        public Items(Item _item, int _num)
        {
            item = _item;
            num = _num;
        }
    }

    private Dictionary<string, Building> buildingData;        // ���๰ ������ �����ϴ� dictionary ����

    void Awake()
    {
    }

    public Dictionary<string, Building> GenerateData()
    {
        buildingData = new Dictionary<string, Building>();
        buildingData.Add("Fence", new BuildingData.Building(
            Resources.Load<Item>("Item/Building/Fence"),
            new List<BuildingData.Items> {
                new BuildingData.Items(Resources.Load<Item>("Item/Food/Apple"), 1),
                new BuildingData.Items(Resources.Load<Item>("Item/Food/Banana"), 2)
            }));
        buildingData.Add("Barn", new BuildingData.Building(
            Resources.Load<Item>("Item/Building/Barn"),
            new List<BuildingData.Items> {
                new BuildingData.Items(Resources.Load<Item>("Item/Food/Apple"), 1),
                new BuildingData.Items(Resources.Load<Item>("Item/Food/Banana"), 2)
            }));
        buildingData.Add("RobotHouse", new BuildingData.Building(
            Resources.Load<Item>("Item/Building/RobotHouse"),
            new List<BuildingData.Items> {
                new BuildingData.Items(Resources.Load<Item>("Item/Food/Apple"), 1),
                new BuildingData.Items(Resources.Load<Item>("Item/Food/Banana"), 2)
            }));

        return buildingData;
    }

    public List<Items> GetBuildingMaterialsData(Item _building)         // ���๰ �Ǽ��� �ʿ��� ��� ������ ������ ����
    {
        foreach (KeyValuePair<string, Building> dict in buildingData)
            if (dict.Value.building == _building)
                return dict.Value.materials;
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
