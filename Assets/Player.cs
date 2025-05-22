using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player
{
    protected List<string> energies= new List<string>();
    protected Pokemon activePokemon;
    protected List<Pokemon> pokemonList= new List<Pokemon>();
    public void findActivePokemon()
    {
        if (pokemonList.Any())
        {
            float bestPosition = -100000f;

            foreach (Pokemon pokemon in pokemonList)
            {
                if (pokemon.visible)
                {
                    float position = pokemon.getModel().transform.position.z;
                    if (position > bestPosition)
                    {
                        bestPosition = position;
                        activePokemon = pokemon;
                    }
                }
            }
            Debug.Log(activePokemon.getName() + " is the active pokemon");
        }
    }
    public void endTurn(Player otherPlayer)
    {
        if (energies.Any()) {
            Debug.Log("Check for energies");
            findActivePokemon();
            otherPlayer.findActivePokemon();
            if (otherPlayer.activePokemon != null)
            {
                activePokemon.attack(energies, otherPlayer.activePokemon);
            }
            energies.Clear();
        }
        Debug.Log("Turn ended inside Player");
    }
    public void addEnergy(string energy)
    {
        energies.Add(energy);
        Debug.Log("Energy added inside Player");
    }
    public void heal(string healCard)
    {
        findActivePokemon();
        if (healCard == "potion")
        {
            activePokemon.healPokemon(30);
        } else if (healCard == "superPotion")
        {
            activePokemon.healPokemon(60);
        }
        Debug.Log("Heal card inside Player");
    }
    public void removePokemon(Pokemon pokemon)
    {
        pokemonList.Remove(pokemon);
        Debug.Log("Pokemon removed inside Player");

    }
    public void hidePokemon(string pokemonName, GameObject pokemonModel)
    {
        foreach(Pokemon pokemon in pokemonList)
        {
            if (pokemon.getName() == pokemonName)
            {
                pokemon.hidePokemon();
            }
        }
        Debug.Log(pokemonName + " hidden inside Player");

    }

    public void addPokemon(string pokemonName, GameObject pokemonModel)
    {
        bool isInList = false;

        foreach (Pokemon pokemoni in pokemonList)
        {
            if (pokemoni.getName() == pokemonName)
            {
                isInList = true;
                pokemoni.unhidePokemon();
            }
        }
        if (!isInList)
        {
            Pokemon pokemon = null;
            switch (pokemonName)
            {
                case "Bulbasaur":
                    pokemon = new Bulbasaur(this, pokemonModel);
                    break;
                case "Wooloo":
                    pokemon = new Wooloo(this, pokemonModel);
                    break;
                case "Meowth":
                    pokemon = new Meowth(this, pokemonModel);
                    break;
                case "Squirtle":
                    pokemon = new Squirtle(this, pokemonModel);
                    break;
                case "Torchic":
                    pokemon = new Torchic(this, pokemonModel);
                    break;
                case "Vaporeon":
                    pokemon = new Vaporeon(this, pokemonModel);
                    break;
                case "Weedle":
                    pokemon = new Weedle(this, pokemonModel);
                    break;
                case "Charmender":
                    pokemon = new Charmender(this, pokemonModel);
                    break;
                case "Eevee":
                    pokemon = new Eevee(this, pokemonModel);
                    break;
                case "Flareon":
                    pokemon = new Flareon(this, pokemonModel);
                    break;
                case "Lapras":
                    pokemon = new Lapras(this, pokemonModel);
                    break;
                case "Leafeon":
                    pokemon = new Leafeon(this, pokemonModel);
                    break;
                default:
                    break;
            }
            pokemonList.Add(pokemon);
            Debug.Log(pokemonName + " added inside Player");
        }
    }
}
