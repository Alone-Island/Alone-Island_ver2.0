using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // 플레이어 스탯
    private Level water = new Level(1, 1, 100f, 1f);        // N : 수분
    private Level nutrition = new Level(1, 1, 100f, 1f);    // N : 영양
    private Level temperature = new Level(1, 1, 100f, 1f);  // N : 체온
    private Level happy = new Level(1, 1, 100f, 1f);        // N : 행복

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
