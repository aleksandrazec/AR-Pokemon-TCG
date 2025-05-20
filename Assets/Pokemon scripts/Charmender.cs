using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmender : Pokemon
{
    public Charmender(Player myPlayer, GameObject myModel) : base(myPlayer, myModel)
    {
        pokemonName = "Charmender";
        pokemonHP = 60;
        List<string> heatTackleEnergies = new List<string> { "fire" };
        Attack heatTackle = new Attack("HeatTackle", heatTackleEnergies, 30, "fire");
        pokemonAttacks.Add(heatTackle);
    }
}
