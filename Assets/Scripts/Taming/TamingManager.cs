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
    private GameObject barn;
    [SerializeField]
    private float margin;

    // Start is called before the first frame update
    void Start()
    {
        animalList = DataController.Instance.gameData.animalInfoList;
        animalObjectList = new List<GameObject>();

        barnPosition = barn.transform.position;

        barnX = barn.transform.GetComponent<SpriteRenderer>().size.x - margin;
        barnY = barn.transform.GetComponent<SpriteRenderer>().size.y - margin;

        Debug.Log(barnPosition);
        Debug.Log(barnX);
        Debug.Log(barnY);

        SpawnAnimals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAnimals()
    {
        foreach (AnimalInfo animal in animalList)
        {
            animalObjectList.Add(HuntingManager.SpawnAnimal(Resources.Load("Prefabs/Animals/" + animal.species), SpawnPosition()));
        }
    }

    private Vector3 SpawnPosition()
    {
        float randomX = Random.Range((barnY / 2) * -1, barnY / 2);
        float randomY = Random.Range((barnY / 2) * -1, barnY / 2);
        Vector3 RandomPostion = new Vector3(randomX, randomY, 0f);

        Vector3 respawnPosition = barnPosition + RandomPostion;

        Debug.Log(respawnPosition);

        return respawnPosition;
    }
}