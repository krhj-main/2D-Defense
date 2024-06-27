using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScale : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeTXT;
    // 현재 시간 배율을 나타내줄 텍스트
    int toggle = 0;
    // 버튼을 누를때마다 시간배율 바뀌기 위한 정수형 변수
    // Start is called before the first frame update
    void Start()
    {
        timeTXT.text = string.Format("{0}x", (toggle % 3) + 1);
        // 초기값은 1 배율
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeTimeScale()
    {
        // 버튼을 클릭했을때 호출하기위해 public 
        toggle++;
        // toggle 변수를 1씩 증가시킴
        timeTXT.text = string.Format("{0}x", (toggle % 3) + 1);
        // 버튼의 텍스트에 최대 3배까지 출력시키고, 1~3배를 반복되게함
        Time.timeScale = (toggle % 3) + 1;
        // 스케일 값 또한 1~3배 사이 값을 반복되게 함
    }
}
