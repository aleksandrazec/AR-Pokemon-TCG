using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lapras : Pokemon
{
    public Lapras()
    {
        pokemonName = "Eevee";
        pokemonHP = 130;
        List<string> waterGunEnergies = new List<string> { "water" };
        Attack waterGun = new Attack("WaterGun", waterGunEnergies, 30, "water");
        pokemonAttacks.Add(waterGun);
        List<string> surfEnergies = new List<string> { "water","double" };
        Attack surf = new Attack("Surf", surfEnergies, 80, "water");
        pokemonAttacks.Add(surf);
    }
}
