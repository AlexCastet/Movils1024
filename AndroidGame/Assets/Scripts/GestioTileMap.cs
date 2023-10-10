using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GestioTileMap : MonoBehaviour
{
    [SerializeField] 
    Tilemap map;

    [SerializeField]
    Transform TransdormIni;
    [SerializeField]
    int Tamany = 4;
    [SerializeField]
    Tile[] Tiles;

    private void Awake()
    {
        map = GetComponent<Tilemap>();
    }

    void Start()
    {
        OnEtsTileMap();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnEtsTileMap();
        }
    }
    public void PintarSegunMatriz(int[,] matriz)
    {
        Vector3Int CasellaIni = map.WorldToCell(TransdormIni.position);
        CasellaIni.z = 0;
        int Pokeballs = 0;
        int Ultraballs = 0;
        int Masterballs = 0;
        for (int i = 0; i < Tamany; i++)
        {
            for (int j = 0; j < Tamany; j++)
            {
                Vector3Int CasellaActual = CasellaIni;
                CasellaActual.x += i;
                CasellaActual.y -= j;
                TileBase tile = null;
                
                switch (matriz[i, j])
                {
                    case 0:
                        tile = null;
                        break;
                  
                    case 2:
                        tile = Tiles[0];
                        Pokeballs++;
                        break;
                    case 4:
                        tile = Tiles[1];
                        Ultraballs++;
                        break;
                    case 8:
                        tile = Tiles[2];
                        Masterballs++;
                        break;
                    case 16:
                        tile = Tiles[3];
                        break;

                }
                map.SetTile(CasellaActual, tile);
            }
        }
        Debug.Log("Pokeballs: " + Pokeballs);
        Debug.Log("Ultraballs: " + Ultraballs);
        Debug.Log("Masterballs: " + Masterballs);
    }
    private void OnEtsTileMap()
    {
        
        //Vector3 size = TransdormFinal.position-TransdormIni.position;
        Vector3Int vectorini = map.WorldToCell(TransdormIni.position);
        vectorini.z = 0;
        
        

        Debug.Log(map.GetTile(vectorini));
        Debug.Log(vectorini.ToString());
    

    }
}
