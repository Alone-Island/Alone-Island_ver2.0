using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        // J : Canvas ������Ʈ�� �ߺ� ���� ����
        var obj = FindObjectsOfType<Canvas>(); 
        if (obj.Length == 1) 
            DontDestroyOnLoad(gameObject);  // J : �κ��丮 ������ ������ ���� ���� �̵��ص� ĵ���� ����
        else 
            Destroy(gameObject);
    }
}
