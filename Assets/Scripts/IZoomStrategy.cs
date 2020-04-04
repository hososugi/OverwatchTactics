using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZoomStrategy
{
    void zoomIn(Camera camera, float delta, float nearZoomLimit);
    void zoomOut(Camera camera, float delta, float farZoomLimit);
}
