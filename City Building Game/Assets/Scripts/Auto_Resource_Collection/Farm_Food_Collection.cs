using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm_Food_Collection : MonoBehaviour
{
    public Data_Manager data_manager_script;

    //Amount of time between resource collection
    float next_time = 3;
    float add_time = 3;

    int local_employed = 0;

    public int Get_Local_Employed()
    {
        return local_employed;
    }

    public void Change_Local_Employed(int amount_changed)
    {
        local_employed += amount_changed;
    }

    float max_employed;

    //Calls function which returns max_employed
    public float Get_Local_Max_Employed()
    {
        return max_employed;
    }

    void FixedUpdate()
    {
        //Check if there is and local jobs available and if there is any workers available 
        if (local_employed < max_employed && data_manager_script.Check_Employer_Slots(2) > 0)
        {
            //Subtracts that worker from the employer slots
            data_manager_script.Change_Employer_Slots(2, -1);
            //Add a worker to the local_employed
            local_employed += 1;

        }

        //Checks if there is a local worker and that the employer slots are negative
        if (local_employed > 0 && data_manager_script.Check_Employer_Slots(2) < 0)
        {
            //Adds a worker to the employer slots
            data_manager_script.Change_Employer_Slots(2, 1);
            //Subtracts a worker to the local_employed
            local_employed -= 1;
        }

        //Checks if the time sice this scritpt stated is greater that current_time
        if (Time.time > next_time)
        {
            //Checks to see it adding this resource will put it over the max_storage
            if (data_manager_script.Check_Resources(3) + Mathf.Ceil(area * local_employed / max_employed) * 1000 <= data_manager_script.Get_Max_Storage())
            { 
                //Add resources to inventory
                data_manager_script.Change_Resources(3, Mathf.Ceil(area * local_employed / max_employed) * 1000);
            }
            //Add the current time to varible add_time
            next_time = Time.time + add_time;
        }
    }

    public GameObject Center_Object;
    float area;

    void Start()
    {
        //References some objects in the game
        Center_Object = GameObject.FindGameObjectWithTag("Center_Object");
        data_manager_script = Center_Object.GetComponent<Data_Manager>();

        //Sets up the time delay
        next_time = Time.time + add_time;

        //Calculates the size of the farm
        area = (gameObject.transform.localScale.x) * (gameObject.transform.localScale.z);
        //Makes the max_employed propotrional to a 25th of the area
        max_employed = Mathf.Ceil(area/25);

        //Adds the jobs to the list
        data_manager_script.Change_Jobs(2, max_employed);
    }
}

