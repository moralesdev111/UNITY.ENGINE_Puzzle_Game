using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable 
{
    void Move();
}

public interface IRemoveButtonFunctionable
{
    void RemoveButtonFunctionality();
}

public interface IRandomNumberGenerateable
{
    int GenerateRandomNumber();
}