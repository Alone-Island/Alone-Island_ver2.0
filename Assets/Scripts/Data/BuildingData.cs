using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData : MonoBehaviour
{
    public struct BuildingDictionary
    {
        public Building building;   // �������� ���๰
        public List<Items> materials;   // ���๰�� ����µ� �ʿ��� ��� ������

        public BuildingDictionary(Building _building, List<Items> _materials)
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

    private List<BuildingDictionary> buildingData;        // ���๰ ������ �����ϴ� dictionary ����

    void Awake()
    {
        GenerateData(buildingData);
    }

    void GenerateData(List<BuildingDictionary> buildingData)
    {
        buildingData = new List<BuildingDictionary>();
        // ���๰ ������ ����Ʈ�� (����)
        buildingData.Add(new BuildingDictionary(
            Resources.Load<Building>("Building/Fence"),
            new List<Items> {
                new Items(Resources.Load<Item>("Item/Food/Apple"), 1),
                new Items(Resources.Load<Item>("Item/Food/Banana"), 2)
            }));
    }

    public List<Items> GetBuildingMaterialsData(Building _building)         // ���๰ �Ǽ��� �ʿ��� ��� ������ ������ ����
    {
        foreach (BuildingDictionary dict in buildingData)
            if (dict.building == _building)
                return dict.materials;
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
