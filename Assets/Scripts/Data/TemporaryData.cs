using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryData : MonoBehaviour
{
    // J : ���� ���� �߿��� ������ ������
    public static Animal encounterAnimal;

    private void Awake()
    {
        // J : TemporaryData ������Ʈ�� �ߺ� ���� ����
        var obj = FindObjectsOfType<TemporaryData>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
