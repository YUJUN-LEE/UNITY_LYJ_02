using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STUDY : MonoBehaviour
{
	// 각 축(x, y, z)의 이동 방향, 값은 3가지(-1, 0, 1)만 입력
	float fDirectionX = 0;
	float fDirectionY = 0;
	float fDirectionZ = 0;
	// 이동 속도
	float fMoveSpeed = 0.1f;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		// 함수 호출
		ProcessInput();
	}
	private void FixedUpdate()
	{
		transform.Translate(fDirectionX * fMoveSpeed, fDirectionY * fMoveSpeed, fDirectionZ * fMoveSpeed);
	}
	// 입력 처리 함수 정의
	void ProcessInput()
	{
		// 누르고 있는 동안 모든 프레임에서 true값 반환
		// Input.GetKey(KeyCode.UpArrow);
		// 키보드를 누른 프레임에 true값 반환
		// Input.GetKeyDown(KeyCode.DownArrow);
		// 키보드를 놓은 프레임에 true값 반환
		// Input.GetKeyUp(KeyCode.RightArrow);

		bool isUpKey = Input.GetKey(KeyCode.UpArrow);
		bool isDownKey = Input.GetKey(KeyCode.DownArrow);
		bool isRightKey = Input.GetKey(KeyCode.RightArrow);
		bool isLeftKey = Input.GetKey(KeyCode.LeftArrow);

		if (isUpKey) // 위에 키를 눌렀을(누르고 있을) 때
		{
			fDirectionY = 1; // Y 방향의 값을 1로 바꿈
		}
		else if (isDownKey)
		{
			fDirectionY = -1;
		}
		else
		{
			fDirectionY = 0;
		}
		if (isRightKey)
		{
			fDirectionX = 1;
		}
		else if (isLeftKey)
		{
			fDirectionX = -1;
		}
		else
		{
			fDirectionX = 0;
		}
		// 마우스를 누르는 동안
        // Input.GetMouseButton()
		// 마우스 버튼이 눌렸을 때
        // Input.GetMouseButtonDown()
		// 마우스 버튼을 놓았을 때
        // Input.GetMouseButtonUp()
		// () 안에 0(왼쪽), 1(오른쪽), 2(휠)
		// 주석 한번에 넣기 : ctrl + k(누르고 떼기) + c
		// 주석 한번에 풀기 : ctrl + k(누르고 떼기) + u
		// 줄 정렬 : ctrl + k + f
		// 전체 선택 : ctrl + a
		//bool isLeftMouseDown = Input.GetMouseButtonDown(0);
		//bool isLeftMouse = Input.GetMouseButton(0);

		//if (isLeftMouseDown)
		//{
		//	Vector3 vecMousePosition = Input.mousePosition;
		//	vecMousePosition.z += 10;
		//	vecMousePosition.y -= 1;
		//	Vector3 vecMouseWorldPosition = Camera.main.ScreenToWorldPoint(vecMousePosition);
		//	Debug.Log(vecMouseWorldPosition.ToString());

		//	transform.position = vecMouseWorldPosition;
		//}
		//else { }
		//if (isLeftMouse)
		//{
		//	// transform.Rotate(0.3f, 0.2f, 0.1f);
		//	Vector3 vecMousePosition = Input.mousePosition;
		//	vecMousePosition.z += 10;
		//	vecMousePosition.y -= 1;
		//	Vector3 vecMouseWorldPosition = Camera.main.ScreenToWorldPoint(vecMousePosition);
		//	Debug.Log(vecMouseWorldPosition.ToString());

		//	transform.position = vecMouseWorldPosition;
		//}
		//else { }
    }
}
