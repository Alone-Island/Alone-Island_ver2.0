using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // �÷��̾� ����
    private Level water = new(1, 1, 100, 1);        // N : ����
    private Level nutrition = new(1, 1, 100, 1);    // N : ����
    private Level temperature = new(1, 1, 100, 1);  // N : ü��
    private Level happy = new(1, 1, 100, 1);        // N : �ູ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
