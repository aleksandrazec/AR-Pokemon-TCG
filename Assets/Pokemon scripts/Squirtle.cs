using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirtle : Pokemon
{
    public Squirtle(Player myPlayer, GameObject myModel) : base(myPlayer, myModel)
    {
        pokemonName = "Squirtle";
        pokemonHP = 60;
        List<string> withdrawEnergies = new List<string> { "water" };
        Attack withdraw = new Attack("Withdraw", withdrawEnergies, 30, "water");
        pokemonAttacks.Add(withdraw);
        List<string> skullBashEnergies = new List<string> { "water", "colorless" };
        Attack skullBash = new Attack("SkullBash", skullBashEnergies, 20, "water");
        pokemonAttacks.Add(skullBash);
    }
}
