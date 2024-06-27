using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������ ���¸� ��Ÿ�� ��������
public enum State
{
    Run,
    Attack,
    Back,

    // �� 3������ ���·�
    // ������ �̵��� -> Run
    // ���Ÿ������� ��� ������ ->  Attack
    // ȭ�쿡 �¾� �˹� �� -> Back
}

/// <summary>
/// ���͸��� �پ��ִ� ��ũ��Ʈ, Mob_1~5���� �پ�����
/// </summary>
public class Monster : MonoBehaviour
{
    public State state;
    // �������� state�� ����
    [SerializeField]    public MonsterStat MM;
    // MobManager ��ũ��Ʈ�� �ִ� MonsterStat Ŭ���� MM ����
    [SerializeField ] GameObject bullet;
    // ���Ÿ� ���ݿ� ���� ���ӿ�����Ʈ bullet ����

    Rigidbody2D rig;
    // ������ Rigidbody2D ��
    Transform castleT;
    // ���Ͱ� ���� ������ ���� Ʈ������

    bool isAttack;
    // ���������� �ƴ����� �Ǵ��ϰ� ���� ������
    // ���¸� ��Ÿ���� ���������� �ٸ���, �����߿��� ����ϴ� ������

    Coroutine knock =null;
    // �˹��� ���¸� ������ �ڷ�ƾ�� ������
    // �Ҹ��� ������ ����� �ۿ��� ��, ���������� ����غ�����


    // Start is called before the first frame update
    void Start()
    {
        castleT = GameObject.Find("target").transform;
        // ���� ��ġ�� ��Ÿ���� target Ʈ������
        rig = GetComponent<Rigidbody2D>();
        // ������ RIgidbody2D

        state = State.Run;
        // ó������ ���� ���� �����ϹǷ� ���¸� Run���� ����
    }

    // Update is called once per frame
    void Update()
    {
        // ���¿� ���� ��ȯ�Ǿ��ϹǷ� ������Ʈ�� ����

        switch (state)
        {
            // �̵����� ���� Run �̶�� ������ �̵��ϴ� MoveAxis �Լ� ����
            case State.Run:
                MoveAxis();
                break;
            // �������� ���� Attack �̶�� ���� �����ϴ� AttackCastle ����
            case State.Attack:
                AttackCastle();
                break;
            // ȭ�쿡 �°� �˹����� ���¶�� �˹��� �ǹ��ϴ� KnockBack �ڷ�ƾ ����
            case State.Back:
                // knock �ڷ�ƾ �������� null ���̶�� �˹� �ڷ�ƾ ����
                if (knock == null)
                {
                    knock = StartCoroutine("KnockBack", 0.15f);
                    // knock �ڷ�ƾ ������ ��ŸƮ �ڷ�ƾ �Լ��� ����� KnockBack �ڷ�ƾ ����, �Ű������� 0.15f�ʵ��� �˹�
                    // ��ŸƮ �ڷ�ƾ�� �ڷ�ƾ ���� ��ȯ�ϹǷ� knock ���� null �� �ƴϰԵǾ� ����ؼ� ȣ�������ʰԵ�
                }
                break;
        }
    }

    IEnumerator KnockBack(float time)
    {
        // �Ű����� time -> �� �˹� �ð�

        float currentTIme = 0f;
        // �˹������ �ð��� ī��Ʈ�� ����

        Vector2 dir = (transform.position - castleT.transform.position).normalized;
        // ���Ͱ� �����κ��� �־�������  ������ ����
        // ȭ��� ���� �־����� �ǳ�, 2D ȯ���̱� ������ ���� �������� �־����� �Ͽ���

        // ī��Ʈ������ �˹�ð��� �ٴٸ� ������ �ݺ�
        while (currentTIme < time)
        {
            currentTIme += Time.deltaTime;
            // 1�����Ӵ� �帣�� �ð� ���� ī��Ʈ������ ����
            transform.Translate(dir * Time.deltaTime * 200f);
            // ���Ͱ� �����κ��� �־�����. 200�� �ӵ���

            yield return new WaitForFixedUpdate();
            // 1������ ���
        }
        state = State.Run;
        // �˹��� ������ �ٽ� �̵���Ű�� ���� Run ���·� ����
        knock = null;
        // �˹��� �������� ȭ���� �¾����� �ٽ� �˹��� ����Ǿ���ϹǷ� knock �ڷ�ƾ ������ �ٽ� null ������ ����

    }
    public void MoveAxis()
    {
        // ������ �̵��ϴ� �Լ�
        
        
        float currentDistance = Vector3.Distance(transform.position, castleT.transform.position);
        // �̵��ϴٰ� ���Ÿ� ���Ͷ�� ���Ÿ������� �ؾ��ϹǷ� ���� ���Ϳ��� �Ÿ��� ����

        // ������ ��Ÿ��� 0���� Ŭ�� -> ��Ÿ��� �ִ� �����϶�
        if (MM.monster_Range > 0)
        {
            // ������ ��Ÿ��� ������ �Ÿ����� ����������
            if(currentDistance < MM.monster_Range)
            {
                state = State.Attack;
                // ���ݻ��·� ����
            }
        }
        Vector2 dir = (castleT.transform.position - transform.position).normalized;
        // �̵��� ������ ����, ���� ��������
        rig.velocity = dir * MM.monster_Speed;
        // ���� �������� ������ �ӵ���ŭ �ӵ��� ��        
    }

    private void OnDestroy()
    {
        // ���� ���Ͱ� ��������� -> ���� ���
        
        GM.Instance.haveGold += MM.monster_reward;
        // �÷��̾��� ������� ������ ���󰪸�ŭ �߰�
        UIManager.Instance.TopUIUpdate();
        // �߰��� ��� �ݿ�
    }
    void AttackCastle()
    {
        // ���� ���� �����ϱ����� �Լ�

        rig.velocity = Vector2.zero;
        // �̵����̴� �ӵ��� 0���� ���� 

        // �������� ���°� �ƴϾ��ٸ� -> �̵����϶��� �ƴϹǷ�
        if (!isAttack)
        {
            isAttack = true;
            // ���� ���̶�� �Ҹ����� �ٲٰ�
            StartCoroutine("ShootBullet");
            // ����ü�� �߻��ϴ� �ڷ�ƾ ����
        }        
    }
    IEnumerator ShootBullet()
    {
        // ����ü �߻� �ڷ�ƾ       

        GameObject monsterBullet = Instantiate(bullet, transform.position, Quaternion.identity,transform);
        // ����ü�� �����Ѵ�, ������ ��ġ���� ��ü ȸ������ ����, ������ �ڽ����� ����
        yield return new WaitForSeconds(1f);
        // ����ü ������ 1�� ���
        isAttack = false;
        // isAttack �Ҹ����� �ٽ� false�� �ٲپ� �ٽ� ����ü �߻� �ڷ�ƾ�� ������ �� �ְ� ��
    }
}
