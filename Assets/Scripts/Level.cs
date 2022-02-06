using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int currLv;     // N : 현재 레벨
    private int currExp;    // N : 현재 경험치
    private int subLv;      // N : 현재 레벨 - 이전 레벨 (0이면 레벨 변화 없음)
    private int maxLv;      // N : 최대 레벨
    private int maxExp;     // N : 현재 레벨에서의 최대 경험치
    private int expRate;    // N : 레벨 당 경험치 증가율
    private bool isMax;     // N : 현재 레벨 == 최대 레벨이면 true 

    public Level(int initLv, int maxLv, int expToNextLv, int expRate)
    {
        currLv = initLv;
        currExp = 0;
        subLv = 0;
        this.maxLv = maxLv;
        maxExp = expToNextLv;                       // N : 현재 레벨에서의 최대 경험치 (레벨 업 하기 위해 필요한 경험치)
        this.expRate = expRate;
        isMax = (currLv == maxLv) ? true : false;
    }

    // 경험치 상승
    public void AddExp(int exp)
    {
        currExp = currExp + exp;
        // 레벨 업
        if (currExp >= maxExp && isMax == false)
        {
            LevelUp();
        }
        else subLv = 0;
    }

    // 경험치 하락
    public void SubExp(int exp)
    {
        currExp = currExp - exp;
        // 레벨 다운
        if (currExp <= 0 && currLv > 0)
        {
            LevelDown();
        }
        else subLv = 0;
    }

    // 레벨 업
    public void LevelUp()
    {
        while (currExp >= maxExp && isMax == false)
        {
            // 레벨 업
            currLv++;
            subLv++;

            // 경험치 리셋
            currExp = currExp - maxExp;
            maxExp = maxExp * expRate;  // 최대 경험치 변경

            if (currLv == maxLv) isMax = true;
        }
    }

    // 레벨 다운
    public void LevelDown()
    {
        while (currExp >= maxExp && isMax == false)
        {
            // 레벨 다운
            currLv--;
            subLv--;

            // 경험치 리셋
            maxExp = maxExp / expRate;  // 최대 경험치 변경
            currExp = currExp + maxExp;
        }
    }

    // N : 스탯 초기화
    public void InitStat(int initLv, int maxLv, int expToNextLv, int expRate)
    {
        currLv = initLv;
        currExp = 0;
        subLv = 0;
        this.maxLv = maxLv;
        maxExp = expToNextLv;
        this.expRate = expRate;
        isMax = (currLv == maxLv) ? true : false;
    }
}