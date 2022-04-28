using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

// J : https://chameleonstudio.tistory.com/56 ����
public class DataController : MonoBehaviour
{
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }

    // J : �̱������� ����
    // J : DataContorller�� �ν��Ͻ�ȭ->�ٸ� ���Ͽ��� ��ũ��Ʈ�� ã�� �ʰ� �ٷ� ���� ����
    // J : static field, ��ü ������ ������� Ŭ�������� ����� ���� �޸𸮿� �Ҵ�ǰ� ���α׷� ���� ������ ����
    static DataController _instance;
    public static DataController Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);  // J : scene�� �̵��ص� game object ����
            }
            return _instance;
        }
    }

    public string GameDataFileName = "data.json";

    public TemporaryData _gameData;
    public TemporaryData gameData
    {
        get
        {
            if (_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            Debug.Log("���� ������ �ҷ����� ����!");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<TemporaryData>(FromJsonData);
        }
        else
        {
            Debug.Log("���ο� ���� ������ ���� ����");
            _gameData = new TemporaryData();
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("������ ���� �Ϸ�");
    }

    // J : ������ ��� ������ ����
    public void DeleteAllData()
    {
        // J : ������ ���� ����
        File.Delete(Application.persistentDataPath + "/" + GameDataFileName);
        _gameData = null;
    }

    private void OnApplicationQuit()    // J : ���α׷� ���� �� ������ ����
    {
        SaveGameData();
    }
}