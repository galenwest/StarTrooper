using UnityEngine;

public class MobileAcc: MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Box(new Rect(50, 50, 100, 50), string.Format("{0:0.00}", Input.acceleration.x));
        GUI.Box(new Rect(50, 110, 100, 50), string.Format("{0:0.00}", Input.acceleration.y));
        GUI.Box(new Rect(50, 170, 100, 50), string.Format("{0:0.00}", Input.acceleration.z));
    }
}
