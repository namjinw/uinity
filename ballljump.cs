using UnityEngine;

public class ballljump : MonoBehaviour
{
    private Rigidbody rb; // 물리 충돌 컴포넌트
    private Vector3 move; // 이동거리 변수
    public float speed = 5f; // 이동 거리
    public float jump_height = 7.5f; // 점프 높이
    private bool isGround = true; // 땅에 닿아있는지 가리는 변수
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 리지드바디 가져오기
    }

    void Update() // 매 프레임갱신 함수
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) { moveZ += 1f; }
        if (Input.GetKey(KeyCode.S)) { moveZ -= 1f; }
        if (Input.GetKey(KeyCode.D)) { moveX += 1f; }
        if (Input.GetKey(KeyCode.A)) { moveX -= 1f; }

        Vector3 moveDirection = new Vector3 (moveX, 0, moveZ).normalized;
        move = moveDirection * speed;

        if (Input.GetKey(KeyCode.Space) && isGround) // 스페이스, 땅에 닿아있을 때
        {
            rb.AddForce(Vector3.up * jump_height, ForceMode.Impulse); // AddForce => 힘 가하는 함수, Vector3.up => Y좌표, ForceMode => 힘이 적용되는 방식, Impulse(순간적인)
            isGround = false; // 점프키 누르먼 초기화 시키기 무조건
        }
    }

    private void FixedUpdate() // 물리 연산 처리 함수
    {
        rb.AddForce(move);
    }

    private void OnCollisionEnter(Collision collision) // 믈리충돌 감지 함수
    {
        if (collision.gameObject.CompareTag("Ground"))
        { // collision => 물리충돌 감지 코드, gameObject => 충돌한 오브젝트의 정보, CompareTag => 오브젝트의 태그 가져오기
            isGround = true;
        }
    }
}
