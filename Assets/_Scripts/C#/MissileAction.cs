using UnityEngine;

public class MissileAction : MonoBehaviour
{
    public GameObject explosion;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * 200.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        GameObject exp = Instantiate(explosion, contact.point + (contact.normal * 5.0f), Quaternion.identity);
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(exp, 2.0f);
        Destroy(gameObject);
    }
}
