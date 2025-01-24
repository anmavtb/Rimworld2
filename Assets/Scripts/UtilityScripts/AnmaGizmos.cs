using System;
using UnityEngine;

public class AnmaGizmos
{
    public enum DrawMode { Full, Wire };

    /// <summary>
    /// Draw a custom debug sphere
    /// </summary>
    /// <param name="_center">[Vector3] Center of the debug sphere</param>
    /// <param name="_radius">[Vector3] Radius of the debug sphere</param>
    /// <param name="_color">[Vector3] Color of the debug sphere</param>
    /// <param name="_mode">[enum] Wire or full</param>
    /// <param name="_enable">[Vector3] If true : the debug sphere will appear</param>
    public static void DrawSphere(Vector3 _center, float _radius, Color _color, DrawMode _mode = DrawMode.Wire, bool _enable = true)
    {
        if (!_enable) return;
        Gizmos.color = _color;
        if (_mode == DrawMode.Wire) Gizmos.DrawWireSphere(_center, _radius);
        else Gizmos.DrawSphere(_center, _radius);
        Gizmos.color = Color.white;
    }

    /// <summary>
    /// Draw a custom debug cube
    /// </summary>
    /// <param name="_center">[Vector3] Center of the debug cube</param>
    /// <param name="_size">[Vector3] Size of the debug cube</param>
    /// <param name="_color">[Color] Color of the debug cube</param>
    /// <param name="_mode">[enum] Wire or Full</param>
    /// <param name="_enable">[bool] If true : the debug cube will appear</param>
    public static void DrawCube(Vector3 _center, Vector3 _size, Color _color, DrawMode _mode = DrawMode.Wire, bool _enable = true)
    {
        if (!_enable) return;
        Gizmos.color = _color;
        if (_mode == DrawMode.Wire) Gizmos.DrawWireCube(_center, _size);
        else Gizmos.DrawCube(_center, _size);
        Gizmos.color = Color.white;
    }

    /// <summary>
    /// Draw a custom debug cube
    /// </summary>
    /// <param name="_center">[Vector3] Center of the debug cube</param>
    /// <param name="_size">[float] Radius of the debug cube</param>
    /// <param name="_color">[Color] Color of the debug cube</param>
    /// <param name="_mode">[enum] Wire or Full</param>
    /// <param name="_enable">[bool] If true : the debug cube will appear</param>
    public static void DrawCube(Vector3 _center, float _size, Color _color, DrawMode _mode = DrawMode.Wire, bool _enable = true)
    {
        if (!_enable) return;
        Gizmos.color = _color;
        if (_mode == DrawMode.Wire) Gizmos.DrawWireCube(_center, Vector3.one * _size);
        else Gizmos.DrawCube(_center, Vector3.one * _size);
        Gizmos.color = Color.white;
    }

    /// <summary>
    /// Draw a custom debug line
    /// </summary>
    /// <param name="_start">[Vector3] Starting position of the debug line</param>
    /// <param name="_end">[Vector3] Ending position of the debug line</param>
    /// <param name="_color">[Color] Color of the debug line</param>
    /// <param name="_enable">[bool] If true : the debug line will appear</param>
    public static void DrawLine(Vector3 _start, Vector3 _end, Color _color, bool _enable = true)
    {
        if (!_enable) return;
        Gizmos.color = _color;
        Gizmos.DrawLine(_start, _end);
        Gizmos.color = Color.white;
    }

    /// <summary>
    /// Draw a custom debug ray
    /// </summary>
    /// <param name="_start">[Vector3] Starting position of the debug ray</param>
    /// <param name="_direction">[Vector3] Direction of the debug ray</param>
    /// <param name="_color">[Color] Color of the debug ray</param>
    /// <param name="_enable">[bool] If true : the debug ray will appear</param>
    public static void DrawRay(Vector3 _start, Vector3 _direction, Color _color, bool _enable = true)
    {
        if (!_enable) return;
        Gizmos.color = _color;
        Gizmos.DrawRay(_start, _direction);
        Gizmos.color = Color.white;
    }
}
