using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private int sceneBuildIdx; // J : �ε��� ���� ���� �ε���

    public int GetSceneBuildIdx()
    {
        return sceneBuildIdx;
    }
}
