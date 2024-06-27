using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

///<summary>
///ī�޶� �巡�� �̵��� ���� ��ũ��Ʈ @������Ʈ�� �پ�����
///</summary>>

public class CameraManager : Singleton<CameraManager>
{
    Vector2 mousePos;
    // ���콺 Ŭ���� ��ġ�� ������ Vector2 ��ü
    bool isOnDrag;
    // Ŭ���ϰ��� �巡�� ���θ� ������ �Ҹ� ��

    [Header("�巡�� �ӵ�")]
    [SerializeField]
    float moveCamSpeed;
    // ī�޶� �̵��ӵ� ��

    Vector2 leftBG, rightBG;
    // ī�޶��� �̵������� �������ֱ� ���� ����� ��ġ���� ������ Vector2 ����


    // Start is called before the first frame update
    void Start()
    {
        leftBG = GameObject.Find("BG").GetComponent<BoxCollider2D>().bounds.size;
        // ���� ������ �ִ� ����� �����
        rightBG = GameObject.Find("BG_Copy").GetComponent<BoxCollider2D>().bounds.size;
        // ���� ������ �ִ� ����� �����
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 ���ʹ�ư�� Ŭ��, UI�� Ŭ�������ʾ��������
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            mousePos = Input.mousePosition;
            // Ŭ������ ���� ���콺 ������ ����
            isOnDrag = true;
            // �巡�׸� �����ߴٰ� �˸�

        }
        if (Input.GetMouseButtonUp(0))
        {
            isOnDrag = false;
            // ���콺 ��ư�� ���� �巡�� ������ �ʴٰ� �˸�
        }

        if (Input.GetMouseButton(0) && isOnDrag == true)
        {
            // ���콺�� �� ���������� ��
            Vector3 movePos = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - mousePos);
            // ī�޶� ������ ��ġ = ������ ���콺 ��ġ�� - ó�� Ŭ�������� ���콺 ��ġ���� ����Ʈ ��ġ������ ����
            movePos.y = 0; movePos.z = 0;
            // y���� z���� ������ �ʿ䰡 �����Ƿ� 0���� �ʱ�ȭ

            if (Camera.main.transform.position.x <= 0)
            {
                movePos.x = -0.1f;
            }
            if (Camera.main.transform.position.x > rightBG.x)
            {
                movePos.x = 0.1f;
            }


            Vector3 moveCam = -movePos * (Time.deltaTime * moveCamSpeed);
            // ������ ��ġ ���� m/s * ���콺 �巡�� �ӵ� �����־�
            Camera.main.transform.Translate(moveCam);
            // Translate �� ī�޶� �̵�
        }
    }
}
