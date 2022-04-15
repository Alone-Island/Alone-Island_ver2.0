using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInfo : MonoBehaviour, IPointerClickHandler
{
    public Item item;     // J : 어떤 아이템을 표시중인지
    public int count;     // J : 아이템 개수

    private float doubleClickSecond = 0.25f;
    private float lastClickTime;

    // 필요한 컴포넌트
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
