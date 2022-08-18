using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    public Material material;

    private Vector2 currentOffset;

    // Start is called before the first frame update
    void Start()
    {
        material = this.GetComponent<Renderer>().material;
        currentOffset = material.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        currentOffset += new Vector2(Time.deltaTime * scrollSpeed, 0); 
         //s   Time.deltaTime * scrollSpeed;

        //material.SetTectureOffset("_MainTex", new Vector2(offset, 0));
        material.SetTextureOffset("_MainTex",currentOffset);
    }
}
