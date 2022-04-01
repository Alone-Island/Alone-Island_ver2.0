using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Plant : ScriptableObject
{
    private string name;        // N : 작물 이름
    public Level level;         // N : 작물 레벨
    private float growthSpeed;  // N : 성장 속도
    private float yield;        // N : 수확량
    private int season;       // N : 재배 가능 계절

    public Plant(string name, float growthSpeed, float yield, int season)
    {
        this.name = name;
        level = new Level(1, 5, 1, 1);
        this.growthSpeed = growthSpeed;
        this.yield = yield;
        this.season = season;
    }

    // N : 읽기 전용
    public string Name { get { return name; } }
    public float GrowthSpeed { get { return growthSpeed; } }
    public float Yield { get { return yield; } }
}
