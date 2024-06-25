using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMuzzle : MonoBehaviour
{
    Vector2 mousePos, target;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,Vector3.right * 100f, Color.red);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mousePos.y - target.y, mousePos.x - target.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle-90,Vector3.forward);
    }
}
