using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// J : Item ScriptableObejct 에셋을 참조하는 스크립트
// J : Item 클래스와는 달리 MonoBehaviour를 상속받으므로 오브젝트에 컴포넌트로 사용 가능
public class ItemPickUp : MonoBehaviour
{
    public Item item;   // J : ScriptableObejct 에셋
}
