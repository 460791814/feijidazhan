using UnityEngine;
using System.Collections;

public static class RendererExtensions 
{
    public static bool IsVisibleFrom(this Renderer render, Camera camera)
    {
        ///判断物体是否在相机里面渲染
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, render.bounds);
    }
}
