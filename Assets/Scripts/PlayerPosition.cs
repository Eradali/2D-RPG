using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour , ISerializationCallbackReceiver 
{
    //Position for transition

    public Vector2 initialValue;

    public Vector2 defaultValue;

   public void OnAfterDeserialize()
    {
        initialValue = defaultValue;
    }
    public void OnBeforeSerialize() { 
    }
    
}
