using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreEdit : MonoBehaviour
{
    TextMeshProUGUI m_TextMeshProUGUI;
    [SerializeField]
    LocalRecordSO m_Record;
    void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        m_TextMeshProUGUI.text = "Record: " + m_Record.m_Score;
    }
    public void CanviRecord()
    {
        m_TextMeshProUGUI.text = "Record: " + m_Record.m_Score;
    }
}
