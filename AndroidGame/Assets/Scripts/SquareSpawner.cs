using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    [SerializeField]
    private float m_SpawnRate;
    //  private float m_SpawnRateDelta = 3f;

    [SerializeField]
    private Transform[] m_SpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            GameObject spawned = CapturaManager.GestioCaptura.SquarePool.GetElement();
            //spawned.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, 0, 0);
            spawned.transform.position = m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)].position;
            yield return new WaitForSeconds(m_SpawnRate);
        }
    }
}
