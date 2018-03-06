using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Drain : MonoBehaviour {

    public Data_Manager data_manager_script;

    //Amount of time between resource collection
    float next_time = 30f;
    float add_time = 30f;

    void FixedUpdate()
    {
        //Checks if the time sice this scritpt stated is greater that current_time
        if (Time.time > next_time)
        {
            //Takes away resources from inventory
            data_manager_script.Change_Resources(3, - Mathf.Floor(data_manager_script.Check_Pop_Total()/1));

            //If the ammount of food goes below 0
            if(data_manager_script.Check_Resources(3) < 0)
            {
                //Remove population proptional to a quarter of the deficit of food
                data_manager_script.Change_Pop(Mathf.Floor(data_manager_script.Check_Resources(3)/4));
                //Change the amount of food back to zero
                data_manager_script.Change_Resources(3, -data_manager_script.Check_Resources(3));
            }
            //Add the current time to varible add_time
            next_time = Time.time + add_time;
        }
    }
}
