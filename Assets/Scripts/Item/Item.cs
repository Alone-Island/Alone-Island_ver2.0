using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-1/
// J : MonoBehavior�� ��� ���� �����Ƿ� ������Ʈ�� ������Ʈ�μ� ���� �� ����
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Used,   // J : �Ҹ�ǰ
        Equipment,  // J : ���
        Ingredient, // J : ���
        ETC,    // J : ��Ÿ
    }

    public string itemName; // J : �������� �̸�
    public ItemType itemType; // J : ������ ����
    public Sprite itemImage; // J : �������� �̹���(�κ� �丮 �ȿ��� ���)
    public GameObject itemPrefab;  // J : �������� ������ (������ ������ ���������� ��)

    public string weaponType;  // J : ���� ����

    // K : Item class ������
    public Item(string _itemName, ItemType _itemType)
    {
        this.itemName = _itemName;
        this.itemType = _itemType;
    }
}