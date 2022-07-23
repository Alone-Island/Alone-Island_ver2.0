using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Firebase.Database;
using Firebase.Extensions;

// J : https://chameleonstudio.tistory.com/56 참고
public class DataController : MonoBehaviour
{
    static DatabaseReference m_Reference;   // J : 파이어베이스 reference
    static string userID = "aaabbbccc";   // J : 임시로 사용자 아이디 지정

    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }

    // J : 싱글톤으로 구현
    // J : DataContorller를 인스턴스화->다른 파일에서 스크립트를 찾지 않고 바로 접근 가능
    // J : static field, 객체 생성과 상관없이 클래스에서 선언된 순간 메모리에 할당되고 프로그램 끝날 때까지 유지
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
                DontDestroyOnLoad(_container);  // J : scene을 이동해도 game object 유지

                m_Reference = FirebaseDatabase.DefaultInstance.GetReference("users").Child(userID);
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
        m_Reference
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

                    Debug.Log(animals.ChildrenCount);

                    // J : 동물 데이터 하나씩 리스트에 저장
                    foreach (DataSnapshot animal in animals.Children)
                    {
                        Debug.Log(((IDictionary)animal.Value)["species"] + " satiety" + ((IDictionary)animal.Value)["satiety"] + "growth" + ((IDictionary)animal.Child("growth").Value)["CurrLv"] + " intimacy" + ((IDictionary)animal.Child("intimacy").Value)["CurrLv"]);
                        _gameData.animalInfoList.Add(new AnimalInfo((IDictionary)animal.Value, (IDictionary)animal.Child("growth").Value, (IDictionary)animal.Child("intimacy").Value));
                    }
                    //SaveGameData(); // J : 데이터 로드가 비동기적으로 수행->로드가 끝난 후 세이브
                }
            });

        /*
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            Debug.Log("게임 데이터 불러오기 성공!");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<TemporaryData>(FromJsonData);
        }
        else
        {
            Debug.Log("새로운 게임 데이터 파일 생성");
            _gameData = new TemporaryData();
        }
        */
    }

    public void SaveGameData()
    {
        Debug.Log("개수 : " + gameData.animalInfoList.Count);
        for (int i = 0; i < gameData.animalInfoList.Count; i++)
        {
            // J : 동물 데이터 저장
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

        /*
        SaveData saveData = new SaveData(gameData);
        string ToJsonData = JsonUtility.ToJson(saveData);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("데이터 저장 완료");
        */
    }

    // J : 게임의 모든 데이터 삭제
    public void DeleteAllData()
    {
        // J : 데이터 파일 삭제
        File.Delete(Application.persistentDataPath + "/" + GameDataFileName);
        _gameData = null;
    }

    private void OnApplicationQuit()    // J : 프로그램 종료 시 데이터 저장
    {
        SaveGameData();
    }
}