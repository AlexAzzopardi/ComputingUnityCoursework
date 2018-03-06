using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm_Placer : MonoBehaviour {

    public Data_Manager data_manager_script;
    public Mouse_Position mouse_position_script;
    public UI_Manager ui_manager_script;

    Vector3 click_pos;
    Vector3 mouse_pos;

    Quaternion rot_zero = Quaternion.Euler(0, 0, 0);

    bool selecting_area = false;

    public GameObject perm_farm_object;
    public GameObject temp_farm_object;
    GameObject perm_farm_placer;
    GameObject temp_farm_placer;

    public bool is_colliding = false;

    public void Collided()
    {
        is_colliding = true;
    }

    public void Farm_Placer_Controller()
    {
        //Find the posision of the mouse
        mouse_pos = mouse_position_script.Get_Mouse_Pos();

        //If you click and you are not selecting an area
        //If you not clicking a button
        if (Input.GetMouseButtonUp(0) && selecting_area == false && ui_manager_script.Get_Button_Pressed() == false)
        {
            //Make the click position equal the mouse position
            //Change bool to say you are selecting an area
            click_pos = mouse_pos;
            selecting_area = true;
        }

        //If the farms area is smaller than 100 in area
        //If you click and you are not selecting an area
        //If you are not clicking a button
        //If it is not colliding with anything
        else if (Input.GetMouseButtonUp(0) && ui_manager_script.Get_Button_Pressed() == false && selecting_area == true && is_colliding == false && (Mathf.Abs(click_pos[0] - mouse_pos[0]) + 1) * (Mathf.Abs(click_pos[2] - mouse_pos[2]) + 1) <= 100 && (Mathf.Abs(click_pos[0] - mouse_pos[0]) + 1) * (Mathf.Abs(click_pos[2] - mouse_pos[2]) + 1) >= 10)
        {
            //Creates the farm object
            //Resizes it to the correct dimentions
            perm_farm_placer = Instantiate(perm_farm_object, new Vector3((click_pos[0] + mouse_pos[0]) / 2, 0, (click_pos[2] + mouse_pos[2]) / 2), rot_zero);
            perm_farm_placer.transform.localScale = new Vector3(Mathf.Abs(click_pos[0] - mouse_pos[0]) + 1, 0.1f, Mathf.Abs(click_pos[2] - mouse_pos[2]) + 1);

            //Change bool to say you are not selecting an area
            selecting_area = false;

            //Adds a building to the building amounts list
            data_manager_script.Change_Building(5, 1);
        }

        //If you right click and you are selecting an area
        //Change bool to say you are not selecting an area
        if (Input.GetMouseButtonUp(1) && selecting_area == true)
        {
            selecting_area = false;
        }

        //Destroy old selector and place down new on inbetween the two corner points
        //Change the scale so that the selector goes between both corners.
        if (selecting_area == true)
        {
            Destroy(temp_farm_placer);
            temp_farm_placer = Instantiate(temp_farm_object, new Vector3((click_pos[0] + mouse_pos[0]) / 2, 0, (click_pos[2] + mouse_pos[2]) / 2), rot_zero);
            temp_farm_placer.transform.localScale = new Vector3(Mathf.Abs(click_pos[0] - mouse_pos[0]) + 1, 0.1f, Mathf.Abs(click_pos[2] - mouse_pos[2]) + 1);
        }

        //If you are not selecting an area destory the previous selector and place down a new selector.
        else
        {
            Destroy(temp_farm_placer);
            temp_farm_placer = Instantiate(temp_farm_object, new Vector3(mouse_pos[0], 0, mouse_pos[2]), rot_zero);
        }

        //Resets variable every time the script is run
        is_colliding = false;
    }

    //Removes any left over objects
    public void End_Farm_Placing()
    {
        selecting_area = false;
        Destroy(temp_farm_placer);
    }
}
