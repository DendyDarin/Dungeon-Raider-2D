using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public static class HelperUtilities
{
    // empty string debug check
    public static bool ValidateCheckEmptyString(Object thisObject, string fieldName, string stringToCheck)
    {
        if (stringToCheck == "")
        {
            Debug.Log(fieldName + " is empty and must contain a value in object " + thisObject.name.ToString());
            return true;
        }
        return false;
    }

    // list empty or contains null value check - returns true if there is an error
    public static bool ValidateCheckEnumerableValues(Object thisObject, string fieldName, IEnumerable enumerableObjeckToCheck)
    {
        bool error = false;
        int count = 0;

        if (enumerableObjeckToCheck == null)
        {
            Debug.Log(fieldName + " is null inn object " + thisObject.name.ToString());
            return true;
        }

        foreach (var item in enumerableObjeckToCheck)
        {
            if (item == null)
            {
                Debug.Log(fieldName + " has null value in object " + thisObject.name.ToString());
                error = true;
            }
            else
            {
                count++;
            }
        }

        if (count == 0)
        {
            Debug.Log(fieldName + " has no value in object " + thisObject.name.ToString());
            error = true;
        }

        return error;
    }
}
