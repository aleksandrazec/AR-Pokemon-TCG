using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public string attackName;
    public List<string> energiesNeeded = new List<string>();
    public int attackPower;
    public string attackType;

    public Attack(string nameInput, List<string> energiesInput, int powerInput, string typeInput)
    {
        attackName = nameInput;
        energiesNeeded = energiesInput;
        attackPower = powerInput;
        attackType = typeInput;
    }
}
