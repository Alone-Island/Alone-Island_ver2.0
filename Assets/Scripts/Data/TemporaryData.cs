using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// J : ���� ���� �߿��� ������ ������
[Serializable]  // J : ����ȭ�� Data
public class TemporaryData : SaveData
{
    public int test2 = 0;
    public Animal encounterAnimal;

    public List<AnimalInfo> animalInfoList = new List<AnimalInfo>();

    private void Awake()
    {
        /*
        // J : TemporaryData ������Ʈ�� �ߺ� ���� ����
        var obj = FindObjectsOfType<TemporaryData>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
        */
    }
}
