using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static bool hasFlag(this DoorPositions value, DoorPositions flag)
    {
        return (value & flag) != 0;
    }
}
