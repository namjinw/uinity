using UnityEditor;
using UnityEngine;

public class dmotionmove : MonoBehaviour
{
    public float speed = 1.5f; // �̵� ũ��
    public float anglespeed = 12.5f; /// ȸ�� �ӵ�
    private Animator animator; // �ִϸ��̼� ���� ����

    private int combo = 0; // �޺� ���� ����
    private float index = 0; // �޺� ���� �ð�
    private float combotime = 1f; // �޺� ���ӽð�
    void Start()
    {
        animator = GetComponent<Animator>(); //Animator ������Ʈ ��������
    }

    void Update()
    {
        AnimatorStateInfo animationneme = animator.GetCurrentAnimatorStateInfo(0); // AnimatorStateInfo ���� ��� ���� �ִϸ��̼� ��������, GetCurrentAnimatorStateInfo ���̾� ����
        bool isAttacking = animationneme.IsName("Attack"); // IsName �ִϸ��̼� �±� �������� <= j, s, h ��� ���� "Attack"�±���

        if (!isAttacking) // �������� �ƴ϶�� �̵� ����
        {
            float moveX = 0f; // vector3dml X�� �������� ��� 0���� �ʱ�ȭ
            float moveZ = 0f; // vector3dml Z�� ��������

            if (Input.GetKey(KeyCode.W)) { moveZ -= 1f; }
            if (Input.GetKey(KeyCode.S)) { moveZ += 1f; }
            if (Input.GetKey(KeyCode.D)) { moveX -= 1f; }
            if (Input.GetKey(KeyCode.A)) { moveX += 1f; } // Ű���� Ű�� ��ǥ�̵�

            Vector3 MoveDirection = new Vector3(moveX, 0, moveZ).normalized; // �̵��ϴ� ���� => normalized �밢�� �ӵ� ���� ���� (����ȭ)
            Vector3 move = MoveDirection * speed * Time.deltaTime; // �� �̵��Ÿ� => �̵��ϴ� ���� * �̵� ũ�� * �� ������
            transform.position += move; // ���� ��ġ�� ���ϸ鼭 ��: �̵� (0, 0, 0) += (2.5f, 0, 0)

            if (move != Vector3.zero) // ���� �̵� ���̶�� move(���� �ӵ�) != Vector3 (0, 0, 0) <= �� ���� �ƴ϶��
            {
                Quaternion anlgemove = Quaternion.LookRotation(move); //Quaternion ȸ���� �ڷ��� LookRotation => Ư�� ������ �ٶ󺸰� �ϴ°�
                transform.rotation = Quaternion.Slerp(transform.rotation, anlgemove, anglespeed * Time.deltaTime); // ���� ȸ������ = Slerp(ȸ�� �ε巴��) (���� ��ġ, ���ϴ� ��, ���ϴ� ���� ũ��)
            }


            float aispeed = move.magnitude / Time.deltaTime; // ���� ���ǵ� ��� move.magnitude => �̵��Ÿ� ��� / �� ������
            animator.SetFloat("speed", aispeed); //speed�� aispeed�� ����
            animator.SetBool("keymove", aispeed > 0.1f); // ���� ũ�ٸ� ��
        }
        else // �������̶�� ����
        {
            animator.SetFloat("speed", 0f); // �����ϴ� ���� speed = 0
            animator.SetBool("keymove", false); // �����ϴµ��� �ٸ� �������� ��ȯ X
        }
        if (Input.GetKeyDown(KeyCode.J))
        {


            if (Time.time - index > combotime) { combo = 0; } // Time.time => ���� ������ �ð� ���� but input�� ��⿡ J�� ���� �� ���� ����
            combo++; // �׷��� Time.time(1.1���� ����) - index( time�� 1�� �ʰ��ϸ� Ŀ���� �ǹ� x) < 1�� <= 1�ʺ��� ũ��

            if (combo == 1) { animator.SetTrigger("J"); } // combo�����ؼ� 1�϶� ��
            else if (combo == 2) { animator.SetTrigger("S"); } // combo�����ؼ� 2�϶� ��Ʈ����Ʈ
            else if (combo == 3) { animator.SetTrigger("H"); combo = 0; } // combo�����ؼ� 3�϶�����Ʈ ��

            index = Time.time; // if���� �������� �� ������ �ϴ°Ŵ� if�������� "0f" ��. �Ѹ���� index �ڸ��� (�� 0.9) ���� �� Time.time�� �ʱ�ȭ
        }
    }
}
