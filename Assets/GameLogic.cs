using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
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
        if (currentPlayer == 2)
        {
            Debug.Log("Player 1 turn");
            Player2.endTurn(Player1);
            gameObject.GetComponent<AudioSource>().Play();
            currentPlayer = 1;
            Player1.changeColorOfText(Color.red);
            Player2.changeColorOfText(Color.white);
            updateHP();
        }
    }
    public void player2Turn()
    {
        if (currentPlayer == 1)
        {
            Debug.Log("Player 2 turn");
            Player1.endTurn(Player2);
            gameObject.GetComponent<AudioSource>().Play();
            currentPlayer = 2;
            Player2.changeColorOfText(Color.red);
            Player1.changeColorOfText(Color.white);
            updateHP();
        }
    }
    public void energyDetected(string energy)
    {
            Debug.Log("Energy detected");
        if (currentPlayer == 1)
        {
            if (Player1.getEnergyCount() < 2)
            {
                Player1.addEnergy(energy);
            }
        }
        else
        {
            if (Player2.getEnergyCount() < 2)
            {
                Player2.addEnergy(energy);
            }
        }
        updateHP();
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
        updateHP();
    }

    public void pokemonDissapeared(string pokemonName)
    {
        GameObject pokemonModel = GameObject.Find(pokemonName);
        Debug.Log(pokemonName + " dissapeared");
        if (currentPlayer == 1)
        {
            Player1.hidePokemon(pokemonName, pokemonModel);
        }
        else
        {
            Player2.hidePokemon(pokemonName, pokemonModel);
        }
        updateHP();
    }
}
