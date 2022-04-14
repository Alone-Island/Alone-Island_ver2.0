using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-2/
// �κ��丮â ����
public class Inventory : MonoBehaviour
{
    private bool inventoryActivated = false;    // J : ���� �κ��丮 â�� ���� (Ȱ��ȭ/��Ȱ��ȭ)

    // J : �ʿ��� ������Ʈ
    [SerializeField]
    private GameObject inventoryImage;  // J : �κ��丮 �̹���
    [SerializeField]
    private GameObject slotsParent;     // J : ���Ե��� �θ� ������Ʈ (Grid Setting)

    private Slot[] slots;   // J : ���Ե� �迭

    private void Start()
    {
        // J : �ڽ� ������Ʈ(����)�� Slot ������Ʈ���� ������
        slots=slotsParent.GetComponentsInChildren<Slot>();
    }

    void Update()
    {
        TryOpenInventory();
    }

    // J : �κ��丮â ���� �õ�
    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;
            if (inventoryActivated)
                OpenInventory();
            else
                CloseInventory();
        }

    }

    // J : �κ��丮 ����
    private void OpenInventory()
    {
        inventoryImage.SetActive(true); // J : �κ��丮 �̹��� Ȱ��ȭ
    }

    // J : �κ��丮 �ݱ�
    private void CloseInventory()
    {
        inventoryImage.SetActive(false);     // J : �κ��丮 �̹��� ��Ȱ��ȭ
    }

    // J : ������ ȹ��
    public void AcquireItem(Item _item, int _count=1)
    {
        // J : ��� �������� �ƴ� ���
        if (_item.itemType!= Item.ItemType.Equipment)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                // J : ���Կ� �̹� �ִ� �����۰� �����ϴٸ� ���� ������Ʈ
                if ((slots[i].item != null) && (slots[i].item.itemName==_item.itemName))
                {
                    slots[i].SetSlotCount(_count);
                    return;
                }
            }
        }

        // J : ��� �������̰ų� ���Կ� �������� �ʴ� ���ο� �������� ���
        for (int i = 0; i < slots.Length; i++)
        {
            // J : �������� ������� ���� ���Կ� �߰�
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }

    // J : ������ �Һ� �����ϸ� true, �����ϸ� false ��ȯ
    public bool ConsumeItem(string _itemName, int _count)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if ((slots[i].item != null) && (slots[i].item.itemName == _itemName))
            {
                if (slots[i].itemCount < _count)    // J : ������ ������ ������ �� ������ �Һ� �Ұ���
                    return false;
                else
                {
                    slots[i].SetSlotCount(_count);  // J : ������ �Һ�
                    return true;
                }
            }
        }
        // J : �ش� �������� �κ��丮�� ���� ��� �Һ� �Ұ���
        return false;
    }

    // J : �κ��丮�� �����ϴ� itemName�� ���� ��ȯ
    public int GetItemCount(string _itemName)
    {
        int itemCount = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if ((slots[i].item != null) && (slots[i].item.itemName == _itemName))
            {
                itemCount++;
            }
        }
        return itemCount;
    }

    // J : Ư�� ItemType�� ������ ����Ʈ�� ��ȯ
    public Dictionary<Item, int> GetTypeItemList(Item.ItemType type)
    {
        Dictionary<Item, int> itemList = new Dictionary<Item, int>();
        for (int i = 0; i < slots.Length; i++)
        {
            if ((slots[i].item != null) && (slots[i].item.itemType== type))
            {
                itemList.Add(slots[i].item, GetItemCount(slots[i].item.itemName));
            }
        }
        return itemList;
    }
}
