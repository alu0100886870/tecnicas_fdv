using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgContol : MonoBehaviour
{
    public Transform cameraTransform;
    private SpriteRenderer render;
    Vector3 size;
    public float speed = 5f;
    public Transform otherBg;
    // Start is called before the first frame update
    void Start()
    {
        render = this.GetComponentInChildren<SpriteRenderer>();
        size = render.bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        if (cameraTransform != null)
        {
            if (this.transform.position.x + size.x <= 0)
            {
                Debug.Log("Se ha salido!");
                transform.position = new Vector3(otherBg.position.x + size.x -0.5f, 0f, 0f);
            }
        }
    }
}
