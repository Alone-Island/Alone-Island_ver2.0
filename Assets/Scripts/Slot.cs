using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-2/
// J : �κ��丮 ���� 1���� ���� ����
public class Slot : MonoBehaviour
{
    public Item item;       // J : ȹ�� ������
    public int itemCount;   // J : ȹ���� ������ ����
    public Image itemImage; // J : �κ��丮�� ���� ������ �̹���

    // J : ������ ���� ǥ�ÿ� �ʿ��� ������Ʈ
    [SerializeField]
    private Text itemCountText;
    [SerializeField]
    private GameObject itemCountImage;

    // J : ������ �̹����� ���� ����
    private void SetAlpha(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // J : ���Կ� ���ο� ������ �߰�
    // J : ������ ������ default ���� 1
    public void AddItem(Item _item, int _count=1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        // J : ��� �������� �ƴ϶�� ������ ���� ǥ��
        if (item.itemType!=Item.ItemType.Equipment)
        {
            itemCountImage.SetActive(true);
            itemCountText.text = itemCount.ToString();
        }
        else    // J : ��� �������̸� ������ ���� ǥ�� X
        {
            itemCountText.text = "0";
            itemCountImage.SetActive(false);
        }

        SetAlpha(1);    // J : ������ �̹����� ���̰�
    }

    // J : �̹� ������ �ִ� �������� ȹ�� or ����� ���
    // J : ������ ���� ������Ʈ
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        itemCountText.text = itemCount.ToString();

        // �������� ��� ����� ���
        if (itemCount <= 0)
            ClearSlot();
    }

    // J : �ش� ���Կ� �ִ� �������� ��� ����� ���
    // J : ���� �ʱ�ȭ
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetAlpha(0);    // J : ������ �̹��� �Ⱥ��̰�

        // J : ������ ���� ǥ�� X
        itemCountText.text = "0";
        itemCountImage.SetActive(false);
    }
}
