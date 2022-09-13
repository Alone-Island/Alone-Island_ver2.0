using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject
{
    public string name;            // N : 작물 이름
    public Sprite[] plantStages;    // N : 단계별 Sprites
    public Sprite icon;

    private Level level;             // N : 작물 레벨
    private float yield;            // N : 수확량
    private int season;             // N : 재배 가능 계절

    public int num;             // N : 작물 개수

    /*
    public Plant(string name, float growthSpeed, float yield, int season)
    {
        this.name = name;
        level = new Level(1, 5, 1, 1);
        this.growthSpeed = growthSpeed;
        this.yield = yield;
        this.season = season;
    }
    */

    // N : 읽기 전용
    public string Name { get { return name; } }
    public float growthSpeed { get; } = 2f;
    public float Yield { get { return yield; } }
    
}
