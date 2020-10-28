using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 10.0f;     // 转弯速度
    public float sensitivity = 1.0f;    // 敏感度，定义旋转时Lerp插值时间
    public float forwardForce = 50.0f;  // 前向力大小
    private float maxTurnLean = 50.0f;
    private float maxTilt = 50.0f;
    private float normalizedSpeed = 0.2f;
    private Vector3 euler = Vector3.zero;
    public Transform guiSpeedElement;
    public GameObject missile;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        guiSpeedElement.position = new Vector3(30, normalizedSpeed * Screen.height, 0);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, normalizedSpeed*forwardForce);
        Vector3 acc = Input.acceleration;
        euler.y += acc.x * turnSpeed;
        euler.z = Mathf.Lerp(euler.z, -acc.x * maxTurnLean, 0.2f);
        euler.x = Mathf.Lerp(euler.x, (acc.y+0.5f) * maxTilt, 0.2f);
        Quaternion rot = Quaternion.Euler(euler);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, sensitivity);

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    normalizedSpeed = touch.position.y / Screen.height;
                    guiSpeedElement.position = new Vector3(30, touch.position.y, 0);
                }
            } else
            {
            }

        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = new Vector3(0, -0.2f, 1) * 10.0f;
            position = transform.TransformPoint(position);
            GameObject thisMissile = Instantiate(missile, position, transform.rotation);
            Physics.IgnoreCollision(thisMissile.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
