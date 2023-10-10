using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEditor.VersionControl.Asset;
using Random = UnityEngine.Random;

public class CapturaManager : MonoBehaviour
{
    private static CapturaManager m_GestioCaptura;
    public static CapturaManager GestioCaptura
    {
        get { return m_GestioCaptura; }
    }

    public enum States { Pokeball, Honorball, Ultraball, Masterball }
    public States m_Currentball;

    [SerializeField] 
    Transform m_Objectiu;
    public Transform objectiu => m_Objectiu;

    [SerializeField]
    Pool m_SquarePool;
    public Pool SquarePool => m_SquarePool;

    void Awake()
    {
        if (m_GestioCaptura == null)
            m_GestioCaptura = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CanviNegatiu()
    {
        if (m_Currentball == States.Pokeball)
        {
            m_Currentball = States.Masterball;
        }
        else
        {
            m_Currentball -= 1;
        }
    }
    public void CanviPositiu()
    {
        if (m_Currentball == States.Masterball)
        {
            m_Currentball = States.Pokeball;
        }
        else
        {
            m_Currentball += 1;
        }
    }
    public void TornaAlMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
