using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int currLv;     // N : ���� ����
    private int currExp;    // N : ���� ����ġ
    private int subLv;      // N : ���� ���� - ���� ���� (0�̸� ���� ��ȭ ����)
    private int maxLv;      // N : �ִ� ����
    private int maxExp;     // N : ���� ���������� �ִ� ����ġ
    private int expRate;    // N : ���� �� ����ġ ������
    private bool isMax;     // N : ���� ���� == �ִ� �����̸� true 

    public Level(int initLv, int maxLv, int expToNextLv, int expRate)
    {
        currLv = initLv;
        currExp = 0;
        subLv = 0;
        this.maxLv = maxLv;
        maxExp = expToNextLv;                       // N : ���� ���������� �ִ� ����ġ (���� �� �ϱ� ���� �ʿ��� ����ġ)
        this.expRate = expRate;
        isMax = (currLv == maxLv) ? true : false;
    }

    // ����ġ ���
    public void AddExp(int exp)
    {
        currExp = currExp + exp;
        // ���� ��
        if (currExp >= maxExp && isMax == false)
        {
            LevelUp();
        }
        else subLv = 0;
    }

    // ����ġ �϶�
    public void SubExp(int exp)
    {
        currExp = currExp - exp;
        // ���� �ٿ�
        if (currExp <= 0 && currLv > 0)
        {
            LevelDown();
        }
        else subLv = 0;
    }

    // ���� ��
    public void LevelUp()
    {
        while (currExp >= maxExp && isMax == false)
        {
            // ���� ��
            currLv++;
            subLv++;

            // ����ġ ����
            currExp = currExp - maxExp;
            maxExp = maxExp * expRate;  // �ִ� ����ġ ����

            if (currLv == maxLv) isMax = true;
        }
    }

    // ���� �ٿ�
    public void LevelDown()
    {
        while (currExp >= maxExp && isMax == false)
        {
            // ���� �ٿ�
            currLv--;
            subLv--;

            // ����ġ ����
            maxExp = maxExp / expRate;  // �ִ� ����ġ ����
            currExp = currExp + maxExp;
        }
    }

    // N : ���� �ʱ�ȭ
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