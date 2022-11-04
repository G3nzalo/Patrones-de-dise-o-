using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Inputs
{
    public interface IInputAdapter
    {
        Vector2 GetDirection();
        bool IsFireActionPressed();
    }
}