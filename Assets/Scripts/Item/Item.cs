using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://ansohxxn.github.io/unity%20lesson%203/ch5-1/
// J : MonoBehavior를 상속 받지 않으므로 오브젝트에 컴포넌트로서 붙일 수 없음
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Food,   // J : 음식
        Equipment,  // J : 장비
        Ingredient, // J : 재료
        Building,
        ETC,    // J : 기타
    }

    public string itemName; // J : 아이템의 이름
    public ItemType itemType; // J : 아이템 유형
    public Sprite itemImage; // J : 아이템의 이미지(인벤 토리 안에서 띄울)
    public GameObject itemPrefab;  // J : 아이템의 프리팹 (아이템 생성시 프리팹으로 찍어냄)
    // 추가 : location?

    /*
    // K : Item class 생성자
    public Item(string _itemName, ItemType _itemType)
    {
        this.itemName = _itemName;
        this.itemType = _itemType;
    }
    */
}

