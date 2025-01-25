using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verticalmovement : MonoBehaviour
{
    public float speedV = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0f, speedV, 0f);
        transform.position += movement * speedV * Time.deltaTime;
    }
}
