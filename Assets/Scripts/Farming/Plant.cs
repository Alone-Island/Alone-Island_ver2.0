using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Plant : ScriptableObject
{
    private string name;        // N : �۹� �̸�
    public Level level;         // N : �۹� ����
    private float growthSpeed;  // N : ���� �ӵ�
    private float yield;        // N : ��Ȯ��
    private int season;       // N : ��� ���� ����

    public Plant(string name, float growthSpeed, float yield, int season)
    {
        this.name = name;
        level = new Level(1, 5, 1, 1);
        this.growthSpeed = growthSpeed;
        this.yield = yield;
        this.season = season;
    }

    // N : �б� ����
    public string Name { get { return name; } }
    public float GrowthSpeed { get { return growthSpeed; } }
    public float Yield { get { return yield; } }
}
