using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovem : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3( moveHorizontal, 0f, 0f);
        transform.position += movement * speed * Time.deltaTime;
    }
}
