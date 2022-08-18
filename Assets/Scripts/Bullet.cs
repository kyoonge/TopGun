using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);

        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);
        if (view.y > 1000)
        {
            Destroy(gameObject); 
        }      
    }
}
