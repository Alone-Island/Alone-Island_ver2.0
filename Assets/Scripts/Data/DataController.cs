using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Firebase.Database;
using Firebase.Extensions;
using Firebase;
using Firebase.Analytics;

// J : https://chameleonstudio.tistory.com/56 ����
public class DataController : MonoBehaviour
{
    static DatabaseReference m_Reference;   // J : ���̾�̽� reference
    static string userID = "aaabbbccc";   // J : �ӽ÷� ����� ���̵� ����
    //static bool isInitialized;

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

                Initialize();
            }
            return _instance;
        }
    }

    // J : https://helloezzi.tistory.com/140
    private static void Initialize()
    {
        Debug.Log("Initialize");

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                m_Reference = FirebaseDatabase.DefaultInstance.GetReference("users").Child(userID);
                //isInitialized = true;
                LoadGameData();
            }
            else
            {
                Debug.Log("Error" + dependencyStatus);
                //isInitialized = false;
            }
        });
    }

    public string GameDataFileName = "data.json";

    public static GameData _gameData;
    public GameData gameData
    {
        get
        {
            if (_gameData == null)
                LoadGameData();

            return _gameData;
        }
    }

    public static void LoadGameData()
    {
        Debug.Log("LoadGameData");

        // if (isInitialized)
        {
            _gameData = new GameData();

            m_Reference
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                    Debug.Log("�ε� ����");
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("�ε� ����");
                    DataSnapshot snapshot = task.Result;
                    DataSnapshot animals = snapshot.Child("animals");

                    Debug.Log(animals.ChildrenCount);

                    // J : ���� ������ �ϳ��� ����Ʈ�� ����
                    foreach (DataSnapshot animal in animals.Children)
                    {
                        Debug.Log(((IDictionary)animal.Value)["species"] + " satiety" + ((IDictionary)animal.Value)["satiety"] + "growth" + ((IDictionary)animal.Child("growth").Value)["CurrLv"] + " intimacy" + ((IDictionary)animal.Child("intimacy").Value)["CurrLv"]);
                        _gameData.animalInfoList.Add(new AnimalInfo((IDictionary)animal.Value, (IDictionary)animal.Child("growth").Value, (IDictionary)animal.Child("intimacy").Value));
                    }
                }
            });
        }
        
    }

    public void SaveGameData()
    {
        Debug.Log("���� : " + gameData.animalInfoList.Count);
        for (int i = 0; i < gameData.animalInfoList.Count; i++)
        {
            // J : ���� ������ ����
            string json = JsonUtility.ToJson(gameData.animalInfoList[i]);
            m_Reference.Child("animals").Child(i.ToString()).SetRawJsonValueAsync(json);

            Dictionary<string, object> growth = new Dictionary<string, object>();
            growth["CurrLv"] = gameData.animalInfoList[i].growth.CurrLv;
            growth["CurrExp"] = gameData.animalInfoList[i].growth.CurrExp;

            Dictionary<string, object> intimacy = new Dictionary<string, object>();
            intimacy["CurrLv"] = gameData.animalInfoList[i].intimacy.CurrLv;
            intimacy["CurrExp"] = gameData.animalInfoList[i].intimacy.CurrExp;

            m_Reference.Child("animals").Child(i.ToString()).Child("growth").UpdateChildrenAsync(growth);
            m_Reference.Child("animals").Child(i.ToString()).Child("intimacy").UpdateChildrenAsync(intimacy);
        }
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