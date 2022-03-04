using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogData : MonoBehaviour
{
    // K : Talk ����ü�� ��ȭ�ڿ� ��ȭ ������ ��� strucure �Դϴ�
    private struct Dialog
    {
        public string Type { get; set; }      // K : ��ȭ��
        public string Data { get; set; }      // K : ��ȭ ����

        public Dialog(string _type, string _data)
        {
            this.Type = _type;
            this.Data = _data;
        }
    }

    private Dictionary<int, List<Dialog>> talkData;       // K : ��ȭ �����͸� �����ϴ� dictionary ����

    void Awake()
    {
        // K : dictionary instance ����
        talkData = new Dictionary<int, List<Dialog>>();
        GenerateData(talkData);
    }

    // K : talkData ����
    void GenerateData(Dictionary<int, List<Dialog>> dialogData)
    {
        dialogData.Add(1001, new List<Dialog> { new Dialog("AI", "�ȳ��ϼ���") });
    }

    // K : �ʿ��� TalkData�� return
    public Tuple<string, string> GetDialogData(int id, int index)
    {
        Debug.Log("TalkID : " + id);
        if (index == talkData[id].Count)       // K : talkIndex�� talkData[id]�� ������ index + 1�̸�
            return Tuple.Create<string, string>(null, null);

        return Tuple.Create<string, string>(talkData[id][index].Type, talkData[id][index].Data);     // C : �ʿ��� ������ id�� index�� ���� return
    }
}
