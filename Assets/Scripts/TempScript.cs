using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempScript : MonoBehaviour
{
    public void CraftScene()
    {
        SceneManager.LoadScene("TestK");
    }

    public void TamingScene()
    {
        SceneManager.LoadScene(6);
    }
}
