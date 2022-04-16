using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        // J : Canvas 오브젝트의 중복 생성 방지
        var obj = FindObjectsOfType<Canvas>(); 
        if (obj.Length == 1) 
            DontDestroyOnLoad(gameObject);  // J : 인벤토리 데이터 유지를 위해 씬을 이동해도 캔버스 유지
        else 
            Destroy(gameObject);
    }
}
