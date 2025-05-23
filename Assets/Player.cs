using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Player
{
    protected List<string> energies= new List<string>();
    protected Pokemon activePokemon;
    protected List<Pokemon> pokemonList= new List<Pokemon>();
    protected int deadPokemonCounter=0;
    protected string playerName;
    public Player(string trainer)
    {
        playerName = trainer;
    }
    public void updatePokemonHealth()
    {
        foreach (Pokemon pokemon in pokemonList)
        {
            string textObjectName = pokemon.getName() + "Text";
            GameObject textObj = GameObject.Find(textObjectName);

            if (textObj != null)
            {
                TextMeshProUGUI hpText = textObj.GetComponent<TextMeshProUGUI>();

                if (hpText != null)
                {
                    if (pokemon.visible)
                    {
                        hpText.text = pokemon.getHP()+"/"+pokemon.getMaxHP();

                        Vector3 worldPos = pokemon.getModel().transform.position;
                        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos + new Vector3(0, 0, 0.5f)); 
                        RectTransform rectTransform = hpText.GetComponent<RectTransform>();
                        rectTransform.position = screenPos;

                        hpText.enabled = true;
                    }
                    else
                    {
                        hpText.enabled = false;
                    }
                }
            }
        }
    }
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
    public void win()
    {
        GameObject textObj = GameObject.Find("WinText");
        if (textObj != null)
        {
            TextMeshProUGUI label = textObj.GetComponent<TextMeshProUGUI>();
            label.text = playerName+ " won!";
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
            if (otherPlayer.deadPokemonCounter>=3){
                win();
            }
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
        string textObjectName = pokemon.getName() + "Text";
        GameObject textObj = GameObject.Find(textObjectName);
        if (textObj != null)
        {
            TextMeshProUGUI hpText = textObj.GetComponent<TextMeshProUGUI>();
            if (hpText != null)
            {
                hpText.enabled = false;
                hpText.text = "";
            }
        }
        pokemonList.Remove(pokemon);
        pokemon.hidePokemon();
        deadPokemonCounter++;
        if (activePokemon == pokemon)
        {
            activePokemon = null;
        }
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
