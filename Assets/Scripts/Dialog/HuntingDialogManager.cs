using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingDialogManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SelectPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrySelectActive();
    }

    // J : 선택지 활성화 시도
    private void TrySelectActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectPanel.SetActive(true);
        }
    }
}
