using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Run,
    Attack,
    Back,
}

public class Monster : MonoBehaviour
{
    public State state;
    [SerializeField]    public MonsterStat MM;
    [SerializeField ] GameObject bullet;

    Rigidbody2D rig;
    Transform castleT;

    bool isAttack;

    Coroutine knock =null;
    // Start is called before the first frame update
    void Start()
    {
        castleT = GameObject.Find("target").transform;
        rig = GetComponent<Rigidbody2D>();
        Debug.Log(MM.monster_HP);
        Debug.Log(MM.monster_Speed);

        state = State.Run;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Run:
                MoveAxis();
                break;
            case State.Attack:
                AttackCastle();
                break;
            case State.Back:
                Debug.Log($"{state}");
                if (knock == null)
                {
                    knock = StartCoroutine("KnockBack", 3f);
                }
                break;
        }
    }

    IEnumerator KnockBack(float time)
    {
        float currentTIme = 0f;
        Vector2 dir = (transform.position - castleT.transform.position).normalized;
        while (currentTIme < time)
        {
            currentTIme += Time.deltaTime;
            Debug.Log(time);
            transform.Translate(dir * Time.deltaTime * 1000f);

            yield return new WaitForFixedUpdate();
        }
        state = State.Run;
        knock = null;

    }
    public void MoveAxis()
    {
        float currentDistance = Vector3.Distance(transform.position, castleT.transform.position);

        if (MM.monster_Range > 0)
        {
            if(currentDistance < MM.monster_Range)
            {
                state = State.Attack;
            }
        }
        Vector2 dir = (castleT.transform.position - transform.position).normalized;
        rig.velocity = dir * MM.monster_Speed;

        //transform.Translate(dir * MM.monster_Speed * Time.deltaTime);
    }
    private void OnDestroy()
    {
        GM.Instance.haveGold += MM.monster_reward;
        UIManager.Instance.TopUIUpdate();
    }
    void AttackCastle()
    {
        
        rig.velocity = Vector2.zero;

        Vector3 dir = (castleT.transform.position - transform.position).normalized;

        if (!isAttack)
        {
            isAttack = true;
            StartCoroutine("ShootBullet");
        }        
    }
    IEnumerator ShootBullet()
    {
        Vector3 dir = (castleT.transform.position - transform.position).normalized;

        GameObject monsterBullet = Instantiate(bullet, transform.position, Quaternion.Euler(castleT.transform.position - transform.position));
        yield return new WaitForSeconds(1f);
        isAttack = false;
    }
}
