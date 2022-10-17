using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// J : 추후 삭제할 임시 스크립트
public class TempScript : MonoBehaviour
{
    // J : 미리 파이어베이스로부터 데이터 불러와서 에러 방지
    private void Start()
    {
        DataController data = DataController.Instance;
    }
    public void CraftScene()
    {
        SceneManager.LoadScene("TestK");
    }

    public void TamingScene()
    {
        SceneManager.LoadScene("Taming");
    }
}
