using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmander : Pokemon
{
    public Charmander(Player myPlayer, GameObject myModel) : base(myPlayer, myModel)
    {
        pokemonName = "Charmander";
        pokemonHP = 60;
        maxPokemonHP = 60;
        List<string> heatTackleEnergies = new List<string> { "fire" };
        Attack heatTackle = new Attack("HeatTackle", heatTackleEnergies, 30, "fire");
        pokemonAttacks.Add(heatTackle);
    }
}
