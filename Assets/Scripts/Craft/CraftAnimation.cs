using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftAnimation : MonoBehaviour
{
    public GameObject CraftScrollView;
    public GameObject CraftInventoryAnimation;
    public Animator CraftUIAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OpenScrollView()
    {
        CraftScrollView.SetActive(true);
    }

    public void CloseScrollView()
    {
        CraftUIAnimator.SetFloat("animationSpeed", -0.8f);
        //CraftInventoryAnimation.SetActive(true);
    }

    void CloseCrfatInventoryAnimation()
    {
        CraftInventoryAnimation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
