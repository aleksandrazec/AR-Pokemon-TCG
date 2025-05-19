using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wooloo : Pokemon
{
    public Wooloo()
    {
        pokemonName = "Wooloo";
        pokemonHP = 70;
        List<string> smashKickEnergies = new List<string> { "colorless", "double" };
        Attack smashKick = new Attack("SmashKick", smashKickEnergies, 50, "colorless");
        pokemonAttacks.Add(smashKick);
    }
}
