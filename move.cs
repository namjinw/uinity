using UnityEngine;
using UnityEngine.UIElements;

public class move : MonoBehaviour
{
    public float Logtimer = 0.5f;
    public float logtime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime;
        }

        if (Input.GetKey (KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -50 * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, 50 * Time.deltaTime);
        }
        Logtimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.O) && logtime <= 0f)
        {
            Debug.Log("¾È³ç À¯´ÏÆ¼!");
            logtime = Logtimer;
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.localScale -= Vector3.one * Time.deltaTime;

            if (transform.localScale.x <= 0.1f)
            {
                transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
    }
}
