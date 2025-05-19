using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<string> energies= new List<string>();
    Pokemon activePokemon;
    List<Pokemon> passivePokemon;

    public void endTurn(Player otherPlayer)
    {
        if (!energies.Any()) {
            activePokemon.attack(energies, otherPlayer.activePokemon);
            energies.Clear();
        }
    }
    public void addEnergy(string energy)
    {
        energies.Add(energy);
    }
    public void heal(string healCard)
    {
        if (healCard == "potion")
        {
            activePokemon.healPokemon(30);
        } else if (healCard == "superPotion")
        {
            activePokemon.healPokemon(60);
        }
    }
}
