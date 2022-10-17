using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D coll)
    {
        // C : dragBuilding 오브젝트의 하위 오브젝트 중 Build 여부 체크를 위한 오브젝트 찾고, 건물을 지을 수 없는 상황이면 buildNo만 SetActive true
        transform.Find("BuildNo").gameObject.SetActive(true);
        transform.Find("BuildYes").gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        // C : dragBuilding 오브젝트의 하위 오브젝트 중, Build 여부 체크를 위한 오브젝트 찾고, 건물을 지을 수 없는 상황이면 buildYes만 SetActive true
        transform.Find("BuildNo").gameObject.SetActive(false);
        transform.Find("BuildYes").gameObject.SetActive(true);

    }
}
