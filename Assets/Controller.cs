using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Vector3 target;

    //private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Change the sprite's rotation
        Vector3 v = target - transform.position;
        v.z = 0;
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, v);
        transform.rotation = rotation;
    }
}
