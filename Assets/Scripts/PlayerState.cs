using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // �÷��̾� ����
    private Level water = new Level(1, 1, 100f, 1f);        // N : ����
    private Level nutrition = new Level(1, 1, 100f, 1f);    // N : ����
    private Level temperature = new Level(1, 1, 100f, 1f);  // N : ü��
    private Level happy = new Level(1, 1, 100f, 1f);        // N : �ູ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
