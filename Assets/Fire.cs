using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public static int fire_counter;
    public float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Change the sprite's rotation
        Vector3 v = target - transform.position;
        v.z = 0;
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, v);
        if (Input.GetMouseButtonDown(0))
        {
            fire_counter += 1;
            GameObject b = Instantiate(bullet,transform.position,transform.rotation);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.AddForce(v*speed); 
        }
    }
}
