using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaporeon : Pokemon
{
    public Vaporeon()
    {
        pokemonName = "Vaporeon";
        pokemonHP = 130;
        List<string> spiralDrainEnergies = new List<string> { "water" };
        Attack spiralDrain = new Attack("SpiralDrain", spiralDrainEnergies, 30, "water");
        pokemonAttacks.Add(spiralDrain);
        List<string> fightingWhirlpoolEnergies = new List<string> { "water", "double"};
        Attack fightingWhirlpool = new Attack("FightingWhirlpool", fightingWhirlpoolEnergies, 90, "water");
        pokemonAttacks.Add(fightingWhirlpool);
    }
}
