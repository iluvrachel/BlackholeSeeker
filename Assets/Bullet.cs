using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isVis = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (!isVis) {
			Destroy (gameObject);
		}

    }

    private void OnBecameVisible() 
    {
        isVis = true;
    }

    private void OnBecameInvisible() 
    {
        isVis = false;
    } 
}
