using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(-1, 0);
        rb.AddForce(dir * speed * Time.deltaTime);

        if (transform.position.x < -10)
            this.gameObject.SetActive(false);
    }
}
