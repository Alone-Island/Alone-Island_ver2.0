using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int currLv;     // N : ���� ����
    private float currExp;    // N : ���� ����ġ
    private int subLv;      // N : ���� ���� - ���� ���� (0�̸� ���� ��ȭ ����)
    private int maxLv;      // N : �ִ� ����
    private float maxExp;     // N : ���� ���������� �ִ� ����ġ
    private float expRate;    // N : ���� �� ����ġ ������
    private bool isMax;     // N : ���� ���� >= �ִ� �����̸� true 
    private bool isZero;    // N : ���� ���� <= 0�̸� true 

    public Level(int initLv, int maxLv, float expToNextLv, float expRate)
    {
        currLv = initLv;
        currExp = 0;
        subLv = 0;
        this.maxLv = maxLv;
        maxExp = expToNextLv;                       // N : ���� ���������� �ִ� ����ġ (���� �� �ϱ� ���� �ʿ��� ����ġ)
        this.expRate = expRate;
        isMax = (currLv >= maxLv) ? true : false;
        isZero = (currLv <= 0) ? true : false;
    }

    // N : �б� ����
    public int CurrLv { get { return currLv; } }
    public float CurrExp { get { return currExp; } }
    public int SubLv { get { return subLv; } }
    public int MaxLv { get { return maxLv; } }
    public float MaxExp { get { return maxExp; } }
    public bool IsMax { get { return isMax; } }
    public bool IsZero { get { return isZero; } }

    // N : ����ġ ���
    public void AddExp(float exp)
    {
        currExp = currExp + exp;
        // N : ���� ��
        if (currExp >= maxExp && isMax == false)
        {
            LevelUp();
        }
        else subLv = 0;
    }

    // N : ����ġ �϶�
    public void SubExp(float exp)
    {
        currExp = currExp - exp;
        // N : ���� �ٿ�
        if (currExp <= 0 && isZero == false)
        {
            LevelDown();
        }
        else subLv = 0;
    }

    // N : ���� ��
    public void LevelUp()
    {
        while (currExp >= maxExp && isMax == false)
        {
            // N : ���� ��
            currLv++;
            subLv++;

            // N : ����ġ ����
            currExp = currExp - maxExp;
            maxExp = maxExp * expRate;  // N : �ִ� ����ġ ����
        }
        if (currLv == maxLv) isMax = true;
        isZero = false;
    }

    // N : ���� �ٿ�
    public void LevelDown()
    {
        while (currExp <= 0 && isZero == false)
        {
            // N : ���� �ٿ�
            currLv--;
            subLv--;

            // N : ����ġ ����
            maxExp = maxExp / expRate;  // N : �ִ� ����ġ ����
            currExp = currExp + maxExp;
        }
        isMax = false;
        if (currLv == 0) isZero = true;
    }

    // N : ���� �� �Ϸ� (���� �� �׼� ���� �� ȣ��)
    public void FinishUp()
    {
        subLv--;
    }

    // N : ���� �ٿ� �Ϸ� (���� �ٿ� �׼� ���� �� ȣ��)
    public void FinishDown()
    {
        subLv++;
    }

    // N : ���� �ʱ�ȭ
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