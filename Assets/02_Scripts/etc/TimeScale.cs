using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScale : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeTXT;
    // ���� �ð� ������ ��Ÿ���� �ؽ�Ʈ
    int toggle = 0;
    // ��ư�� ���������� �ð����� �ٲ�� ���� ������ ����
    // Start is called before the first frame update
    void Start()
    {
        timeTXT.text = string.Format("{0}x", (toggle % 3) + 1);
        // �ʱⰪ�� 1 ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeTimeScale()
    {
        // ��ư�� Ŭ�������� ȣ���ϱ����� public 
        toggle++;
        // toggle ������ 1�� ������Ŵ
        timeTXT.text = string.Format("{0}x", (toggle % 3) + 1);
        // ��ư�� �ؽ�Ʈ�� �ִ� 3����� ��½�Ű��, 1~3�踦 �ݺ��ǰ���
        Time.timeScale = (toggle % 3) + 1;
        // ������ �� ���� 1~3�� ���� ���� �ݺ��ǰ� ��
    }
}
