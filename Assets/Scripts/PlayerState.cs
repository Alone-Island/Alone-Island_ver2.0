using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // player로 클래스명 변경 필요

    // N : 플레이어 스탯
    private Level water = new Level(1, 1, 100f, 1f);        // N : 수분
    private Level nutrition = new Level(1, 1, 100f, 1f);    // N : 영양
    private Level temperature = new Level(1, 1, 100f, 1f);  // N : 체온
    private Level happy = new Level(1, 1, 100f, 1f);        // N : 행복
}
