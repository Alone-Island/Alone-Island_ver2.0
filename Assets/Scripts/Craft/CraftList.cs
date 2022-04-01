using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftList : MonoBehaviour
{
    [SerializeField]
    private CraftManager craftManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // 마우스 왼쪽 버튼을 뗄 때의 처리
            craftManager.MakeNewItem(0);
        }
    }

}
