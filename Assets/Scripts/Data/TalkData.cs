using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkData : MonoBehaviour
{
    // K : Talk 구조체로 대화자와 대화 내용을 담는 strucure 입니다
    public struct Talk
    {
        public string name;      // K : 대화자
        public string dialog;    // K : 대화 내용

        public Talk(string _name, string _dialog)
        {
            this.name = _name;
            this.dialog = _dialog;
        }
    }

    Dictionary<int, List<Talk>> talkData;       // K : 대화 데이터를 저장하는 dictionary 변수

    void Awake()
    {
        // K : dictionary instance 생성
        talkData = new Dictionary<int, List<Talk>>();
        GenerateData();
    }

    // K : talkData 생성
    void GenerateData()
    {
        talkData.Add(1001, new List<Talk> { new Talk("AI", "안녕하세요") });
    }

    // K : 필요한 TalkData를 return
    public Talk GetTalkData(int id, int talkIndex)
    {
        Debug.Log("TalkID : " + id);
        if (talkIndex == talkData[id].Count)       // K : talkIndex가 talkData[id]의 마지막 index + 1이면
            return new Talk(null, null);

        return talkData[id][talkIndex] ;     // C : 필요한 문장을 id와 index를 통해 return
    }
}
