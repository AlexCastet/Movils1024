using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "SO/Inventari")]
public class Inventario : ScriptableObject
{
    public int Pokeballs;
    public int Honorballs;
    public int Ultraballs;
    public int Masterballs;
    public int PokeSquaresConseguits;
    public int PokeSquaresLegendarisConseguits;

    public void UsarPokeball()
    {
        if(Pokeballs <= 0)
        {
            Debug.LogError("NO TENS POKEBALLS");
        }
        else
        {
            Pokeballs--;
            PokeSquareCaptured();
        }
        
    }
    public void UsarHonorball()
    {
        if (Honorballs <= 0)
        {
            //Donar avis de que no te Pokeballs
        }
        else
        {
            Honorballs--;
            PokeSquareCaptured();
        }

    }
    public void UsarUltraball()
    {
        if (Ultraballs <= 0)
        {
            //Donar avis de que no te Pokeballs
        }
        else
        {
            Ultraballs--;
            PokeSquareCaptured();
        }

    }
    public void UsarMasterball()
    {
        if (Masterballs <= 0)
        {
            //Donar avis de que no te Pokeballs
        }
        else
        {
            Masterballs--;
            PokeSquareCaptured();
        }

    }
    private void PokeSquareCaptured()
    {
        PokeSquaresConseguits++;
    }
    public void PokeSquaresLegendarisCaptured()
    {
        PokeSquaresLegendarisConseguits++;
    }
}
