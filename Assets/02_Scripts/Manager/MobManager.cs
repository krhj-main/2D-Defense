using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  ������ ���Ȱ� Ŭ����. ���� ������Ʈ�� Monster ��ũ��Ʈ���� ����ϸ�
///  ���͸��� ���� �ٸ� ���� ����Ѵ�.
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

    // ������ ü��, �ӵ�, ���� �ð�, ���ܷ�, �ִ� ������, ���� �� ����

    [Space(15)]
    public float monster_Range;
    // ���Ÿ� ���ͷ� �����ҰŶ�� ��Ÿ� ���� ������ ��
}

/// <summary>
/// ���͸� ������Ű�� ��ũ��Ʈ. �������� ������Ʈ�� �پ��ִ�.
/// </summary>

public class MobManager : Singleton<MobManager>
{
    public GameObject[] monsters;
    // ������ų ���͸� �迭�� �޾ƿ�
    [SerializeField] Button nextWave_BTN;
    // ���� ���͸� ������ų nextWave ��ư��ü
    int waveIndex = -1;
    // ���° ���̺������� ��Ÿ���� ��, 0���� �ε����� �����̹Ƿ� -1�� �ʱⰪ ����
    [SerializeField] Monster[] mobs;
    // �����Ǵ� ���Ϳ� �پ��ִ� Monster ��ũ��Ʈ�� �迭�� ����
    
    // Start is called before the first frame update
    void Start()
    {
        nextWave_BTN.onClick.AddListener(AddIndex);
        // ���� ���̺� ��ư�� Ŭ������ �� ȣ��

        AddIndex();
        // ó������ �ڵ����� ù��° ���̺갡 ������ AddIndex �Լ� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddIndex()
    {
        // ���̺� �ε����� ������Ű�� �Լ�

        waveIndex++;
        // ���̺� �ε��� ������ 1 ������Ű��
        StartCoroutine(StartWave(waveIndex, mobs[waveIndex].MM.monster_regentime, mobs[waveIndex].MM.monster_limitSpawn));
        // ���̺긦 ���۽��� ���͸� ��ȯ��Ű�� �ڷ�ƾ ����
        // ��Ʈ�� ���·� �����ϸ� �Ű������� 1���� ���� �� �ֱ� ������, �Լ� ���·� ��ŸƮ�ڷ�ƾ�� ȣ����
        // ���̺� �ε��� ��ȣ, ������ �����ð�, ������ �������ѷ��� �Ű������� ����
    }
    public IEnumerator StartWave(int monsterIndex, float regentime, int limitSpawn)
    {
        // ���̺긦 ������ ���Ͱ� �����Ǵ� �ڷ�ƾ
        // ���° ���̺�����, �󸶸�ŭ�� �ֱ�� ������ų��, �󸶸�ŭ ������ų�� ���� �޴´�.


        while (true)
        {
            // �����߿��� ���̺� ���� ��ư�� ��Ȱ��ȭ
            nextWave_BTN.interactable = false;
            if (limitSpawn <= 0)
            {
                break;
                // ���� �������ѷ��� 0�Ʒ��� �������� �ݺ��� Ż��
            }
            limitSpawn--;
            // �ݺ��Ǵ� ���� �������ѷ��� 1�� ���ҽ�Ű��
            GameObject mob = Instantiate(monsters[monsterIndex], transform.position, Quaternion.identity);
            // �����ε����� �´� ���͸� ������ ��ġ���� ������Ų��.

            yield return new WaitForSeconds(regentime);
            // �޾ƿ� �����ֱ� ��ŭ ��ٷȴٰ� �ٽ� �ݺ�
        }
        nextWave_BTN.interactable = true;
        // ������ ������ ��ư�� �ٽ� Ȱ��ȭ��Ű��
        StopCoroutine("StartWave");
        // �ڷ�ƾ ����
    }
}
