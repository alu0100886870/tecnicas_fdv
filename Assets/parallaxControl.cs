using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxControl : MonoBehaviour
{
    public Rigidbody2D rb;
    Renderer rend;
    public float scrollSpeed = 0.5F;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        Debug.Log("La velocidad magnitude es: " + rb.velocity.magnitude);
        Debug.Log("La velocidad es: " + rb.velocity);
        if (rb.velocity.magnitude > 0) { 
            Vector2 bgVector = new Vector2(rb.velocity.x, 0);
            for (int i = 0; i < rend.materials.Length; i++)
            {
                float skyModif = 1.0f;
                Material m = rend.materials[i];
                if (i == 0)
                    skyModif = 0.1f;
                else
                    skyModif = 1.0f;
                // Movemos el fondo según el vector de velocidad del personaje, pero solo al 0.05%.
                // Multiplicamos por el indice del material (que hace que los más al fondo vayan más lentos)
                // Multiplicamos por el modificador del cielo, si es el material 0 (más al fondo), entonces que vaya MUY lento.
                m.SetTextureOffset("_MainTex", m.GetTextureOffset("_MainTex") + (bgVector * 0.0005f * (i + 1) * skyModif));
            }
            //rend.material.SetTextureOffset("_MainTex", rend.material.GetTextureOffset("_MainTex") + (bgVector * 0.0005f));
        }

    }
}
