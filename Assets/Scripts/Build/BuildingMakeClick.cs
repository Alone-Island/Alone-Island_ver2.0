using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMakeClick : MonoBehaviour
{
    private bool isClicked = false;             // C : 클릭하고 있는지 확인하기 위한 변수

    public GameObject manualBuilding = null;    // C : 건물 리스트에 있는 건물 오브젝트
    private GameObject dragBuilding = null;     // C : 드래그 시 나타나는 건물 오브젝트
    public GameObject realBuilding = null;      // C : 실제로 빌드한 건물 오브젝트

    private bool checkCanBuild = false;         // C : 빌드할 수 있는 상태(자리)인지 체크하는 변수

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // C : 마우스 클릭(누를) 시
    private void OnMouseDown()
    {
        isClicked = true;
        dragBuilding = Instantiate(manualBuilding, transform);      // C : 클릭한 건물 오브젝트 복사
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);     // C : 마우스 위치 담는 변수
        mousePos.z = 1.0f;
        dragBuilding.transform.position = mousePos;                 // C : 복사한 건물 오브젝트 위치를 마우스 위치로 설정
    }

    // C : 마우스 드래그 시
    private void OnMouseDrag()
    {
        if (isClicked == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1.0f;
            dragBuilding.transform.position = mousePos;             // C : dragBuilding 위치를 현재 마우스 위치로 변경
        }
    }

    // C : 마우스 뗄 시
    private void OnMouseUp()
    {
        isClicked = false;
        // C : dragBuilding 위치에 실제 건물 오브젝트를 건설
        Instantiate(realBuilding, dragBuilding.transform.position, Quaternion.identity);
        Destroy(dragBuilding);      // C : dragBuilding 오브젝트 삭제
    }

    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        // C : 이미 지어진 건물 위치로 들어갔을 경우, 혹은 건물을 지을 수 없는 위치로 들어갔을 경우
        checkCanBuild = false;          // C : 빌드 가능 여부를 false로

        if (dragBuilding)               // C : 현재 건물 빌드 위해 드래그 중일 경우
        {
            // C : dragBuilding 오브젝트의 하위 오브젝트 중, Build 여부 체크를 위한 오브젝트 찾기
            GameObject buildNo = dragBuilding.transform.Find("BuildNo").gameObject;
            GameObject buildYes = dragBuilding.transform.Find("BuildYes").gameObject;
            
            // C : 건물을 지을 수 없는 상황이면 buildNo만 SetActive true
            buildYes.SetActive(false);
            buildNo.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        // C : 이미 지어진 건물 위치에 들어가있는 경우
        checkCanBuild = false;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        // C : 이미 지어진 건물 위치로 들어갔을 경우, 혹은 건물을 지을 수 없는 위치로 들어갔을 경우
        checkCanBuild = true;           // C : 빌드 가능 여부를 true로

        if (dragBuilding)               // C : 현재 건물 빌드 위해 드래그 중일 경우
        {
            // C : dragBuilding 오브젝트의 하위 오브젝트 중, Build 여부 체크를 위한 오브젝트 찾기
            GameObject buildNo = dragBuilding.transform.Find("BuildNo").gameObject;
            GameObject buildYes = dragBuilding.transform.Find("BuildYes").gameObject;
            
            // C : 건물을 지을 수 있는 상황이면 buildYes만 SetActive true
            buildNo.SetActive(false);
            buildYes.SetActive(true);
        }
    }
}
