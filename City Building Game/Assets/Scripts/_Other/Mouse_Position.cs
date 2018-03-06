using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Position : MonoBehaviour {

    Vector3 mouse_pos;

    public Vector3 Get_Mouse_Pos(){
        //Creates a raycast called ray and sends it from the camera to the mouse
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //If the raycast hits an object
        //Make the hit point equal to mouse_pos
        //Round the x and z values and remove the y value
        if (Physics.Raycast(ray, out hit)){
            mouse_pos = hit.point;
            mouse_pos[0] = Mathf.Round(mouse_pos[0]);
            mouse_pos[1] = 0;
            mouse_pos[2] = Mathf.Round(mouse_pos[2]);
            return mouse_pos;}
        //If the raycast doesnt hit the return zero
        return Vector3.zero;
    }
}

