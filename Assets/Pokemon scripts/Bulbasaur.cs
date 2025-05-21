using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulbasaur : Pokemon
{
    public Bulbasaur(Player myPlayer, GameObject myModel) : base(myPlayer, myModel)
    {
        pokemonName = "Bulbasaur";
        pokemonHP = 70;
        List<string> leechSeedEnergies = new List<string> { "grass", "colorless" };
        Attack leechSeed = new Attack("LeechSeed", leechSeedEnergies, 20, "grass");
        pokemonAttacks.Add(leechSeed);
    }

}
