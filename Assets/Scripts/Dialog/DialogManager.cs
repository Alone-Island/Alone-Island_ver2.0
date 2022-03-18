using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    private DialogData talkData;

    // Start is called before the first frame update
    private void Start()
    {
        talkData = GetComponent<DialogData>();
    }

    // Update is called once per frame
    private void Update()
    {
        // TalkData.Dialog talk = talkData.GetDialogData(1001, 0);
    }
}
