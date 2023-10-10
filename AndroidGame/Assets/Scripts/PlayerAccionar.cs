using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerAccionar : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset m_inputasset;

    private InputActionAsset m_inputAction;
    
    private InputAction m_PosicionAction;

    private Vector2 m_PositionInicial;
    private Vector2 m_PositionFinal;

    [SerializeField]
    private GameEventVector2 m_Movimiento;
    [SerializeField]
    private GameEvent m_TotsDreta;
    [SerializeField]
    private GameEvent m_TotsEsquerra;
    [SerializeField]
    private GameEvent m_TotsAmunt;
    [SerializeField]
    private GameEvent m_TotsAbaix;

    void Awake()
    {
        m_inputAction = Instantiate(m_inputasset);
        m_inputAction.FindActionMap("Playing").FindAction("Mover").performed += GetPressed;
        m_inputAction.FindActionMap("Playing").FindAction("Mover").started += GetFirstTap;
        m_inputAction.FindActionMap("Playing").FindAction("Mover").canceled += GetFinalTap;

        m_PosicionAction = m_inputAction.FindActionMap("Playing").FindAction("Posicion");

        m_inputAction.FindActionMap("Playing").Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GetFirstTap(InputAction.CallbackContext context)
    {
        m_PositionInicial = m_PosicionAction.ReadValue<Vector2>();

    }

    private void GetFinalTap(InputAction.CallbackContext context)
    {
        m_PositionFinal = m_PosicionAction.ReadValue<Vector2>();

        MoverFicha();
    }

    private void MoverFicha()
    {
        Vector2 Direccio = m_PositionFinal - m_PositionInicial;
        float x = math.abs(Direccio.normalized.x);
        float y = math.abs(Direccio.normalized.y);
        if (x>y)
        {
            if (Direccio.normalized.x > 0)
            {
                //Right
                Debug.Log("Derecha");
                //m_Movimiento.Raise(new Vector2(2, 0));
                m_TotsDreta.Raise();
            }
            else if (Direccio.normalized.x < 0)
            {
                //Left
                Debug.Log("Izquierda");
                //m_Movimiento.Raise(new Vector2(-2, 0));
                m_TotsEsquerra.Raise();
            }
        } 
        else if(x < y)
        {
            if (Direccio.normalized.y > 0)
            {
                //Up
                Debug.Log("Arriba");
                //m_Movimiento.Raise(new Vector2(0, 2));
                m_TotsAmunt.Raise();
            }
            else if (Direccio.normalized.y < 0)
            {
                //Down
                Debug.Log("Abajo");
                //m_Movimiento.Raise(new Vector2(0, -2));
                m_TotsAbaix.Raise();
            }
        }
        
    }
    private void GetPressed(InputAction.CallbackContext context)
    {
        Debug.Log("has clickado");
    }
}
