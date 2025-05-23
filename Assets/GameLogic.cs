using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.EventSystems.EventTrigger;

public class GameLogic : MonoBehaviour
{
    int currentPlayer = 1;
    Player Player1;
    Player Player2;

    // Start is called before the first frame update
    void Start()
    {
        Player1 = new Player("Marnie");
        Player2 = new Player("Bede");
        InvokeRepeating("updateHP", 2.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateHP()
    {
        Player1.updatePokemonHealth();
        Player2.updatePokemonHealth();
    }
    public void player1Turn()
    {
        Debug.Log("Player 1 turn");
        Player2.endTurn(Player1);
        currentPlayer = 1;
    }
    public void player2Turn()
    {
        Debug.Log("Player 2 turn");
        Player1.endTurn(Player2);
        currentPlayer = 2;
    }
    public void energyDetected(string energy)
    {
        Debug.Log("Energy detected");
        if (currentPlayer == 1)
        {
            Player1.addEnergy(energy);
        }
        else
        {
            Player2.addEnergy(energy);
        }
    }
    public void healDetected(string healCard)
    {
        Debug.Log("Heal detected");
        if (currentPlayer == 1)
        {
            Player1.heal(healCard);
        }
        else
        {
            Player2.heal(healCard);
        }
    }

    public void pokemonDetected(string pokemonName)
    {
        GameObject pokemonModel = GameObject.Find(pokemonName);
        if (pokemonModel != null)
        {
            Debug.Log(pokemonName + " detected");
            if (currentPlayer == 1)
            {
                Player1.addPokemon(pokemonName, pokemonModel);
            }
            else
            {
                Player2.addPokemon(pokemonName, pokemonModel);
            }
            Debug.Log("finished pokemon detection");
        }
    }

    public void pokemonDissapeared(string pokemonName)
    {
        GameObject pokemonModel = GameObject.Find(pokemonName);
        if (pokemonModel != null)
        {
            Debug.Log(pokemonName + " dissapeared");
            if (currentPlayer == 1)
            {
                Player1.hidePokemon(pokemonName, pokemonModel);
            }
            else
            {
                Player2.hidePokemon(pokemonName, pokemonModel);
            }
        }
    }
}
