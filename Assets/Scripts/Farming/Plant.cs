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

    // N : �б� ����
    public string Name { get { return name; } }
    public float GrowthSpeed { get { return growthSpeed; } }
    public float Yield { get { return yield; } }
}
