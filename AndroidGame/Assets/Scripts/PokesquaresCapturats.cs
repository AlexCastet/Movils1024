using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PokesquaresCapturats : MonoBehaviour
{
    TextMeshProUGUI m_TextMeshProUGUI;
    [SerializeField]
    Inventario m_Record;
    void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        m_TextMeshProUGUI.text = "Pokesquares Capturats: " + m_Record.PokeSquaresConseguits;
    }
}
