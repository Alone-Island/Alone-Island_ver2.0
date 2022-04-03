using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingManager : MonoBehaviour
{
    [SerializeField]
    private TimingBar theTimingBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (theTimingBar.moveActivated && Input.GetKeyDown(KeyCode.Space))
        {
            theTimingBar.Stop();
        }
    }

    
}
