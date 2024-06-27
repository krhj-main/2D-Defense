using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 종료 시키는 함수. 하단 Option 메뉴 탭에 Quit버튼에 등록되어있다.
/// </summary>
public class TestQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitTest()
    {
        // 버튼 클릭시 호출시키기 위해 public 으로 선언
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // 에디터 내에서 작동됐다면 유니티 에디터의 재생을 중지
#else
            Application.Quit();
            // 앱을 실행한거라면 앱 종료
#endif
    }
}
