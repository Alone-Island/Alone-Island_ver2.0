using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private bool checkCanBuild = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        checkCanBuild = false;

        Debug.Log("trigger enter, " + checkCanBuild);

        if (checkCanBuild)
        {
            coll.gameObject.transform.Find("BuildNo").gameObject.SetActive(false);
            coll.gameObject.transform.Find("BuildYes").gameObject.SetActive(true);
        }
        else if (!checkCanBuild)
        {
            coll.gameObject.transform.Find("BuildNo").gameObject.SetActive(true);
            coll.gameObject.transform.Find("BuildYes").gameObject.SetActive(false);
        }

    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        checkCanBuild = false;
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        checkCanBuild = true;

        Debug.Log("trigger exit, " + checkCanBuild);

        
        if (checkCanBuild)
        {
            coll.gameObject.transform.Find("BuildNo").gameObject.SetActive(false);
            coll.gameObject.transform.Find("BuildYes").gameObject.SetActive(true);
        }
        else if (!checkCanBuild)
        {
            coll.gameObject.transform.Find("BuildNo").gameObject.SetActive(true);
            coll.gameObject.transform.Find("BuildYes").gameObject.SetActive(false);
        }

    }
}
