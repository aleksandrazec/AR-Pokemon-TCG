using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameLogic : MonoBehaviour
{
    int currentPlayer = 1;
    Player Player1;
    Player Player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void player1Turn()
    {
        Player player2script = Player2.GetComponent<Player>();
        player2script.endTurn(Player1);
        currentPlayer = 1;
    }
    public void player2Turn()
    {
        Player player1script = Player1.GetComponent<Player>();
        player1script.endTurn(Player2);
        currentPlayer = 2;
    }
    public void energyDetected(string energy)
    {
        if (currentPlayer == 1)
        {
            Player player1script = Player1.GetComponent<Player>();
            player1script.addEnergy(energy);
        }
        else
        {
            Player player2script = Player2.GetComponent<Player>();
            player2script.addEnergy(energy);
        }
    }
    public void healDetected(string healCard)
    {
        if (currentPlayer == 1)
        {
            Player player1script = Player1.GetComponent<Player>();
            player1script.heal(healCard);
        }
        else
        {
            Player player2script = Player2.GetComponent<Player>();
            player2script.heal(healCard);
        }
    }
}
