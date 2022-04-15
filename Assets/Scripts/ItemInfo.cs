using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInfo : MonoBehaviour, IPointerClickHandler
{
    public Item item;     // J : � �������� ǥ��������
    public int count;     // J : ������ ����

    private float doubleClickSecond = 0.25f;
    private float lastClickTime;

    // �ʿ��� ������Ʈ
    private RearManager theRearManager;
    private void Start()
    {
        theRearManager = FindObjectOfType<RearManager>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Mathf.Abs(Time.time - lastClickTime) < doubleClickSecond)
        {
            theRearManager.DropFood(item, count);
            lastClickTime = -1;
        }
        else
        {
            lastClickTime = Time.time;
        }
    }
}
