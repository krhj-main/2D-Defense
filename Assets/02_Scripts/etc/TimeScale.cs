using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScale : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeTXT;
    int toggle = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeTXT.text = string.Format("{0}x", (toggle % 3) + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeTimeScale()
    {
        toggle++;
        timeTXT.text = string.Format("{0}x", (toggle % 3) + 1);
        Time.timeScale = (toggle % 3) + 1;
    }
}
