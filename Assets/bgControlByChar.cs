using System.Collections.Generic;
using UnityEngine;

public class bgControlByChar : MonoBehaviour
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
        //this.transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        if (cameraTransform != null)
        {
            if (this.transform.position.x + size.x <= cameraTransform.position.x)
            {
                Debug.Log("Se ha salido por la izquierda");
                transform.position = new Vector3(otherBg.position.x + size.x - 0.5f, 0f, 0f);
            }
            else if (this.transform.position.x > cameraTransform.position.x + size.x)
            {
                Debug.Log("Se ha salido por la derecha");
                transform.position = new Vector3(otherBg.position.x - size.x + 0.5f, 0f, 0f);
            }
        }
    }
}
