using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  몬스터의 스탯값 클래스. 몬스터 오브젝트가 Monster 스크립트에서 사용하며
///  몬스터마다 각각 다른 값을 사용한다.
/// </summary>
[System.Serializable]
public class MonsterStat
{
    public float monster_HP;
    public float monster_Speed;
    public float monster_regentime;
    public int monster_Dmg;
    public int monster_limitSpawn;
    public int monster_reward;

    // 몬스터의 체력, 속도, 생성 시간, 공겨력, 최대 생성량, 보상 값 포함

    [Space(15)]
    public float monster_Range;
    // 원거리 몬스터로 설정할거라면 사거리 값을 넣으면 됨
}

/// <summary>
/// 몬스터를 생성시키는 스크립트. 몹스포너 오브젝트에 붙어있다.
/// </summary>

public class MobManager : Singleton<MobManager>
{
    public GameObject[] monsters;
    // 생성시킬 몬스터를 배열로 받아옴
    [SerializeField] Button nextWave_BTN;
    // 다음 몬스터를 생성시킬 nextWave 버튼객체
    int waveIndex = -1;
    // 몇번째 웨이브인지를 나타내는 값, 0부터 인덱스가 시작이므로 -1로 초기값 세팅
    [SerializeField] Monster[] mobs;
    // 생성되는 몬스터에 붙어있는 Monster 스크립트를 배열로 받음
    
    // Start is called before the first frame update
    void Start()
    {
        nextWave_BTN.onClick.AddListener(AddIndex);
        // 다음 웨이브 버튼이 클릭됐을 때 호출

        AddIndex();
        // 처음에는 자동으로 첫번째 웨이브가 오도록 AddIndex 함수 실행
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddIndex()
    {
        // 웨이브 인덱스를 증가시키는 함수

        waveIndex++;
        // 웨이브 인덱스 변수를 1 증가시키고
        StartCoroutine(StartWave(waveIndex, mobs[waveIndex].MM.monster_regentime, mobs[waveIndex].MM.monster_limitSpawn));
        // 웨이브를 시작시켜 몬스터를 소환시키는 코루틴 실행
        // 스트링 형태로 선언하면 매개변수를 1개만 넣을 수 있기 때문에, 함수 형태로 스타트코루틴을 호출함
        // 웨이브 인덱스 번호, 몬스터의 생성시간, 몬스터의 생성제한량을 매개변수로 넣음
    }
    public IEnumerator StartWave(int monsterIndex, float regentime, int limitSpawn)
    {
        // 웨이브를 시작해 몬스터가 생성되는 코루틴
        // 몇번째 웨이브인지, 얼마만큼의 주기로 생성시킬지, 얼마만큼 생성시킬지 값을 받는다.


        while (true)
        {
            // 생성중에는 웨이브 시작 버튼을 비활성화
            nextWave_BTN.interactable = false;
            if (limitSpawn <= 0)
            {
                break;
                // 만약 생성제한량이 0아래로 내려가면 반복문 탈출
            }
            limitSpawn--;
            // 반복되는 동안 생성제한량을 1씩 감소시키고
            GameObject mob = Instantiate(monsters[monsterIndex], transform.position, Quaternion.identity);
            // 몬스터인덱스에 맞는 몬스터를 스포너 위치에서 생성시킨다.

            yield return new WaitForSeconds(regentime);
            // 받아온 생성주기 만큼 기다렸다가 다시 반복
        }
        nextWave_BTN.interactable = true;
        // 생성이 끝나면 버튼을 다시 활성화시키고
        StopCoroutine("StartWave");
        // 코루틴 종료
    }
}
