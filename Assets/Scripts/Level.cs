using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int currLv;     // N : 현재 레벨
    private float currExp;    // N : 현재 경험치
    private int subLv;      // N : 현재 레벨 - 이전 레벨 (0이면 레벨 변화 없음)
    private int maxLv;      // N : 최대 레벨
    private float maxExp;     // N : 현재 레벨에서의 최대 경험치
    private float expRate;    // N : 레벨 당 경험치 증가율
    private bool isMax;     // N : 현재 레벨 >= 최대 레벨이면 true 
    private bool isZero;    // N : 현재 레벨 <= 0이면 true 

    public Level(int initLv, int maxLv, float expToNextLv, float expRate)
    {
        currLv = initLv;
        currExp = 0;
        subLv = 0;
        this.maxLv = maxLv;
        maxExp = expToNextLv;                       // N : 현재 레벨에서의 최대 경험치 (레벨 업 하기 위해 필요한 경험치)
        this.expRate = expRate;
        isMax = (currLv >= maxLv) ? true : false;
        isZero = (currLv <= 0) ? true : false;
    }

    // N : 읽기 전용
    public int CurrLv { get { return currLv; } }
    public float CurrExp { get { return currExp; } }
    public int SubLv { get { return subLv; } }
    public int MaxLv { get { return maxLv; } }
    public float MaxExp { get { return maxExp; } }
    public bool IsMax { get { return isMax; } }
    public bool IsZero { get { return isZero; } }

    // N : 경험치 상승
    public void AddExp(float exp)
    {
        currExp = currExp + exp;
        // N : 레벨 업
        if (currExp >= maxExp && isMax == false)
        {
            LevelUp();
        }
        else subLv = 0;
    }

    // N : 경험치 하락
    public void SubExp(float exp)
    {
        currExp = currExp - exp;
        // N : 레벨 다운
        if (currExp <= 0 && isZero == false)
        {
            LevelDown();
        }
        else subLv = 0;
    }

    // N : 레벨 업
    public void LevelUp()
    {
        while (currExp >= maxExp && isMax == false)
        {
            // N : 레벨 업
            currLv++;
            subLv++;

            // N : 경험치 리셋
            currExp = currExp - maxExp;
            maxExp = maxExp * expRate;  // N : 최대 경험치 변경
        }
        if (currLv == maxLv) isMax = true;
        isZero = false;
    }

    // N : 레벨 다운
    public void LevelDown()
    {
        while (currExp <= 0 && isZero == false)
        {
            // N : 레벨 다운
            currLv--;
            subLv--;

            // N : 경험치 리셋
            maxExp = maxExp / expRate;  // N : 최대 경험치 변경
            currExp = currExp + maxExp;
        }
        isMax = false;
        if (currLv == 0) isZero = true;
    }

    // N : 레벨 업 완료 (레벨 업 액션 적용 후 호출)
    public void FinishUp()
    {
        subLv--;
    }

    // N : 레벨 다운 완료 (레벨 다운 액션 적용 후 호출)
    public void FinishDown()
    {
        subLv++;
    }

    // N : 스탯 초기화
    public void InitStat(int initLv, int maxLv, float expToNextLv, float expRate)
    {
        currLv = initLv;
        currExp = 0;
        subLv = 0;
        this.maxLv = maxLv;
        maxExp = expToNextLv;
        this.expRate = expRate;
        isMax = (currLv >= maxLv) ? true : false;
        isZero = (currLv <= 0) ? true : false;
    }
}