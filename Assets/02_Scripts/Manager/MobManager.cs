using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterStat
{
    public float monster_HP;
    public float monster_Speed;
    public float monster_regentime;
}

public class MobManager : Singleton<MobManager>
{
   
    [SerializeField] GameObject[] monsters;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator StartWave(float regentime)
    {
        while (true)
        {
            GameObject mob = Instantiate(monsters[0], transform.position, Quaternion.identity);

            yield return new WaitForSeconds(regentime);
        }

    }
}
