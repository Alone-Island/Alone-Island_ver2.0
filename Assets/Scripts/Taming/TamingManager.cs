using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamingManager : MonoBehaviour
{
    private List<AnimalInfo> animalList;
    private List<GameObject> animalObjectList;

    private Vector3 barnPosition;
    private float barnX, barnY;

    [SerializeField]
    private LayerMask myAnimalLayerMask;    // MyAnimal 레이어
    [SerializeField]
    private GameObject barn;
    [SerializeField]
    private float margin;

    // Start is called before the first frame update
    void Start()
    {
        animalList = DataController.Instance.gameData.animalInfoList;
        animalObjectList = new List<GameObject>();

        myAnimalLayerMask = LayerMask.NameToLayer("MyAnimal");

        barnPosition = barn.transform.position;

        barnX = barn.transform.GetComponent<SpriteRenderer>().size.x - margin;
        barnY = barn.transform.GetComponent<SpriteRenderer>().size.y - margin;

        /*
        Debug.Log(barnPosition);
        Debug.Log(barnX);
        Debug.Log(barnY);
        */

        SpawnAnimals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 동물 오브젝트 스폰
    private void SpawnAnimals()
    {
        // 레이어가 MyAnimal인 동물 오브젝트들 스폰
        foreach (AnimalInfo animal in animalList)
        {
            GameObject myAnimal = HuntingManager.SpawnAnimal(Resources.Load("Prefabs/Animals/" + animal.species), SpawnPosition());
            myAnimal.gameObject.layer = myAnimalLayerMask;
            animalObjectList.Add(myAnimal);
        }
    }

    private Vector3 SpawnPosition()
    {
        float randomX = Random.Range((barnY / 2) * -1, barnY / 2);
        float randomY = Random.Range((barnY / 2) * -1, barnY / 2);
        Vector3 RandomPostion = new Vector3(randomX, randomY, 0f);

        Vector3 respawnPosition = barnPosition + RandomPostion;

        // Debug.Log(respawnPosition);

        return respawnPosition;
    }

    // J : myAnimal의 성장도 경험치 증가
    public void GrowMyAnimal(GameObject myAnimal)
    {
        Debug.Log("GrowMyAnimal");
        animalList[animalObjectList.IndexOf(myAnimal)].Grow();
    }
}