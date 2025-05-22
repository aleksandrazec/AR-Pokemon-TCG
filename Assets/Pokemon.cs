using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public abstract class Pokemon
{
    //protected ParticleCall particleEffect=new ParticleCall();
    protected string pokemonName;
    protected int pokemonHP;
    protected List<Attack> pokemonAttacks;
    protected Player player;
    GameObject pokemonModel;
    public bool visible=true;
    public Pokemon(Player myPlayer, GameObject myModel)
    {
        player = myPlayer;
        pokemonModel = myModel;
        pokemonAttacks = new List<Attack>();
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
        pokemonHP = pokemonHP + healAmount;
        Debug.Log("Pokemon healed "+pokemonHP+" hp");
    }
    public void attack(List<string> energies, Pokemon otherPokemon)
    {
        Debug.Log("inside attack function");
        Attack currentAttack=null;
        foreach(Attack attack in pokemonAttacks)
        {
            var firstNotSecond = energies.Except(attack.energiesNeeded).ToList();
            var secondNotFirst = attack.energiesNeeded.Except(energies).ToList();

            if (!firstNotSecond.Any()&& !secondNotFirst.Any())
            {
                currentAttack = attack;
            }
        }
        if (currentAttack != null)
        {
            int attackPower = currentAttack.attackPower;
            Debug.Log("Pokemon attacked");
            otherPokemon.damagePokemon(attackPower);
            ParticleSystem[] particle = pokemonModel.GetComponentsInChildren<ParticleSystem>(true);
            particle[0].Play();
            if (particle.Length == 2)
            {
                particle[1].Play();
            }
        }

    }
}
