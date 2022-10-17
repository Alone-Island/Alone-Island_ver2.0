using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private int sceneBuildIdx; // J : ∑ŒµÂ«“ æ¿¿« ∫ÙµÂ ¿Œµ¶Ω∫

    public int GetSceneBuildIdx()
    {
        return sceneBuildIdx;
    }
}
