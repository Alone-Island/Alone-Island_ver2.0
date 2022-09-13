using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject
{
    public string name;            // N : �۹� �̸�
    public Sprite[] plantStages;    // N : �ܰ躰 Sprites
    public Sprite icon;

    private Level level;             // N : �۹� ����
    private float yield;            // N : ��Ȯ��
    private int season;             // N : ��� ���� ����

    public int num;             // N : �۹� ����

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

    // N : �б� ����
    public string Name { get { return name; } }
    public float growthSpeed { get; } = 2f;
    public float Yield { get { return yield; } }
    
}
