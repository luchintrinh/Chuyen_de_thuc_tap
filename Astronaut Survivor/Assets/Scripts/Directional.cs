using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directional : MonoBehaviour
{
    Movement move;
    // Start is called before the first frame update
    void Start()
    {
        move = transform.GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (Vector3)move.mousePos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0, 0, angle);
        Debug.Log(angle);
    }
}
