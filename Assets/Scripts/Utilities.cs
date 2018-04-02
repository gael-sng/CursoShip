using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour {

    public static float GetMinHorizontalPosition()
    {
        return -Camera.main.orthographicSize * Screen.width / Screen.height;
    }
	public static float GetMaxHorizontalPosition()
    {
        return Camera.main.orthographicSize * Screen.width / Screen.height;
    }
	public static float GetMinVerticalPosition()
    {
        return -Camera.main.orthographicSize;
    }
	public static float GetMaxVerticalPosition()
    {
        return Camera.main.orthographicSize;
    }
}
