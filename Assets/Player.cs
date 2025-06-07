using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
    public void changeColorOfText(Color color)
    {
        string livesObjectName = playerName + "Lives";
        GameObject livesObj = GameObject.Find(livesObjectName);
        TextMeshProUGUI livesText = livesObj.GetComponent<TextMeshProUGUI>();
        livesText.color = color;
        string trainerObjectName = playerName;
        GameObject trainerObj = GameObject.Find(trainerObjectName);
        TextMeshProUGUI trainerText = trainerObj.GetComponent<TextMeshProUGUI>();
        trainerText.color = color;
    }
    public int getEnergyCount()
    {
        return energies.Count();
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
                        hpText.text = "";
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
            foreach (Pokemon pokemon in pokemonList)
            {
                if (pokemon.visible)
                {
                    activePokemon = pokemon;
                    Debug.Log(activePokemon.getName() + " is the active pokemon");

                }
            }
        }
        updatePokemonHealth();
    }
    public void win()
    {
        GameObject textObj = GameObject.Find("WinText");
        if (textObj != null)
        {
            TextMeshProUGUI label = textObj.GetComponent<TextMeshProUGUI>();
            label.text = playerName+ " won!";
        }
        updatePokemonHealth();
    }
    public void endTurn(Player otherPlayer)
    {
        if (energies.Any()) {
            Debug.Log("Check for energies");
            findActivePokemon();
            if (activePokemon != null)
            {
                otherPlayer.findActivePokemon();
                if (otherPlayer.activePokemon != null)
                {
                    activePokemon.attack(energies, otherPlayer.activePokemon);
                }
                energies.Clear();
                if (otherPlayer.deadPokemonCounter >= 3)
                {
                    win();
                }
            }
        }
        Debug.Log("Turn ended inside Player");
        updatePokemonHealth();
    }
    public void addEnergy(string energy)
    {
        if (!energies.Contains(energy))
        {
            GameObject.Find("GameLogic").transform.GetChild(0).GetComponent<AudioSource>().Play();
            if (energy == "fire")
            {
                GameObject.Find("FireEnergy").GetComponentInChildren<ParticleSystem>(true).Play();
            }
            else if (energy == "colorless")
            {
                GameObject.Find("ColorlessEnergy").GetComponentInChildren<ParticleSystem>(true).Play();
            }
            else if (energy == "double")
            {
                GameObject.Find("DoubleColorlessEnergy").GetComponentInChildren<ParticleSystem>(true).Play();
            }
            else if (energy == "water")
            {
                GameObject.Find("WaterEnergy").GetComponentInChildren<ParticleSystem>(true).Play();
            }
            else if (energy == "grass")
            {
                GameObject.Find("GrassEnergy").GetComponentInChildren<ParticleSystem>(true).Play();
            }
            energies.Add(energy);
            Debug.Log("Energy added inside Player");
        }
        updatePokemonHealth();
    }
    public void heal(string healCard)
    {
        findActivePokemon();
        if (activePokemon != null)
        {
            if (healCard == "Potion")
            {
                activePokemon.healPokemon(30);
            }
            else if (healCard == "SuperPotion")
            {
                activePokemon.healPokemon(60);
            }

            AudioSource source = GameObject.Find(healCard).GetComponent<AudioSource>();
            if (source != null)
            {
                source.Play();
            }
            ParticleSystem particle = GameObject.Find(healCard).GetComponentInChildren<ParticleSystem>();
            if (particle != null)
            {
                GameObject particleObj = GameObject.Find("HealEffect" + healCard);
                particleObj.transform.position = activePokemon.getModel().transform.position;
                particle.Play();
            }
            Debug.Log("Heal card inside Player");
        }
        updatePokemonHealth();
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
                hpText.text = "";
                hpText.enabled = false;
            }
        }
        pokemon.hidePokemon();
        pokemonList.Remove(pokemon);
        deadPokemonCounter++;
        GameObject.Find("Death").GetComponent<AudioSource>().Play();
        string livesObjectName = playerName + "Lives";
        GameObject livesObj = GameObject.Find(livesObjectName);
        TextMeshProUGUI livesText = livesObj.GetComponent<TextMeshProUGUI>();
        if (deadPokemonCounter == 0)
        {
            livesText.text = "OOO";
        }else if (deadPokemonCounter==1)
        {
            if (playerName == "Marnie")
            {
                livesText.text = "OOX";
            }
            else
            {
                livesText.text = "XOO";
            }
        }else if (deadPokemonCounter == 2)
        {
            if (playerName == "Marnie")
            {
                livesText.text = "OXX";
            }
            else
            {
                livesText.text = "XXO";
            }
        }
        else
        {
            livesText.text = "XXX";
        }

        if (activePokemon == pokemon)
        {
            activePokemon = null;
        }
        Debug.Log("Pokemon removed inside Player");
        updatePokemonHealth();

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
        updatePokemonHealth();
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
                case "Charmander":
                    pokemon = new Charmander(this, pokemonModel);
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
        updatePokemonHealth();
        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000);
            updatePokemonHealth();
        });
    }

}
