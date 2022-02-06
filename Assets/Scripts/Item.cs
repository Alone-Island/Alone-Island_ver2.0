using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://ansohxxn.github.io/unity%20lesson%203/ch5-1/
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Used,   // J : 소모품
        Equipment,  // J : 장비
        Ingredient, // J : 재료
        ETC,    // J : 기타
    }

    public string itemName; // J : 아이템의 이름
    public ItemType itemType; // J : 아이템 유형
    public Sprite itemImage; // J : 아이템의 이미지(인벤 토리 안에서 띄울)
    public GameObject itemPrefab;  // J : 아이템의 프리팹 (아이템 생성시 프리팹으로 찍어냄)

    public string weaponType;  // J : 무기 유형
}
