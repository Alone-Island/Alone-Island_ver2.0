using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-2/
// J : 인벤토리 슬롯 1개에 대한 관리
public class Slot : MonoBehaviour
{
    public Item item;       // J : 획득 아이템
    public int itemCount;   // J : 획득한 아이템 개수
    public Image itemImage; // J : 인벤토리에 보일 아이템 이미지

    // J : 아이템 개수 표시에 필요한 컴포넌트
    [SerializeField]
    private Text itemCountText;
    [SerializeField]
    private GameObject itemCountImage;

    // J : 아이템 이미지의 투명도 조절
    private void SetAlpha(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // J : 슬롯에 새로운 아이템 추가
    // J : 아이템 개수의 default 값은 1
    public void AddItem(Item _item, int _count=1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        // J : 장비 아이템이 아니라면 아이템 개수 표시
        if (item.itemType!=Item.ItemType.Equipment)
        {
            itemCountImage.SetActive(true);
            itemCountText.text = itemCount.ToString();
        }
        else    // J : 장비 아이템이면 아이템 개수 표시 X
        {
            itemCountText.text = "0";
            itemCountImage.SetActive(false);
        }

        SetAlpha(1);    // J : 아이템 이미지가 보이게
    }

    // J : 이미 가지고 있는 아이템을 획득 or 사용한 경우
    // J : 아이템 개수 업데이트
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        itemCountText.text = itemCount.ToString();

        // 아이템을 모두 사용한 경우
        if (itemCount <= 0)
            ClearSlot();
    }

    // J : 해당 슬롯에 있던 아이템을 모두 사용한 경우
    // J : 슬롯 초기화
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetAlpha(0);    // J : 아이템 이미지 안보이게

        // J : 아이템 개수 표시 X
        itemCountText.text = "0";
        itemCountImage.SetActive(false);
    }
}
