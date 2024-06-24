using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MonsterStat
{
    public float monster_HP;
    public float monster_Speed;
    public float monster_regentime;
    public int monster_limitSpawn;
}

public class MobManager : Singleton<MobManager>
{
    public GameObject[] monsters;
    [SerializeField] Button nextWave_BTN;
    int waveIndex = -1;
    [SerializeField] Monster[] mobs;
    
    // Start is called before the first frame update
    void Start()
    {
        nextWave_BTN.onClick.AddListener(AddIndex);

        AddIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddIndex()
    {
        waveIndex++;
        StartCoroutine(StartWave(waveIndex, mobs[waveIndex].MM.monster_regentime, mobs[waveIndex].MM.monster_limitSpawn));
    }
    public IEnumerator StartWave(int monsterIndex, float regentime, int limitSpawn)
    {
        while (true)
        {
            if (limitSpawn <= 0)
            {
                break;
            }
            limitSpawn--;
            GameObject mob = Instantiate(monsters[monsterIndex], transform.position, Quaternion.identity);

            yield return new WaitForSeconds(regentime);
        }
        StopCoroutine("StartWave");
    }
}
