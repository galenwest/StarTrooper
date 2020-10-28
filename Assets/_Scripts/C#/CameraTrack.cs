using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    private float heightDamping = 2.0f;
    private float rotationDamping = 180.0f;

    private void LateUpdate()
    {
        if (target == null) return;

		// Calculate the current rotation angles
		float targetdRotationAngle = target.eulerAngles.y;
		float targetHeight = target.position.y + height;

		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;

		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, targetdRotationAngle, rotationDamping * Time.deltaTime);
		//Time.GetMyDeltaTime());

		// Damp the height
		currentHeight = Mathf.Lerp(currentHeight, targetHeight, heightDamping * Time.deltaTime);
		//Time.GetMyDeltaTime());
		//System.Console.WriteLine("dt: {0}", dt);//Time.GetMyDeltaTime());
		//Debug.Log("dt: " + Time.deltaTime);

		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		//transform.position = target.position;
		Vector3 pos = target.position - currentRotation * Vector3.forward * distance;
		pos.y = currentHeight;

		// Set the height of the camera
		transform.position = pos;

        // Always look at the target
        transform.LookAt(target);
    }
}
