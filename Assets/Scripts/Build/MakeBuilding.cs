using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MakeBuilding : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public GameObject dragPrefeb;
    public GameObject buildPrefeb;
    public GameObject failedBuild;

    private BuildingManager BuildingManager;
    private bool isClicked;                     // C : 클릭하고 있는지 확인하기 위한 변수
    private GameObject dragBuilding;            // C : 드래그 시 나타나는 건물 오브젝트

    void Start()
    {
        isClicked = false;
        BuildingManager = FindObjectOfType<BuildingManager>();
    }

    // C : 마우스 클릭(누를) 시
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
        dragBuilding = Instantiate(dragPrefeb);        // C : 클릭한 건물 오브젝트 복사
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);     // C : 마우스 위치 담는 변수
        mousePos.z = 1.0f;
        dragBuilding.transform.position = mousePos;                 // C : 복사한 건물 오브젝트 위치를 마우스 위치로 설정
    }

    // C : 마우스 드래그 시
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1.0f;
            dragBuilding.transform.position = mousePos;             // C : dragBuilding 위치를 현재 마우스 위치로 변경
        }
    }

    // C : 마우스 뗄 시
    public void OnEndDrag(PointerEventData eventData)
    {
        isClicked = false;
        bool checkCanBuild = dragBuilding.transform.Find("BuildYes").gameObject.activeSelf;
        // 현재 위치에 빌드 가능한 경우
        if (checkCanBuild)
        {
            // 1. '재료 소비'
            string buildingName = buildPrefeb.name;
            BuildingManager.FinalConsume(BuildingManager.buildingData[buildingName]);
            // 2. 해당 위치에 '건물 설치'
            Instantiate(buildPrefeb, dragBuilding.transform.position, Quaternion.identity);        // C : dragBuilding 위치에 실제 건물 오브젝트를 건설
        }
        // 현재 위치에 빌드 불가능한 경우
        else
        {
            // 1. 건설 실패 모달창 띄우기
            /*
            GameObject failedImageObj = failedBuild.transform.Find("ItemImage").gameObject;
            Image failedImage = failedImageObj.GetComponent<Image>();
            failedImage.sprite = Resources.Load<Sprite>("/") as Sprite;
            */
            failedBuild.SetActive(true);
        }
        
        Destroy(dragBuilding);      // C : dragBuilding 오브젝트 삭제
    }
}
