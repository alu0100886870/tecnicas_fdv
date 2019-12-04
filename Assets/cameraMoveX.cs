using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveX : MonoBehaviour
{
    public Transform follow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(follow.position.x, transform.position.y);
    }
}
