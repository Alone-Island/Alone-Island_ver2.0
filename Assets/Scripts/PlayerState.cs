using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // player�� Ŭ������ ���� �ʿ�

    // N : �÷��̾� ����
    private Level water = new Level(1, 1, 100f, 1f);        // N : ����
    private Level nutrition = new Level(1, 1, 100f, 1f);    // N : ����
    private Level temperature = new Level(1, 1, 100f, 1f);  // N : ü��
    private Level happy = new Level(1, 1, 100f, 1f);        // N : �ູ
}
