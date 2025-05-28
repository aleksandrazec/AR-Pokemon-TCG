using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
            updateHP();
            Debug.Log("Player 1 turn");
            Player2.endTurn(Player1);
            gameObject.GetComponent<AudioSource>().Play();
            updateHP();
            currentPlayer = 1;
        }
    }
    public void player2Turn()
    {
        if (currentPlayer == 1)
        {
            updateHP();
            Debug.Log("Player 2 turn");
            Player1.endTurn(Player2);
            gameObject.GetComponent<AudioSource>().Play();
            updateHP();
            currentPlayer = 2;
        }
    }
    public void energyDetected(string energy)
    {
        gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
        Debug.Log("Energy detected");
        if (currentPlayer == 1)
        {
            Player1.addEnergy(energy);
            updateHP();
        }
        else
        {
            Player2.addEnergy(energy);
            updateHP();
        }
    }
    public void healDetected(string healCard)
    {
        Debug.Log("Heal detected");
        if (currentPlayer == 1)
        {
            Player1.heal(healCard);
            updateHP();
        }
        else
        {
            Player2.heal(healCard);
            updateHP();
        }
    }

    public void pokemonDetected(string pokemonName)
    {
        GameObject pokemonModel = GameObject.Find(pokemonName);
            Debug.Log(pokemonName + " detected");
            if (currentPlayer == 1)
            {
                Player1.addPokemon(pokemonName, pokemonModel);
                updateHP();
        }
        else
            {
                Player2.addPokemon(pokemonName, pokemonModel);
                updateHP();
        }
        updateHP();
        Debug.Log("finished pokemon detection");
    }

    public void pokemonDissapeared(string pokemonName)
    {
        GameObject pokemonModel = GameObject.Find(pokemonName);
            Debug.Log(pokemonName + " dissapeared");
            if (currentPlayer == 1)
            {
                Player1.hidePokemon(pokemonName, pokemonModel);
                updateHP();
            }
            else
                {
                Player2.hidePokemon(pokemonName, pokemonModel);
                updateHP();
    
            }
    }
}
