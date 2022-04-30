using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "Animal")]
public class Animal : ScriptableObject
{
    public string koreanName;   // J : 동물 이름
    public string englishName;  // J : 동물 프리팹 이름
    public int hp;
    public List<Item> huntingItems;    // J : 사냥 시 플레이어가 얻는 아이템 리스트
    public List<FoodItem.FoodType> preferFoods; // J : 동물이 좋아하는 음식 유형
}
