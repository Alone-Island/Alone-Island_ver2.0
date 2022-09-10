using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICraft : MonoBehaviour
{
    // 필요한 컴포넌트
    [SerializeField]
    public CraftManager CraftManager;

    private void OnEnable()
    {
        for (int i = 0; i < CraftManager.itemData.Count; i++)
        {
            ItemData.ItemDictionary item = CraftManager.itemData[i];
            GameObject craftItemList = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Craft/CraftItemList") as GameObject) as GameObject;

            if (CraftManager.CheckCanMakeItem(item.materials))
            {
                craftItemList.GetComponent<Button>().interactable = true;
            }
            else
            {
                craftItemList.GetComponent<Button>().interactable = false;
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < CraftManager.itemData.Count; i++)
        {
            ItemData.ItemDictionary item = CraftManager.itemData[i];
            GameObject craftItemList = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Craft/CraftItemList") as GameObject) as GameObject;
            craftItemList.transform.GetChild(0).GetComponent<Image>().sprite = item.item.itemImage;
            craftItemList.transform.SetParent(CraftManager.CraftContent.transform, false);

            for (int j = 0; j < item.materials.Count; j++)
            {
                GameObject material = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Craft/Material") as GameObject) as GameObject;
                material.transform.SetParent(craftItemList.transform.GetChild(2), false);

                material.transform.GetChild(0).GetComponent<Image>().sprite = item.materials[j].item.itemImage;
                material.transform.GetChild(2).GetComponent<Text>().text = item.materials[j].num.ToString();

                if (j < item.materials.Count - 1)
                {
                    GameObject addMaterial = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Craft/AddMaterial") as GameObject) as GameObject;
                    addMaterial.transform.SetParent(craftItemList.transform.GetChild(2), false);
                }
            }


            craftItemList.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (CraftManager.MakeNewItem(item))
                {
                    CraftManager.CraftComplete.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = item.item.itemImage;
                    CraftManager.CraftComplete.SetActive(true);
                }
            });
        }
    }

    private void OnMouseUp()
    {
        
    }

    private void OnMouseDown()
    {
        
    }

    private void Update()
    {
    }
}
