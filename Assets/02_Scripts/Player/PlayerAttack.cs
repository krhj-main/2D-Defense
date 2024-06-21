using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(mousePos,Vector2.zero,15f);
            Debug.DrawRay(mousePos,Vector3.forward * 30f,Color.red,2f);
            Debug.Log(hit.point);

            if (hit.collider != null)
            {
                GameObject gg = hit.collider.gameObject;
                if (gg.CompareTag("Monster"))
                {

                }
            }
        }
    }
}
