using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Blackhole : MonoBehaviour
{
    public LayerMask m_MagneticLayers;
    //public Vector3 m_Position;
    public static float m_Radius = 4;
    public float m_Force;
    private Vector2 distance;
    private float shakeAmount = 5f;
    

    void Start()
    {
        transform.position += UnityEngine.Random.insideUnitSphere * shakeAmount;
        m_Radius *= (1 - Score.level*0.2f);
        
        
    }
    void FixedUpdate ()
    {
        Collider2D[] colliders;
        Rigidbody2D rigidbody;
        colliders = Physics2D.OverlapCircleAll (transform.position, m_Radius, m_MagneticLayers);
        foreach (Collider2D collider in colliders)
        {
            GameObject obj = collider.gameObject;
            rigidbody = (Rigidbody2D) obj.GetComponent<Rigidbody2D>();
            if (rigidbody == null)
            {
                continue;
            }
            Vector3 m_Position = obj.transform.position;
            distance.x = transform.position.x - m_Position.x;
            distance.y = transform.position.y - m_Position.y;
            float GForce = (float)(Math.Pow(distance.x,2)+Math.Pow(distance.y,2))*10;
            rigidbody.AddForce (m_Force * (transform.position - m_Position)/GForce);
            
        }
    }
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, m_Radius);
    }

}


