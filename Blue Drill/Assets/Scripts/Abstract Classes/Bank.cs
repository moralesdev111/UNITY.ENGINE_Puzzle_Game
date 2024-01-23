using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Bank : MonoBehaviour
{
    public int currentBalance;

    public abstract int AddToBank(int amout);
}
