using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "Animal")]
public class Animal : ScriptableObject
{
    public string koreanName;   // J : ���� �̸�
    public string englishName;  // J : ���� ������ �̸�
    public int hp;
    public List<Item> huntingItems;    // J : ��� �� �÷��̾ ��� ������ ����Ʈ
    public List<FoodItem.FoodType> preferFoods; // J : ������ �����ϴ� ���� ����
}
