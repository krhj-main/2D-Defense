using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 몬스터의 상태를 나타낼 열거형값
public enum State
{
    Run,
    Attack,
    Back,

    // 총 3가지의 상태로
    // 성으로 이동중 -> Run
    // 원거리공격의 경우 공격중 ->  Attack
    // 화살에 맞아 넉백 중 -> Back
}

/// <summary>
/// 몬스터마다 붙어있는 스크립트, Mob_1~5까지 붙어있음
/// </summary>
public class Monster : MonoBehaviour
{
    public State state;
    // 열거형값 state를 선언
    [SerializeField]    public MonsterStat MM;
    // MobManager 스크립트에 있는 MonsterStat 클래스 MM 선언
    [SerializeField ] GameObject bullet;
    // 원거리 공격에 사용될 게임오브젝트 bullet 선언

    Rigidbody2D rig;
    // 몬스터의 Rigidbody2D 값
    Transform castleT;
    // 몬스터가 성에 도달할 성의 트랜스폼

    bool isAttack;
    // 공격중인지 아닌지를 판단하게 해줄 변수값
    // 상태를 나타내는 열거형값과 다르게, 공격중에만 사용하는 변수임

    Coroutine knock =null;
    // 넉백의 상태를 조절할 코루틴형 변수값
    // 불린값 변수와 비슷한 작용을 함, 시험적으로 사용해보았음


    // Start is called before the first frame update
    void Start()
    {
        castleT = GameObject.Find("target").transform;
        // 성의 위치를 나타내는 target 트랜스폼
        rig = GetComponent<Rigidbody2D>();
        // 몬스터의 RIgidbody2D

        state = State.Run;
        // 처음에는 성을 향해 가야하므로 상태를 Run으로 세팅
    }

    // Update is called once per frame
    void Update()
    {
        // 상태에 따라 변환되야하므로 업데이트에 선언

        switch (state)
        {
            // 이동중인 상태 Run 이라면 성으로 이동하는 MoveAxis 함수 실행
            case State.Run:
                MoveAxis();
                break;
            // 공격중인 상태 Attack 이라면 성을 공격하는 AttackCastle 실행
            case State.Attack:
                AttackCastle();
                break;
            // 화살에 맞고 넉백중인 상태라면 넉백을 의미하는 KnockBack 코루틴 실행
            case State.Back:
                // knock 코루틴 변수값이 null 값이라면 넉백 코루틴 실행
                if (knock == null)
                {
                    knock = StartCoroutine("KnockBack", 0.15f);
                    // knock 코루틴 변수에 스타트 코루틴 함수를 사용해 KnockBack 코루틴 실행, 매개변수값 0.15f초동안 넉백
                    // 스타트 코루틴은 코루틴 값을 반환하므로 knock 백은 null 이 아니게되어 계속해서 호출하지않게됨
                }
                break;
        }
    }

    IEnumerator KnockBack(float time)
    {
        // 매개변수 time -> 총 넉백 시간

        float currentTIme = 0f;
        // 넉백까지의 시간을 카운트할 변수

        Vector2 dir = (transform.position - castleT.transform.position).normalized;
        // 몬스터가 성으로부터 멀어지도록  방향을 구함
        // 화살로 부터 멀어져도 되나, 2D 환경이기 때문에 성을 기준으로 멀어지게 하였음

        // 카운트변수가 넉백시간에 다다를 때까지 반복
        while (currentTIme < time)
        {
            currentTIme += Time.deltaTime;
            // 1프레임당 흐르는 시간 값을 카운트변수에 더함
            transform.Translate(dir * Time.deltaTime * 200f);
            // 몬스터가 성으로부터 멀어진다. 200의 속도로

            yield return new WaitForFixedUpdate();
            // 1프레임 대기
        }
        state = State.Run;
        // 넉백이 끝나면 다시 이동시키기 위해 Run 상태로 변경
        knock = null;
        // 넉백이 끝났으면 화살을 맞았을때 다시 넉백이 실행되어야하므로 knock 코루틴 변수를 다시 null 값으로 변경

    }
    public void MoveAxis()
    {
        // 성으로 이동하는 함수
        
        
        float currentDistance = Vector3.Distance(transform.position, castleT.transform.position);
        // 이동하다가 원거리 몬스터라면 원거리공격을 해야하므로 성과 몬스터와의 거리를 구함

        // 몬스터의 사거리가 0보다 클떄 -> 사거리가 있는 몬스터일때
        if (MM.monster_Range > 0)
        {
            // 몬스터의 사거리가 성과의 거리보다 좁아졌을때
            if(currentDistance < MM.monster_Range)
            {
                state = State.Attack;
                // 공격상태로 변경
            }
        }
        Vector2 dir = (castleT.transform.position - transform.position).normalized;
        // 이동할 방향을 구함, 성의 방향으로
        rig.velocity = dir * MM.monster_Speed;
        // 성의 방향으로 몬스터의 속도만큼 속도를 줌        
    }

    private void OnDestroy()
    {
        // 만약 몬스터가 사라졌을때 -> 몬스터 사망
        
        GM.Instance.haveGold += MM.monster_reward;
        // 플레이어의 소지골드 몬스터의 보상값만큼 추가
        UIManager.Instance.TopUIUpdate();
        // 추가된 골드 반영
    }
    void AttackCastle()
    {
        // 성을 향해 공격하기위한 함수

        rig.velocity = Vector2.zero;
        // 이동중이던 속도를 0으로 만듬 

        // 공격중인 상태가 아니었다면 -> 이동중일때는 아니므로
        if (!isAttack)
        {
            isAttack = true;
            // 공격 중이라고 불린값을 바꾸고
            StartCoroutine("ShootBullet");
            // 투사체를 발사하는 코루틴 실행
        }        
    }
    IEnumerator ShootBullet()
    {
        // 투사체 발사 코루틴       

        GameObject monsterBullet = Instantiate(bullet, transform.position, Quaternion.identity,transform);
        // 투사체를 생성한다, 몬스터의 위치에서 자체 회전값을 갖고, 몬스터의 자식으로 생성
        yield return new WaitForSeconds(1f);
        // 투사체 생성후 1초 대기
        isAttack = false;
        // isAttack 불린값을 다시 false로 바꾸어 다시 투사체 발사 코루틴을 실행할 수 있게 함
    }
}
