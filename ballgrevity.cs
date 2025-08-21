using UnityEngine;

public class ballgrevity : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { rb.AddForce(Vector3.up * 10f, ForceMode.Impulse); }
    }
}
