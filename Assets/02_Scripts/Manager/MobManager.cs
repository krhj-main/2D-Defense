using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Monster
{
    public int mob_HP;
    public int mob_MaxHP;
    public float mob_Speed;
    public float mob_Dmg;
}
[System.Serializable]
public class DotMob : Monster
{
    public float mob_DotDmg;
}
[System.Serializable]
public class LongMob : Monster
{
    public float mob_LongDmg;
}

public class MobManager : MonoBehaviour
{
    static MobManager instance;

    public static MobManager Instance
    {
        get => instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public Monster myMob;

    [SerializeField] GameObject monster;

    public float spawn_delay;
    // ���� ���� �ֱ�
    float count;
    // ���� �ֱ� ����� ī��Ʈ ��

    [SerializeField] float CreateYpos;
    // ���� ������ġ ���� Y�� ��

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawning");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Spawning()
    {
        while (true)
        {
            count++;

            
            float ypos = Random.Range(-CreateYpos, CreateYpos);

            GameObject gg = Instantiate(monster);
            gg.transform.position = new Vector2(transform.position.x, transform.position.y + ypos);

            spawn_delay = 2f / (count*0.5f);
            yield return new WaitForSeconds(spawn_delay);
        }
    }
}
