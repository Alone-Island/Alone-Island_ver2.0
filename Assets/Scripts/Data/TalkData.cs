using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkData : MonoBehaviour
{
    // K : Talk ����ü�� ��ȭ�ڿ� ��ȭ ������ ��� strucure �Դϴ�
    public struct Talk
    {
        public string name;      // K : ��ȭ��
        public string dialog;    // K : ��ȭ ����

        public Talk(string _name, string _dialog)
        {
            this.name = _name;
            this.dialog = _dialog;
        }
    }

    Dictionary<int, List<Talk>> talkData;       // K : ��ȭ �����͸� �����ϴ� dictionary ����

    void Awake()
    {
        // K : dictionary instance ����
        talkData = new Dictionary<int, List<Talk>>();
        GenerateData();
    }

    // K : talkData ����
    void GenerateData()
    {
        talkData.Add(1001, new List<Talk> { new Talk("AI", "�ȳ��ϼ���") });
    }

    // K : �ʿ��� TalkData�� return
    public Talk GetTalkData(int id, int talkIndex)
    {
        Debug.Log("TalkID : " + id);
        if (talkIndex == talkData[id].Count)       // K : talkIndex�� talkData[id]�� ������ index + 1�̸�
            return new Talk(null, null);

        return talkData[id][talkIndex] ;     // C : �ʿ��� ������ id�� index�� ���� return
    }
}
