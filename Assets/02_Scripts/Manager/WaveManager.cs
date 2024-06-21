using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MobManager.Instance.StartCoroutine("StartWave",1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
