using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// J : ���� ������ �ӽ� ��ũ��Ʈ
public class TempScript : MonoBehaviour
{
    // J : �̸� ���̾�̽��κ��� ������ �ҷ��ͼ� ���� ����
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
