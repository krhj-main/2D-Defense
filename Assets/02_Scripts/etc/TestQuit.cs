using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ��Ű�� �Լ�. �ϴ� Option �޴� �ǿ� Quit��ư�� ��ϵǾ��ִ�.
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
        // ��ư Ŭ���� ȣ���Ű�� ���� public ���� ����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // ������ ������ �۵��ƴٸ� ����Ƽ �������� ����� ����
#else
            Application.Quit();
            // ���� �����ѰŶ�� �� ����
#endif
    }
}
