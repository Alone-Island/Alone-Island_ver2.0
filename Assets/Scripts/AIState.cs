using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    // AI ����
    private Level farming = new(1, 10, 10, (float)1.5);     // N : ���
    private Level hunting = new(1, 10, 10, (float)1.5);     // N : ���
    private Level raising = new(1, 10, 10, (float)1.5);     // N : ����
    private Level building = new(1, 10, 10, (float)1.5);    // N : ����
    private Level crafting = new(1, 10, 10, (float)1.5);    // N : ����
    private Level engineering = new(1, 10, 10, (float)1.5); // N : ����
    private Level hearting = new(1, 10, 10, (float)1.5);    // N : ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
