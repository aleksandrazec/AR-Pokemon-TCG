using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pokemon
{
    protected string pokemonName;
    protected int maxPokemonHP;
    protected int pokemonHP;
    protected List<Attack> pokemonAttacks = new List<Attack>();
    protected Player player;
    GameObject pokemonModel;
    public bool visible=true;
    public Pokemon(Player myPlayer, GameObject myModel)
    {
        player = myPlayer;
        pokemonModel = myModel;
    }
    public string getName()
    {
        return pokemonName;
    }
    public GameObject getModel()
    {
        return pokemonModel;
    }
    public void damagePokemon(int damageAmount)
    {
        pokemonHP = pokemonHP - damageAmount;
        Debug.Log("Pokemon damaged");
        if (pokemonHP <= 0)
        {
            killPokemon();
        }
        Debug.Log(pokemonName + " damaged, now has "+pokemonHP+" hp");
    }
    public void hidePokemon()
    {
        pokemonModel.SetActive(false);
        visible = false;
        Debug.Log(pokemonName + " is hidden");
    }
    public void unhidePokemon()
    {
        pokemonModel.SetActive(true);
        visible = true;
        Debug.Log(pokemonName + " is visible");

    }
    public void killPokemon()
    {
        Debug.Log(pokemonName + " died");
        player.removePokemon(this);
    }
    public void healPokemon(int healAmount)
    {
        if (pokemonHP + healAmount >= maxPokemonHP)
        {
            pokemonHP = maxPokemonHP;
        }
        pokemonHP = pokemonHP + healAmount;
        Debug.Log("Pokemon healed "+pokemonHP+" hp");
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
