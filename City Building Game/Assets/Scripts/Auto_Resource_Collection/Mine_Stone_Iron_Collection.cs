using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Stone_Iron_Collection : MonoBehaviour {


    public Data_Manager data_manager_script;

    //Amount of time between resource collection
    float next_time = 3;
    float add_time = 3;

    float max_employed = 2;

    public float Get_Local_Max_Employed()
    {
        return max_employed;
    }

    int local_employed = 0;

    public int Get_Local_Employed()
    {
        return local_employed;
    }

    public void Change_Local_Employed(int amount_changed)
    {
        local_employed += amount_changed;
    }

    void FixedUpdate()
    {
        //Check if there is and local jobs available and if there is any workers available 
        if (local_employed < max_employed && data_manager_script.Check_Employer_Slots(1) > 0)
        {
            //Subtracts that worker from the employer slots
            data_manager_script.Change_Employer_Slots(1, -1);
            //Add a worker to the local_employed
            local_employed += 1;

        }

        //Checks if there is a local worker and that the employer slots are negative
        if (local_employed > 0 && data_manager_script.Check_Employer_Slots(1) < 0)
        {
            //Adds a worker to the employer slots
            data_manager_script.Change_Employer_Slots(1, 1);
            //Subtracts a worker to the local_employed
            local_employed -= 1;
        }

        //Checks if the time sice this scritpt stated is greater that current_time
        if (Time.time > next_time)
        {
            //Checks to see if it will go over the maximum storage.  
            if (data_manager_script.Check_Resources(2) + 6 * local_employed / max_employed <= data_manager_script.Get_Max_Storage()) 
            {
                //Add resources to inventory
                data_manager_script.Change_Resources(2, 6 * local_employed / max_employed);
            }

            //Checks to see if it will go over the maximum storage.  
            if (data_manager_script.Check_Resources(4) + 6 * local_employed / max_employed <= data_manager_script.Get_Max_Storage()) 
            {
                //Add resources to inventory
                data_manager_script.Change_Resources(4, 6 * local_employed / max_employed);
            }
            //Add the current time to varible add_time
            next_time = Time.time + add_time;
        }
    }

    public GameObject Center_Object;

    //Refferences the Center_Object and the Data_Manager on it
    void Start()
    {
        Center_Object = GameObject.FindGameObjectWithTag("Center_Object");
        data_manager_script = Center_Object.GetComponent<Data_Manager>();

        //Adds jobs to the jobs list
        data_manager_script.Change_Jobs(1, max_employed);
    }
}