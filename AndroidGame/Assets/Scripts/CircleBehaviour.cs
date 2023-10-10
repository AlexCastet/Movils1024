using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class CircleBehaivour : MonoBehaviour
{
    // Start is called before the first frame update
    
    SpriteRenderer m_SpriteRenderer;
    Rigidbody2D m_Rigidbody;
    [SerializeField]
    private InputActionAsset m_inputasset;

    private InputActionAsset m_inputAction;

    

    [SerializeField]
    private Inventario m_Inventario;

  


    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_inputAction = Instantiate(m_inputasset);
        m_inputAction.FindActionMap("Captura").FindAction("Disparar").performed += LanzarBall;
        m_inputAction.FindActionMap("Captura").FindAction("CanviarBallIzq").performed += CanviarBallIzq;
        m_inputAction.FindActionMap("Captura").FindAction("CanviarBallDer").performed += CanviarBallDer;
        m_inputAction.FindActionMap("Captura").Enable();
    }

    private void LanzarBall(InputAction.CallbackContext context)
    {
        
    }
    private void CanviarBallIzq(InputAction.CallbackContext context)
    {
            CapturaManager.GestioCaptura.CanviNegatiu();
    }
    private void CanviarBallDer(InputAction.CallbackContext context)
    {
        CapturaManager.GestioCaptura.CanviPositiu();
    }


    // Update is called once per frame
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_Rigidbody.velocity = new Vector2(0, 3);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Rigidbody.velocity = new Vector2(0, -3);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.velocity = new Vector2(3, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.velocity = new Vector2(-3, 0);
        }
    }
    public void Moverse(Vector2 direccio)
    {
        m_Rigidbody.velocity = direccio;
    }
    
    

}
