using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]  // J : ����ȭ�� Data
public class TemporaryData : MonoBehaviour
{
    // J : ���� ���� �߿��� ������ ������
    public Animal encounterAnimal;

    /*
    private void Awake()
    {
        // J : TemporaryData ������Ʈ�� �ߺ� ���� ����
        var obj = FindObjectsOfType<TemporaryData>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
    */
}
