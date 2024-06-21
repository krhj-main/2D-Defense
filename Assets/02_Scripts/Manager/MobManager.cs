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

public class MobManager : MonoBehaviour
{
    static MobManager instance;

    public static MobManager Instance
    {
        get => instance;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
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
