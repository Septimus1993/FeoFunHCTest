using UnityEngine;

namespace HCTest.CameraScripts
{
    public interface ICameraSettings
    {
        float Speed { get; }
        float AngleX { get; }
        float AngleStep { get; }
        float Distance { get; }
        float DistanceStep { get; }
        Vector3 Offset { get; }
    }
}