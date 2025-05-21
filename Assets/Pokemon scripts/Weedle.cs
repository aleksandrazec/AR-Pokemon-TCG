using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weedle : Pokemon
{

   public Weedle(Player myPlayer, GameObject myModel) : base(myPlayer, myModel)
    {
        pokemonName = "Weedle";
        pokemonHP = 50;
        maxPokemonHP = 50;
        List<string> ramEnergies = new List<string> { "grass" };
        Attack ram = new Attack("Ram", ramEnergies, 10, "grass");
        pokemonAttacks.Add(ram);
        List<string> bugBiteEnergies = new List<string> { "double" };
        Attack bugBite = new Attack("BugBite", bugBiteEnergies, 10, "colorless");
        pokemonAttacks.Add(bugBite);
    }
}
