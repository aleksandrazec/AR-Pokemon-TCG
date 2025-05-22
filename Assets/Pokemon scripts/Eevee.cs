using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eevee : Pokemon
{
    public Eevee(Player myPlayer, GameObject myModel) : base(myPlayer, myModel)
    {
        pokemonName = "Eevee";
        pokemonHP = 70;
        maxPokemonHP = 70;
        List<string> cheerUpEnergies = new List<string> { "colorless" };
        Attack cheerUp = new Attack("CheerUp", cheerUpEnergies, 30, "colorless");
        pokemonAttacks.Add(cheerUp);
        List<string> kickEnergies = new List<string> { "double" };
        Attack kick = new Attack("Kick", kickEnergies, 20, "colorless");
        pokemonAttacks.Add(kick);
    }
}
