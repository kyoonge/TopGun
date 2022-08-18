using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float enemySpeed = 7f;
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * enemySpeed);


        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);
        if (view.y < -5 )
        {
            Debug.Log("Game Over");
            gameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        //Debug.Log()
        Instantiate(Explosion, transform.position, transform.rotation);
        if(collision.collider.CompareTag("PLAYER") )
        {
            gameManager.instance.GameOver();
        }
        else
        {
            gameManager.instance.AddScore(1);
        }
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        
    }

    private void OnBecameInvisible()
    {
        Debug.Log("안보임");
        Destroy(this.gameObject);
    }

    private void OnBecameVisible()
    {
        Debug.Log("보임");
    }
}
