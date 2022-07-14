using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    // �ʿ��� ������Ʈ
    [SerializeField]
    private static CraftManager _instance;

    public ItemData ItemData;
    private Inventory Inventory;

    public GameObject CraftContent;
    public GameObject CraftComplete;
    public List<ItemData.ItemDictionary> itemData;

    // Start is called before the first frame update
    private void Start()
    {
        Inventory = FindObjectOfType<Inventory>();
        ItemData = FindObjectOfType<ItemData>();

        //ItemData.GenerateData();

        itemData = ItemData.GenerateData();
        // J : ���� ������ �߰� (����)
        //itemData = ItemData.itemData;

       
    }

    private void Update()
    {
    }
    public CraftManager Instance()
    {
        Init();
        return _instance;
    }
    private void Init()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<CraftManager>();
        }
    }

    // K : �κ��丮�� �ʿ��� ��ᰡ ��� ������ ��� ����Ʈ ����, �ƴϸ� null ����
    public Boolean CheckCanMakeItem(List<ItemData.Items> materials) {
        //List<ItemData.Items> materials = ItemData.GetItemMaterialsData(_item);  // J : �������� ����µ� �ʿ��� ��� ����Ʈ �޾ƿ���

        foreach (ItemData.Items material in materials)
        { // J : ��� + ����� ����
            if (material.num > Inventory.GetItemCount(material.item))    // J : �κ��丮�� ����� ������ �ʿ� �������� ���ٸ� ����� �Ұ���
                return false;
        }

        return true;   // J : ����� �����ϸ� ��� ����Ʈ ����
    }

    // K : ������ ����� ���� ���� ����
    public bool MakeNewItem(ItemData.ItemDictionary _item) {
        if (!CheckCanMakeItem(_item.materials))  // J : �κ��丮�� �����ϴ� �����۵�δ� _item ����� �Ұ���
        {
            Debug.Log(_item.item.name + " ȹ�� ����");
            return false;
        }

        // J : �κ��丮�� ��� ������ �Һ�
        foreach (ItemData.Items material in _item.materials)
            Inventory.ConsumeItem(material.item, material.num);
        Inventory.AcquireItem(_item.item);    // K : �κ��丮�� ���Կ� ������ �߰�
        Debug.Log(_item.item.name + " ȹ�� ����");

        return true;
    }
}
