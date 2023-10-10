using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehaivour : MonoBehaviour
{
    
    Transform Objectiu;

    Rigidbody2D m_Rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        Objectiu = CapturaManager.GestioCaptura.objectiu;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 Direccio = Objectiu.position - transform.position;
        m_Rigidbody.velocity = Direccio.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            this.GetComponent<Pooleable>().ReturnToPool();
        switch (CapturaManager.GestioCaptura.m_Currentball)
        {
            case CapturaManager.States.Pokeball:
                GameManager.Instance.m_Inventario.UsarPokeball();
                break;
            case CapturaManager.States.Honorball:
                GameManager.Instance.m_Inventario.UsarHonorball();
                break;
            case CapturaManager.States.Ultraball:
                GameManager.Instance.m_Inventario.UsarUltraball();
                break;
            case CapturaManager.States.Masterball:
                GameManager.Instance.m_Inventario.UsarMasterball();
                break;

        }
            
            
    }
}
