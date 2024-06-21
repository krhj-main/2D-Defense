using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour
{
    [SerializeField] bool isDebuging;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackMouse();   
    }
    void AttackMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward,30f);
            if (isDebuging)
            {
                Debug.DrawRay(mousePos, transform.forward * 10, Color.red, 0.5f);
            }

            if (hit.collider.tag == "Monster")
            {
                Debug.Log("몬스터 감지");
                GameObject go = hit.collider.gameObject;
                Destroy(go,1f);
            }
        }
    }
}
