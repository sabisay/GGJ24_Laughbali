using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    float hiz = 6f;
    bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) canMove = true;
        if(canMove) transform.position = Vector3.MoveTowards(transform.position, new Vector3(21f, 2f, -41f), hiz * Time.deltaTime);
    }
}
