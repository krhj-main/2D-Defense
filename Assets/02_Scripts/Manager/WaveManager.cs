using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : Singleton<WaveManager>
{
    int monsterIndex;
    GameObject[] wave_Mob;
    MonsterStat[]   stat;
    Button wavestart_BTN;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClickNextWave(int monsterIndex)
    {
        SpawnNextWave(monsterIndex);
    }
    void SpawnNextWave(int monsterIndex)
    {
        for (int i = 0; i < wave_Mob.Length; i++)
        {
            if (monsterIndex == i)
            {
                //MobManager.Instance.StartCoroutine(MobManager.Instance.StartWave(i,stat[i].monster_regentime,stat[i].monster_limitSpawn));
                StartCoroutine(MobManager.Instance.StartWave(i, stat[i].monster_regentime, stat[i].monster_limitSpawn));
            }
        }
    }
}
