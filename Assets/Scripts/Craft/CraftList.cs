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
            // ���콺 ���� ��ư�� �� ���� ó��
            craftManager.MakeNewItem(0);
        }
    }

}
