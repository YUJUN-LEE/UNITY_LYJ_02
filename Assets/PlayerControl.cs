using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
	Vector3 m_vecMoveDirection = Vector3.zero;
	float m_fMoveSpeed = 0.1f; // 움직이는 속도
	float m_fJumpForce = 5f; // 점프 하는 힘
    float TimeCount = 0f; // 시간 카운트
    int JumpCount = 0; // 점프 횟수 체크
    bool isGround = true; // 땅에 닿아있는지 확인
    // Start is called before the first frame update
    void Start()
	{
		
	}
	// Update is called once per frame
	void Update()
	{
		MoveComponent();
        Jump();
        TimeCount += Time.deltaTime;
        // Debug.Log(Time.deltaTime.ToString()); // Time.deltaTime = 1 프레임 당 처리 시간
        // transform.Translate(m_vecMoveDirection * Time.deltaTime * 3f); 추천하는 방법 X
        // Time.timeScale(값) : 재생속도, 기본 값 1
    }
	private void FixedUpdate()
	{
		transform.Translate(m_vecMoveDirection * m_fMoveSpeed);
        
    }
	void MoveComponent()
	{
		bool isUpKey = Input.GetKey(KeyCode.W);
		bool isDownKey = Input.GetKey(KeyCode.S);
		bool isRightKey = Input.GetKey(KeyCode.D);
		bool isLeftKey = Input.GetKey(KeyCode.A);

		if (isUpKey)
		{
			m_vecMoveDirection.z = 1f;
		}
		else if (isDownKey) 
		{
			m_vecMoveDirection.z = -1f;
		}
		else
		{
			m_vecMoveDirection.z = 0f;
		}
		if(isRightKey)
		{
			m_vecMoveDirection.x = 1f;
		}
		else if(isLeftKey)
		{
			m_vecMoveDirection.x = -1f;
		}
		else
		{
			m_vecMoveDirection.x = 0f;
		}
	}

	void Jump()
	{
        bool isjump = Input.GetKeyDown(KeyCode.Space);

        if (isjump && isGround) // isjump가 true이고 isGround가 true면 실행
		{
			m_vecMoveDirection.y = 1f; // y축 +1 방향 설정
			transform.Translate(m_vecMoveDirection * m_fJumpForce * Time.deltaTime); // 위치 변경(방향 * 점프하는 힘 * 시간(자연스럽게 올라가게 만드는 용도))
			TimeCount = 0;
			isGround = false; // 점프를 했으므로 땅에서 떨어짐
			JumpCount = JumpCount + 1; // 점프 횟수 증가
			Debug.Log("점프 입력");
            Debug.Log(JumpCount);
        }
        else if (!isGround && TimeCount <= 1 && isjump && JumpCount < 2) // isGround가 false고 TimeCount(체공 시간)가 1보다 작고 isjump가 true이며 JumpCount가 2보다 작을 때 실행
        {
            m_vecMoveDirection.y = 1f;
            transform.Translate(m_vecMoveDirection * m_fJumpForce * Time.deltaTime);
            TimeCount = 0; // 체공 시간 초기화
            JumpCount = JumpCount + 1; // 점프 횟수 증가
            Debug.Log("공중에서 점프");
            Debug.Log(JumpCount);
        }

        if (!isGround && TimeCount >= 1 && !isjump) // isGround가 false이고 체공 시간이 1초를 넘으며 isjump가 false일 때 실행
		{
			m_vecMoveDirection.y = -1f; // y축 -1 방향 설정
            transform.Translate(m_vecMoveDirection * m_fJumpForce * Time.deltaTime);
			TimeCount = 0; // 체공 시간 초기화
        }

        if (!isGround && transform.position.y <= 0 && !isjump) // isGround가 false이고 y의 위치가 0보다 작거나 같고 isjump가 false일 때 실행
        {
            m_vecMoveDirection.y = 0f; // y축 0 방향 설정
            transform.Translate(m_vecMoveDirection * m_fJumpForce * Time.deltaTime);
            isGround = true; // 땅에 닿았으니 true로 변경
            JumpCount = 0; // 점프 횟수 초기화
            Debug.Log("바닥에 닿음");
            Debug.Log(JumpCount);
        }
    }
}