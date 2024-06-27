using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ȭ�� ������Ʈ�� ������ ��� ���� �Լ�
/// </summary>

public class Arrow : MonoBehaviour
{
    Vector2 velocity;
    // ȭ���� �ӵ���
    Vector2 gravity;
    // ȭ���� �߷°�
    ArrowShot arrowScript;
    // ȭ������� �߻��ϴ� ArrowShot ��ũ��Ʈ ���� ����
    [SerializeField] Weapon Weapon_Type;
    // ���� Ÿ�Կ� ���� �����ϱ����� Weapon Ŭ���� ���� ����

    public void Initialize(Vector2 dir)
    {
        // ArrowShot ���� ȣ���� ���Ⱚ�� �޾ƿ������� �Լ�

        this.velocity = dir * Weapon_Type.attackSpeed;
        // ȭ���� �ӵ��� ���Ⱚ�� ����, ȭ�������Ʈ�� velocity ���� ����
        this.gravity = Weapon_Type.gravity;
        // �߷°��� �����Ȱ� �״�� ����

        Destroy(this.gameObject, 2f);
        // ���͸� ���������������� 2�ʵڿ� �ڵ����� �����
    }
    private void Start()
    {
        arrowScript = GameObject.Find("@").GetComponent<ArrowShot>();    
        // ArrowShot ��ũ��Ʈ�� @ ������Ʈ�� �پ������Ƿ� ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        velocity += gravity * Time.deltaTime;
        // ȭ���� �ӵ��� �߷°� * p/s ��ŭ ����
        // �߷°��� �����̹Ƿ� ��������δ� �ӵ��� ������

        transform.Translate(velocity * Time.deltaTime,Space.World);
        // ȭ���� �̵�
        // ����ؼ� ���ϴ� �ӵ�����ŭ �̵��Ѵ�

        Vector2 norVelo = velocity.normalized;
        // �ӵ����� ����ȭ
        float angle = Mathf.Atan2(norVelo.y, norVelo.x) * Mathf.Rad2Deg;
        // ȭ���� ������ ���� �������� ����� �������� �ϴ� ��
        // �˻��� ���� ã�ƺ� ���������� �Ϻ��� �������� ������

        angle -= 90;
        // 90�� ���ҽ����ִ� ������ �߻��� ������ �����ϱ� ����
        // -90���� ���� ���ι������� ������ش�
        transform.rotation = Quaternion.Euler(0,0,angle);
        // ���� angle ���� ȭ�� z�� ���� ����
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            // ȭ�� ������Ʈ�� ���� �±׸� ���� ������Ʈ�� ������
            Destroy(gameObject);
            // ȭ���� �����ϰ�
            arrowScript.OnHitted(collision.gameObject, Weapon_Type.damage);          
            // ArrowScript ���� ���Ϳ��� �������� ó���Ѵ�.
        }
    }
}
