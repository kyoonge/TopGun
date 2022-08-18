using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGOD : MonoBehaviour
{
    private float curTime = 0f;
    
    public float createTime = 1f;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > createTime)
        {
            Instantiate(Enemy,new Vector3(Random.Range(-2.8f,2.8f),0,0) + transform.position  ,transform.rotation );
            curTime = 0f;
        }
    }
}
