using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �÷��̾ ���콺 Ŭ������ ȭ���� �߻��ϴ� ��ũ��Ʈ @ ������Ʈ�� �پ�����
/// </summary>

public class ArrowShot : MonoBehaviour
{
    [Header ("ȭ�� ������")]
    [SerializeField] GameObject arrow;
    // ȭ�� ������
    [Header("ȭ�� �߻� ��ġ")]
    [SerializeField] Transform muzzle;
    // ȭ�� �߻� ����Ʈ 

    




    // Update is called once per frame
    void Update()
    {
        // UI�� �ƴ� �κ��� ���콺 ��Ŭ�� ���� �� ����
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ShootArrow();
        }
    }
    void ShootArrow()
    {
        // ȭ�� �߻� �Լ�
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Ŭ���������� ���콺 ��ũ����ġ���� ��������Ʈ ������ ��ȯ�� Vector3 ������ ����
        mousePos.z = 0;
        // z ���� ������������Ƿ� 0���� �ʱ�ȭ

        GameObject arrows = Instantiate(arrow, muzzle.position, Quaternion.Euler(muzzle.transform.eulerAngles));
        // ȭ�� ������Ʈ ����, muzzle ��ġ���� muzzle �� ������ ����

        Vector2 dir = (mousePos - muzzle.position).normalized;
        // ȭ���� ������ �����ֱ� ���� ���Ⱚ�� ���

        Arrow arrowScript = arrows.GetComponent<Arrow>();
        arrowScript.Initialize(dir);
        // ȭ�� ��ũ��Ʈ�� ������ ȭ�쿡 ���Ⱚ�� ����
    }


    /// <summary>
    /// ���Ϳ��� ������ ó��
    /// </summary>
    /// <param name="ȭ�� ������Ʈ"></param>
    /// <param name="���� ������Ʈ"></param>
    /// <param name="���Ϳ��� ���� ������"></param>
    public void OnHitted(GameObject monster, float damage)
    {
        monster.GetComponent<Monster>().state = State.Back;
        // ȭ�쿡 �¾����Ƿ� ������ ���¸� �˹���·� �ٲ���
        monster.GetComponent<Monster>().MM.monster_HP -= damage;
        // ������ ü���� ȭ���� ������ ��ŭ ����
        if(monster.GetComponent<Monster>().MM.monster_HP <= 0)
        {
            Destroy(monster.gameObject);
            // ȭ�쿡 ���� ������ ü���� 0���ϰ� �ȴٸ� ���� ������Ʈ�� ����
        }
    }
}
