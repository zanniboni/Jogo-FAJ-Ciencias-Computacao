/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class Utility
{
    public static float AngleTowardsMouse(Vector3 pos){
        
        Vector3 mousePos = Input.MousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldScreenPoint(pos);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        
        return angle;
    }
}
*/