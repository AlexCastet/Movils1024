using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get { return m_Instance; }
    }
    [SerializeField]
    public Sprite m_Sprites;
    [SerializeField]
    public GameEventMatriu m_Draw;
    [SerializeField]
    public GameEvent m_CanviScore;
    [SerializeField]
    public LocalRecordSO m_Record;
    [SerializeField]
    public Inventario m_Inventario;

    public int[,] MatriuGame;
    void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
        m_Record.m_Score = 0;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        m_Draw.Raise(MatriuGame);
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void Entrada4x4()
    {
        SceneManager.LoadScene("Play 4x4");
        MatriuGame = new int[4, 4];
        LlenarMatriz();
    }
    public void Entrada5x5()
    {
        SceneManager.LoadScene("Play 5x5");
        MatriuGame = new int[5, 5];
        LlenarMatriz();
    }
    public void Entrada6x6()
    {
        SceneManager.LoadScene("Play 6x6");
        MatriuGame = new int[6, 6];
        LlenarMatriz();
    }
    public void ModoCaptura()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
    
    public void PintarTileMap()
    {

    }
    private void LlenarMatriz()
    {
        
        
        for (int i = 0; i < MatriuGame.GetLength(0); i++)
        {
            for (int j = 0; j < MatriuGame.GetLength(0); j++)
            {
               MatriuGame[i, j] = 0; 
            }
        }
        NextStep();
    }

    private void NextStep()
    {
        RandomSpawn();
        m_Draw.Raise(MatriuGame);
        //MostrarMatriu(MatriuGame);
        ComprovarDerrota();
        ComprovarVictoria();

    }

    private void MostrarMatriu(int[,] matriuGame)
    {
        for (int i = 0; i < matriuGame.GetLength(0); i++)
        {
            for (int j = 0; j < matriuGame.GetLength(0); j++)
            {
                Debug.Log(matriuGame[i, j]);
            }
        }
    }

    private void ComprovarDerrota()
    {
        int cerostrobats = 0;
        for (int i = 0; i < MatriuGame.GetLength(0); i++)
        {
            for (int j = 0; j < MatriuGame.GetLength(0); j++)
            {
                if (MatriuGame[i, j] == 0)
                {
                    cerostrobats++;
                    
                }
            }
        }
        if( cerostrobats == 0)
        {
            GameOver();
        }
    }
    private void ComprovarVictoria()
    {
        for (int i = 0; i < MatriuGame.GetLength(0); i++)
        {
            for (int j = 0; j < MatriuGame.GetLength(0); j++)
            {
                if (MatriuGame[i, j] == 32)
                {
                    Debug.Log("YOU WIN, congraTULAtions");
                    m_Record.DesafiarRecord(m_Record.m_Score);
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }

    private void GameOver()
    {
        m_Record.DesafiarRecord(m_Record.m_Score);
        SceneManager.LoadScene("GameOver");
    }
    public void Tornar()
    {
        m_Record.m_Score = 0;
        SceneManager.LoadScene("MainMenu");
    }

    private void RandomSpawn()
    {
        int x_Ramdom = Random.Range(0, MatriuGame.GetLength(0));
        int y_Ramdom = Random.Range(0, MatriuGame.GetLength(0));
        while (MatriuGame[x_Ramdom, y_Ramdom] != 0)
        {
            x_Ramdom = Random.Range(0, MatriuGame.GetLength(0));
            y_Ramdom = Random.Range(0, MatriuGame.GetLength(0));
        }
        MatriuGame[x_Ramdom, y_Ramdom] = 2;

        Debug.Log(x_Ramdom + ", " + y_Ramdom);
    }

    public void Up()
    {
        for (int i = 0; i < MatriuGame.GetLength(0); i++)
        {
            for (int j = 0; j < MatriuGame.GetLength(0); j++)
            {
                if (MatriuGame[i, j] != 0)
                {
                    
                    int corredor = 1;
                    int Valor = MatriuGame[i, j];
                    bool hetopat = false;
                    while (j >= corredor)
                    {
                        
                        if (MatriuGame[i, j - corredor] != 0)
                        {
                            hetopat = false;
                            if (MatriuGame[i, j - corredor] == Valor)
                            {
                                AgafarPokeball(Valor);
                                Valor = Valor * 2;
                                m_Record.m_Score += Valor;
                                m_CanviScore.Raise();
                                


                            }
                            else
                            {
                                hetopat = true;
                                
                                break;
                            }
                        }
                        corredor++;
                        


                    }
                    if (!hetopat)
                    {
                        MatriuGame[i, j] = 0;
                        MatriuGame[i, 0] = Valor;
                        
                    }
                    else
                    {
                        MatriuGame[i, j] = 0;
                        MatriuGame[i, j - (corredor - 1)] = Valor;
                        
                    }

                }
            }
        }
        NextStep();
    }

    
    public void Right()
    {
        for (int i = MatriuGame.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = MatriuGame.GetLength(0) - 1; j >= 0; j--)
            {
                if (MatriuGame[i, j] != 0)
                {
                    bool hetopat = false;
                    int corredor = 1;
                    int Valor = MatriuGame[i, j];
                    while (i + corredor < MatriuGame.GetLength(0))
                    {
                        hetopat = false;

                        if (MatriuGame[i + corredor, j] != 0)
                        {
                            
                            if (MatriuGame[i + corredor, j] == Valor)
                            {
                                AgafarPokeball(Valor);
                                Valor = Valor * 2;

                                m_Record.m_Score += Valor;
                                m_CanviScore.Raise();
                            }
                            else
                            {
                                hetopat = true;
                                
                                break;
                            }
                            
                        }
                        corredor++;
                        
                        
                        
                    }
                    if (!hetopat)
                    {
                        MatriuGame[i, j] = 0;
                        MatriuGame[MatriuGame.GetLength(0) - 1, j] = Valor;
                        
                    }
                    else
                    {
                        MatriuGame[i, j] = 0;
                        MatriuGame[i + (corredor - 1), j] = Valor;
                        
                    }
                    Debug.Log("Estoy en " + i + " ," + j + " y he acabado en " + (i + (corredor - 1)) + " ," + j+" y mi valor es"+Valor);
                }
                
            }
        }
        NextStep();
    }

    

    public void Down()
    {
        for (int i = 0; i < MatriuGame.GetLength(0); i++)
        {
            for (int j = MatriuGame.GetLength(0)-1; j >=0 ; j--)
            {
                if (MatriuGame[i, j] != 0)
                {
                    bool hetopat = false;
                    int corredor = 1;
                    int Valor = MatriuGame[i, j];
                    while (j + corredor < MatriuGame.GetLength(0))
                    {
                        hetopat = false;

                        if (MatriuGame[i, j + corredor] != 0)
                        {
                            
                            if (MatriuGame[i, j + corredor] == Valor)
                            {
                                AgafarPokeball(Valor);
                                Valor = Valor * 2;

                                m_Record.m_Score += Valor;
                                m_CanviScore.Raise();
                            }
                            else
                            {
                                hetopat = true;
                                
                                break;
                            }

                        }
                        corredor++;
                        
                        
                        
                    }
                    if (!hetopat)
                    {
                        MatriuGame[i, j] = 0;
                        MatriuGame[i, MatriuGame.GetLength(0) - 1] = Valor;
                        
                    }
                    else
                    {
                        MatriuGame[i, j] = 0;
                        MatriuGame[i, j + (corredor - 1)] = Valor;
                        
                    }

                }
            }
        }
        NextStep();
    }
    public void Left()
    {
        for (int i = 0; i < MatriuGame.GetLength(0); i++)
        {
            for (int j = 0; j < MatriuGame.GetLength(0); j++)
            {
                if (MatriuGame[i, j] != 0)
                {
                    bool hetopat = false;
                    int corredor = 1;
                    int Valor = MatriuGame[i, j];
                    while (i >= corredor)
                    {
                        hetopat = false;

                        if (MatriuGame[i - corredor, j] != 0)
                        {
                            if (MatriuGame[i - corredor, j] == Valor)
                            {
                                AgafarPokeball(Valor);
                                Valor = Valor * 2;

                                m_Record.m_Score += Valor;
                                m_CanviScore.Raise();
                            }
                            else
                            {
                                hetopat = true;
                             
                                break;
                            }

                        }
                        corredor++;
                        
                        
                        
                    }
                    if (!hetopat)
                    {
                        MatriuGame[i, j] = 0;
                        MatriuGame[0, j] = Valor;
                        
                    }
                    else
                    {
                        MatriuGame[i, j] = 0;
                        MatriuGame[i - (corredor - 1), j] = Valor;
                        
                    }

                }
            }
        }
        NextStep();
    }

    private void AgafarPokeball(int valor)
    {
        switch (valor)
        {
            case 2:
                m_Inventario.Pokeballs++;
                break;
            case 4:
                break;
            case 8:
                m_Inventario.Ultraballs++;
                break;
            case 16:
                m_Inventario.Masterballs++;
                break;
        }
    }
}
