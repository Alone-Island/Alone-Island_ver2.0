using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    // AI 레벨
    private Level farming = new(1, 10, 10, (float)1.5);     // N : 농사
    private Level hunting = new(1, 10, 10, (float)1.5);     // N : 사냥
    private Level raising = new(1, 10, 10, (float)1.5);     // N : 목축
    private Level building = new(1, 10, 10, (float)1.5);    // N : 건축
    private Level crafting = new(1, 10, 10, (float)1.5);    // N : 공예
    private Level engineering = new(1, 10, 10, (float)1.5); // N : 공학
    private Level hearting = new(1, 10, 10, (float)1.5);    // N : 공감

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
