using UnityEngine;

namespace Code.Viewport
{
    public interface ICheckLimits
    {
        Vector2 ClampFinalPosition(Vector2 currentPosition);
    }
}