using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pokemon : MonoBehaviour
{
    protected string pokemonName;
    protected int pokemonHP;
    protected List<Attack> pokemonAttacks = new List<Attack>();
    public void damagePokemon(int damageAmount)
    {
        pokemonHP = pokemonHP - damageAmount;
        Debug.Log("Pokemon damaged");
    }
    public void healPokemon(int healAmount)
    {
        pokemonHP = pokemonHP + healAmount;
        Debug.Log("Pokemon healed");
    }
    public void attack(List<string> energies, Pokemon pokemon)
    {
        Attack currentAttack=null;
        foreach(Attack attack in pokemonAttacks)
        {
            if (energies.Equals(attack.energiesNeeded))
            {
                currentAttack = attack;
            }
        }
        int attackPower = currentAttack.attackPower;
        Debug.Log("Pokemon attacked");
        pokemon.damagePokemon(attackPower);
    }
}
