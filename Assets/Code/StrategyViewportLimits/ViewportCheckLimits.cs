using UnityEngine;

public class ViewportCheckLimits : ICheckLimits
{
    private readonly Camera _camera;
    private readonly Transform _transform;

    public ViewportCheckLimits(Camera camera , Transform transform)
    {
        _camera = camera;
        _transform = transform;
    }

    public void ClampFinalPosition()
    {
        var viewportPoint = _camera.WorldToViewportPoint(_transform.position);
        viewportPoint.x = Mathf.Clamp(viewportPoint.x, 0.03f, 0.97f);
        viewportPoint.y = Mathf.Clamp(viewportPoint.y, 0.03f, 0.97f);
        _transform.position = _camera.ViewportToWorldPoint(viewportPoint);
    }
}
