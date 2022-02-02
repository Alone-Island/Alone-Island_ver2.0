using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    private TalkData talkData;

    // Start is called before the first frame update
    void Start()
    {
        talkData = GameObject.Find("TalkManger").GetComponent<TalkData>();
    }

    // Update is called once per frame
    void Update()
    {
        //TalkData.
    }
}
