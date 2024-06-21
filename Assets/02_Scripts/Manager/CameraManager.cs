using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// 카메라 매니저
/// 카메라 드래그 이동에 관해 포함
/// @ 오브젝트에 붙어있음


public class CameraManager : MonoBehaviour
{
    static CameraManager instance;

    public static CameraManager Instance
    {
        get
        {
            return instance;
        }
    }


    Vector2 mousePos;
    // 마우스 클릭된 위치를 저장할 Vector2 객체
    bool isOnDrag;
    // 클릭하고나서 드래그 여부를 전달할 불린 값

    [Header("드래그 속도")]
    [SerializeField]
    float moveCamSpeed;
    // 카메라 이동속도 값

    Vector2 leftBG, rightBG;


    // Start is called before the first frame update
    void Start()
    {
        leftBG = GameObject.Find("BG").GetComponent<BoxCollider2D>().bounds.size;
        rightBG = GameObject.Find("BG_Copy").GetComponent<BoxCollider2D>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            mousePos = Input.mousePosition;
            // 클릭했을 때의 마우스 포지션 저장
            isOnDrag = true;
            // 드래그를 시작했다고 알림

        }
        if (Input.GetMouseButtonUp(0))
        {
            isOnDrag = false;
            // 마우스 버튼을 떼면 드래그 중이지 않다고 알림
        }

        if (Input.GetMouseButton(0) && isOnDrag == true)
        {
            // 마우스를 꾹 누르고있을 때
            Vector3 movePos = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - mousePos);
            // 카메라가 움직일 위치 = 지금의 마우스 위치값 - 처음 클릭했을때 마우스 위치값을 뷰포트 위치값으로 전달
            movePos.y = 0; movePos.z = 0;
            // y값과 z값은 움직일 필요가 없으므로 0으로 초기화

            if (Camera.main.transform.position.x <= 0)
            {
                movePos.x = -0.1f;
            }
            if (Camera.main.transform.position.x > rightBG.x)
            {
                movePos.x = 0.1f;
            }


            Vector3 moveCam = -movePos * (Time.deltaTime * moveCamSpeed);
            // 움직일 위치 값에 m/s * 마우스 드래그 속도 곱해주어
            Camera.main.transform.Translate(moveCam);
            // Translate 로 카메라 이동
        }
    }
}
