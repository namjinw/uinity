using UnityEditor;
using UnityEngine;

public class dmotionmove : MonoBehaviour
{
    public float speed = 1.5f; // 이동 크기
    public float anglespeed = 12.5f; /// 회전 속도
    private Animator animator; // 애니메이션 변수 선언

    private int combo = 0; // 콤보 동작 변수
    private float index = 0; // 콤보 감속 시간
    private float combotime = 1f; // 콤보 지속시간
    void Start()
    {
        animator = GetComponent<Animator>(); //Animator 컴포넌트 가져오기
    }

    void Update()
    {
        AnimatorStateInfo animationneme = animator.GetCurrentAnimatorStateInfo(0); // AnimatorStateInfo 현재 재생 중인 애니메이션 가져오기, GetCurrentAnimatorStateInfo 레이어 상태
        bool isAttacking = animationneme.IsName("Attack"); // IsName 애니메이션 태그 가져오기 <= j, s, h 모두 같은 "Attack"태그임

        if (!isAttacking) // 공격중이 아니라면 이동 가능
        {
            float moveX = 0f; // vector3dml X값 변수선언 계속 0으로 초기화
            float moveZ = 0f; // vector3dml Z값 변수선언

            if (Input.GetKey(KeyCode.W)) { moveZ -= 1f; }
            if (Input.GetKey(KeyCode.S)) { moveZ += 1f; }
            if (Input.GetKey(KeyCode.D)) { moveX -= 1f; }
            if (Input.GetKey(KeyCode.A)) { moveX += 1f; } // 키보드 키로 좌표이동

            Vector3 MoveDirection = new Vector3(moveX, 0, moveZ).normalized; // 이동하는 변수 => normalized 대각선 속도 증가 방지 (정규화)
            Vector3 move = MoveDirection * speed * Time.deltaTime; // 총 이동거리 => 이동하는 변수 * 이동 크기 * 매 프레임
            transform.position += move; // 현재 위치에 더하면서 예: 이동 (0, 0, 0) += (2.5f, 0, 0)

            if (move != Vector3.zero) // 만약 이동 중이라면 move(현재 속도) != Vector3 (0, 0, 0) <= 이 값이 아니라면
            {
                Quaternion anlgemove = Quaternion.LookRotation(move); //Quaternion 회전의 자료형 LookRotation => 특정 방향을 바라보게 하는거
                transform.rotation = Quaternion.Slerp(transform.rotation, anlgemove, anglespeed * Time.deltaTime); // 현재 회전각도 = Slerp(회전 부드럽게) (현재 위치, 변하는 값, 변하는 값의 크기)
            }


            float aispeed = move.magnitude / Time.deltaTime; // 현재 스피드 출력 move.magnitude => 이동거리 출력 / 매 프레임
            animator.SetFloat("speed", aispeed); //speed에 aispeed값 대입
            animator.SetBool("keymove", aispeed > 0.1f); // 만약 크다면 참
        }
        else // 공격중이라면 실행
        {
            animator.SetFloat("speed", 0f); // 동작하는 동안 speed = 0
            animator.SetBool("keymove", false); // 동작하는동안 다른 동작으로 전환 X
        }
        if (Input.GetKeyDown(KeyCode.J))
        {


            if (Time.time - index > combotime) { combo = 0; } // Time.time => 게임 시작후 시간 측정 but input을 썼기에 J를 누른 후 부터 측정
            combo++; // 그래서 Time.time(1.1초후 누름) - index( time이 1초 초과하면 커져도 의미 x) < 1초 <= 1초보다 크냐

            if (combo == 1) { animator.SetTrigger("J"); } // combo증감해서 1일때 잽
            else if (combo == 2) { animator.SetTrigger("S"); } // combo증감해서 2일때 스트레이트
            else if (combo == 3) { animator.SetTrigger("H"); combo = 0; } // combo증감해서 3일때레프트 훅

            index = Time.time; // if문을 빠져나온 후 대입을 하는거다 if문에서는 "0f" 다. 한마디로 index 자리에 (예 0.9) 대입 후 Time.time은 초기화
        }
    }
}
