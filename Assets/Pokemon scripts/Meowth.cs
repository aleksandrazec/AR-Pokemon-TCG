using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meowth : Pokemon
{
    public Meowth(Player myPlayer, GameObject myModel) : base(myPlayer, myModel)
    {
        pokemonName = "Meowth";
        pokemonHP = 70;
        List<string> comeHereRightMeowEnergies = new List<string> { "colorless" };
        Attack comeHereRightMeow = new Attack("ComeHereRightMeow", comeHereRightMeowEnergies, 30, "colorless");
        pokemonAttacks.Add(comeHereRightMeow);
        List<string> digClawsEnergies = new List<string> { "double" };
        Attack digClaws = new Attack("DigClaws", digClawsEnergies, 20, "colorless");
        pokemonAttacks.Add(digClaws);
    }
}
