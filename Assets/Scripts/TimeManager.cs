using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float dayLength;  // N : �Ϸ簡 ��������

    private int day = 0;                        // N : ���� ��¥ (1�� = day_length)
    private float dayTime = 0;                  // N : �Ϸ� �� ���� �ð� (��)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (true) dayTime += Time.deltaTime;    // N : Ư�� ���ǿ��� �ð� ����
        if (dayTime >= dayLength)
        {
            dayTime = 0;
            dayAfter();
        }
    }

    // N : ��¥ ��ȭ
    public void dayAfter()
    {
        day++;

        // N : ��¥�� ���� ���� ��ȭ �� �ۼ�
    }
}
