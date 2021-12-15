using System;
using System.Collections.Generic;
using UnityEngine;

public class WeapChoose : MonoBehaviour
{
    public int currWeapID;    //Currently equipped weapon's ID
    public int currWeap;    //Currently equipped weapon's slot number
    public int[] hotbar;    //Hotbar array. 0 is unequip
    //1-10 holds data of 0-9 of alphanum keys

    private List<int> availableWeap = new List<int>();   //IDs of weapons player has in inventory   
    private const int totalWeap = 10;

    void Start()
    {
        availableWeap.Add(1);
        availableWeap.Add(0);   //0 reserved for NULL item (None equipped)
        hotbar = new int[totalWeap+1];
        hotbar[0] = 0;   //0 is reserved for UNEQUIP
        InitHotbar();
    }

    //Initializes hotbar array with all elements 0
    void InitHotbar()       
    {
        foreach(int i in hotbar)
        {
            hotbar[i] = 0;
        }
    }

    public int SwitchWeap(int a)
    {
        int returnID;
        if(a == currWeap)
        {
            returnID = 0;
            currWeapID = 0;
            currWeap = 0;
            //Unequip
        }
        else
        {            
            currWeap = a;
            currWeapID = hotbar[a+1];
            returnID = currWeapID;
        }       
        return returnID;       
    }

    public void AddWeap(int a)
    {
        if(!availableWeap.Contains(a))
        {
            availableWeap.Add(a);
        }
    }

    public void RemoveWeap(int a)
    {
        if(availableWeap.Contains(a))
        {
            availableWeap.Remove(a);
        }
    }

    public void SetWeap(int weapSlot, int weapID)
    {
        if(weapSlot < totalWeap)
        {
            hotbar[weapSlot+1] = weapID;
        }       
    }

    public void RemoveWeapFromH(int weaponSlot)
    {
        if(weaponSlot < totalWeap)
        {
            hotbar[weaponSlot+1] = 0;
        }
    }


    void Update()
    {
        if (Input.inputString != "")
        {
            int number;
            bool is_a_number = Int32.TryParse(Input.inputString, out number);
            if (is_a_number && number > 0 && number < 10)
            {
                SwitchWeap(number);
            }
        }
    }
}
