using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;    // J : TextMeshPro

public class HuntingManager : MonoBehaviour
{
    private bool isSuccess; // J : 타이밍바 적중 여부
    private GameObject animalObject;    // J : 스폰한 동물 오브젝트
    private int animalHP;

    [SerializeField]
    private Vector3 spawnPosition;  // J : 동물이 스폰될 위치
    [SerializeField]
    private Vector4 successTextColor;   // J : 성공 시 텍스트 색상
    [SerializeField]
    private Vector4 failTextColor;  // J : 실패 시 텍스트 색상

    // 필요한 컴포넌트
    [SerializeField]
    private TimingBar theTimingBar;
    [SerializeField]
    private TextMeshProUGUI judgementText;  // J : SUCCESS / FAIL 텍스트
    private Inventory theInventory;

    private void Start()
    {
        theInventory = FindObjectOfType<Inventory>();
        animalObject = SpawnAnimal(Resources.Load("Prefabs/" + DataController.Instance.gameData.encounterAnimal.englishName), spawnPosition);
        animalHP = DataController.Instance.gameData.encounterAnimal.hp;
    }

    // Update is called once per frame
    void Update()
    {
        // J : 화살표가 움직이는 중에 스페이스바를 누른 경우
        if (theTimingBar.moveActivated && Input.GetKeyDown(KeyCode.Space))
        {
            isSuccess = theTimingBar.Stop();    // J : 화살표를 멈춰 적중 여부를 받아옴
            SetText();
        }
    }

    // J : 동물 오브젝트 스폰
    public static GameObject SpawnAnimal(Object obj, Vector3 spawnPosition)
    {
        GameObject animalObject = Instantiate(obj as GameObject, spawnPosition, Quaternion.identity);    // J : 동물 오브젝트 스폰
        animalObject.GetComponent<Rigidbody2D>().gravityScale = 1;  // J : 횡스크롤이므로 중력 적용
        return animalObject;
    }

    // J : 공격 결과 반영
    private void Result()
    {
        if (isSuccess)  // J : 성공하면 무기의 공격력만큼 동물 체력 감소
        {
            int offensivePower = 20;    // J : 무기 장착 미구현 상태이므로 무기 공격력 임의로 지정 (미구현)
            animalHP -= offensivePower;
            if (animalHP <= 0)    // J : 동물의 체력이 모두 닳음
            {
                Debug.Log(DataController.Instance.gameData.encounterAnimal.koreanName + " 사냥 성공!");

                // J : 인벤토리에 사냥으로 얻은 아이템 추가
                foreach (Item item in DataController.Instance.gameData.encounterAnimal.huntingItems)
                    theInventory.AcquireItem(item);

                SceneManager.LoadScene("TestJ_hunt");   // J : 사냥터로 이동
            }
            else
            {
                Debug.Log(DataController.Instance.gameData.encounterAnimal.koreanName + "의 남은 체력 : " + animalHP);
                theTimingBar.DecideSuccessRange();  // J : 적중 범위 갱신
                theTimingBar.moveActivated = true;  // J : 다시 공격 시도
            }
        }
        else    // J : 실패하면 동물이 도망감
        {
            Debug.Log("사냥 실패!");
            SceneManager.LoadScene("TestJ_hunt");   // J : 사냥터로 이동
        }
    }

    // J : 적중 여부에 따른 결과 텍스트 설정
    private void SetText()
    {
        if (judgementText != null)
        {
            if (isSuccess)  // J : SUCCESS 텍스트
            {
                judgementText.text = "SUCCESS";
                judgementText.color = successTextColor;
            }
            else    // J : FAIL 텍스트
            {
                judgementText.text = "FAIL";
                judgementText.color = failTextColor;
            }
        }
        StartCoroutine("ShowText");
    }

    // J : https://hyunity3d.tistory.com/410
    // J : 결과 텍스트가 커지다가 사라짐
    IEnumerator ShowText()
    {
        // J : 글자 크기 변경
        for (int i = 0; i <= 50; i++)
        {
            judgementText.fontSize = i;
            yield return new WaitForFixedUpdate();
        }

        // J : 글자 투명도 변경
        for (float a = 1; a >= 0; a -= 0.01f)
        {
            judgementText.color = new Vector4(judgementText.color.r, judgementText.color.g, judgementText.color.b, a);
            yield return new WaitForFixedUpdate();
        }

        Result();
    }
}
