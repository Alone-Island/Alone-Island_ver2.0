using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    // AI ����
    private Level farming = new Level(1, 10, 10f, 1.5f);     // N : ���
    private Level hunting = new Level(1, 10, 10f, 1.5f);     // N : ���
    private Level raising = new Level(1, 10, 10f, 1.5f);     // N : ����
    private Level building = new Level(1, 10, 10f, 1.5f);    // N : ����
    private Level crafting = new Level(1, 10, 10f, 1.5f);    // N : ����
    private Level engineering = new Level(1, 10, 10f, 1.5f); // N : ����
    private Level hearting = new Level(1, 10, 10f, 1.5f);    // N : ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
