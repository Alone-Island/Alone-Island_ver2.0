using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogData : MonoBehaviour
{
    // K : Talk 구조체로 대화자와 대화 내용을 담는 strucure 입니다
    private struct Dialog
    {
        public string Type { get; set; }      // K : 대화자
        public string Data { get; set; }      // K : 대화 내용

        public Dialog(string _type, string _data)
        {
            this.Type = _type;
            this.Data = _data;
        }
    }

    private Dictionary<int, List<Dialog>> talkData;       // K : 대화 데이터를 저장하는 dictionary 변수

    void Awake()
    {
        // K : dictionary instance 생성
        talkData = new Dictionary<int, List<Dialog>>();
        GenerateData(talkData);
    }

    // K : talkData 생성
    void GenerateData(Dictionary<int, List<Dialog>> dialogData)
    {
        dialogData.Add(1001, new List<Dialog> { new Dialog("AI", "안녕하세요") });
    }

    // K : 필요한 TalkData를 return
    public Tuple<string, string> GetDialogData(int id, int index)
    {
        Debug.Log("TalkID : " + id);
        if (index == talkData[id].Count)       // K : talkIndex가 talkData[id]의 마지막 index + 1이면
            return Tuple.Create<string, string>(null, null);

        return Tuple.Create<string, string>(talkData[id][index].Type, talkData[id][index].Data);     // C : 필요한 문장을 id와 index를 통해 return
    }
}
