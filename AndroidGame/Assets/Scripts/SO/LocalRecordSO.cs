using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "SO/LocalRecord")]
public class LocalRecordSO : ScriptableObject
{
    public int m_Score;
    public int m_Movements;
    public int m_NumPokemons;
    public int m_MaxScore;

    public void DesafiarRecord(int newScore)
    {
        if(m_MaxScore <= newScore)
        {
            m_MaxScore = newScore;
            Debug.Log("NEW RECORD");
        }
        else
        {
            Debug.Log("NICE TRY");
        }
            
    }
}
