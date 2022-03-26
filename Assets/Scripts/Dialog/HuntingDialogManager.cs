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

    // J : ������ Ȱ��ȭ �õ�
    private void TrySelectActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectPanel.SetActive(true);
        }
    }
}
