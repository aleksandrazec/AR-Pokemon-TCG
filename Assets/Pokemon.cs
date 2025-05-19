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
    }
    public void healPokemon(int healAmount)
    {
        pokemonHP = pokemonHP + healAmount;
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
        pokemon.damagePokemon(attackPower);
    }
}
