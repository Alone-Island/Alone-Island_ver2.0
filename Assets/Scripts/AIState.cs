using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    // AI 레벨
    private Level farming = new Level(1, 10, 10f, 1.5f);     // N : 농사
    private Level hunting = new Level(1, 10, 10f, 1.5f);     // N : 사냥
    private Level raising = new Level(1, 10, 10f, 1.5f);     // N : 목축
    private Level building = new Level(1, 10, 10f, 1.5f);    // N : 건축
    private Level crafting = new Level(1, 10, 10f, 1.5f);    // N : 공예
    private Level engineering = new Level(1, 10, 10f, 1.5f); // N : 공학
    private Level hearting = new Level(1, 10, 10f, 1.5f);    // N : 공감

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
