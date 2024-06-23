using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    [Header ("ȭ�� ������")]
    [SerializeField] GameObject arrow;
    // ȭ�� ������
    [Header("ȭ�� �߻� ��ġ")]
    [SerializeField] Transform muzzle;
    // ȭ�� �߻� ����Ʈ 
    [Header("ȭ�� �߻� �ӵ�")]
    [SerializeField] float arrowPower;
    // ȭ�� �߻� ��
    [Header("�߷� ���ӵ�")]
    [Tooltip ("�⺻�� -9.81")]
    [SerializeField] Vector2 gravity = new Vector2(0,-9.81f);
    // �߷°��ӵ�




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootArrow();
        }
    }
    void ShootArrow()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        GameObject arrows = Instantiate(arrow, muzzle.position, Quaternion.Euler(muzzle.transform.eulerAngles));

        Vector2 dir = (mousePos - muzzle.position).normalized;

        Arrow arrowScript = arrows.GetComponent<Arrow>();
        arrowScript.Initialize(dir * arrowPower, gravity);
    }
}
