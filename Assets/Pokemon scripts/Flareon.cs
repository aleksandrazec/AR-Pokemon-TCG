using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flareon : Pokemon
{
    public Flareon(Player myPlayer, GameObject myModel) : base(myPlayer, myModel)
    {
        pokemonName = "Flareon";
        pokemonHP = 130;
        maxPokemonHP = 130;
        List<string> destructiveFlameEnergies = new List<string> { "fire" };
        Attack destructiveFlame = new Attack("DestructiveFlame", destructiveFlameEnergies, 30, "fire");
        pokemonAttacks.Add(destructiveFlame);
        List<string> fightingBlazeEnergies = new List<string> { "fire","double" };
        Attack fightingBlaze = new Attack("FightingBlaze", fightingBlazeEnergies, 90, "fire");
        pokemonAttacks.Add(fightingBlaze);
    }
}
