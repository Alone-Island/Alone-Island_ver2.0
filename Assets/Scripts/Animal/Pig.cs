using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Animal
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.left * range, Color.green);   // J : æ∆¿Ã≈€ Ω¿µÊ ∞°¥… π¸¿ß «•Ω√
        CheckPlayer();
        CanAttack();
    }

    public override void MakeSound()
    {
        Debug.Log("≤‹≤‹");
    }
}
