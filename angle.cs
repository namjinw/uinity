using UnityEngine;

public class angle : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5f, -10f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = player.position + offset;
        transform.LookAt(player);
    }
}
