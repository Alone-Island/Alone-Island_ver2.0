using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Firebase.Database;
using Firebase.Extensions;

// J : https://chameleonstudio.tistory.com/56 ����
public class DataController : MonoBehaviour
{
    static DatabaseReference m_Reference;   // J : ���̾�̽� reference
    static string userID = "wkddpdnjs99";   // J : �ӽ÷� ����� ���̵� ����

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

                m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
            }
            return _instance;
        }
    }

    public string GameDataFileName = "data.json";

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if (_gameData == null)
            {
                LoadGameData();
            }
            return _gameData;
        }
    }

    public void LoadGameData()
    {
        _gameData = new GameData();

        FirebaseDatabase.DefaultInstance.GetReference("users").Child(userID)
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    DataSnapshot animals = snapshot.Child("animals");

                    // J : ���� ������ �ϳ��� ����Ʈ�� ����
                    foreach (DataSnapshot animal in animals.Children)
                    {
                        _gameData.animalInfoList.Add(new AnimalInfo((IDictionary)animal.Value));
                    }
                    SaveGameData(); // J : ������ �ε尡 �񵿱������� ����->�ε尡 ���� �� ���̺�
                }
            });

        /*
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
        */
    }

    public void SaveGameData()
    {
        for (int i = 0; i < gameData.animalInfoList.Count; i++)
        {
            string json = JsonUtility.ToJson(gameData.animalInfoList[i]);
            m_Reference.Child("users").Child(userID).Child("animals").Child(i.ToString()).SetRawJsonValueAsync(json);
        }

        /*
        SaveData saveData = new SaveData(gameData);
        string ToJsonData = JsonUtility.ToJson(saveData);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("������ ���� �Ϸ�");
        */
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