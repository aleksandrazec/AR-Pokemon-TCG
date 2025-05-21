using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchic : Pokemon
{
    public Torchic(Player myPlayer, GameObject myModel) : base(myPlayer, myModel)
    {
        pokemonName = "Torchic";
        pokemonHP = 60;
        List<string> scratchEnergies = new List<string> { "fire", "colorless" };
        Attack scratch = new Attack("Scratch", scratchEnergies, 20, "grass");
        pokemonAttacks.Add(scratch);
    }
}
