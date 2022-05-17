using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCanBuild : MonoBehaviour
{

    private bool checkCanBuild = false;             // C : 빌드할 수 있는 상태(자리)인지 체크하는 변수

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
        // C : 지어진 건물 위치로 들어왔을 경우
        checkCanBuild = false;              // C : 빌드 가능 여부를 false로

        // C : 건물을 지을 수 없는 상황이면 buildNo만 SetActive true
        coll.gameObject.transform.Find("BuildNo").gameObject.SetActive(true);
        coll.gameObject.transform.Find("BuildYes").gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        // C : 이미 지어진 건물 위치에 들어가있는 경우
        checkCanBuild = false;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        // C : 지어진 건물 위치로 들어왔을 경우
        checkCanBuild = true;              // C : 빌드 가능 여부를 false로

        // C : 건물을 지을 수 있는 상황이면 buildYes만 SetActive true
        coll.gameObject.transform.Find("BuildNo").gameObject.SetActive(false);
        coll.gameObject.transform.Find("BuildYes").gameObject.SetActive(true);
    }
}
