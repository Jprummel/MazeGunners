using UnityEngine;
using System.Collections;

public class BoostPad : MonoBehaviour
{
    public delegate void SpeedUpAction();
    public static event SpeedUpAction OnSpeedUp;

    void SpeedUp()
    {
        if(OnSpeedUp != null)
        {
            OnSpeedUp();
        }
    }
}
