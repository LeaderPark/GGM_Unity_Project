using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start() //여기다 쓰면 자동으로 실행된다 (1번만);
    {
        #region 1챕

        // int a = 10; //이건 float가 소수점을 표시할 수 있어서 3.333333...
        // float c = 3f;
        // Debug.Log(a/c);

        // int a = 10; //이건 int값이라 소수점 표시 못함 3
        // int c = 3;
        // Debug.Log(a/c);

        // int a = 10;
        // string strA = "안녕하세요";

        // try //try catch문은 try에서 시도하여 오류나면 catch로 넘겨서 예외처리를 해줌
        // {
        //     a = int.Parse(strA);
        // }
        // catch (System.Exception)
        // {
        //     a = 0;
        //     Debug.Log("변환중 오류 발생");
        // }
        // Debug.Log(a);
        #endregion
    
        #region 2챕

        // int a = 20;
        // int b = 30;

        // float date = b / a; //이거 계산하면 1임 왜냐 int끼리 나누닌깐 소수점이 안나옴
        // double sum = 23.44;
        // sum += (double)date; //24.44 = 23.44 + 1;

        // string answer = "정답 : "; 
        // answer += sum; //"정답 : " 문자열에 sum 24.44을 붙혀서 "정답 : 24.44" 이다.
        // Debug.Log(answer);
        // //"정답 : 24.44"
        #endregion
    
        #region 3챕
        // if(bool형으로 나올 수 있는 것 == 참, 거짓으로만 판명되면 됨)
        // ==같다 , <= 작거나 같다, >= 크거나 같다. , != 같지 않다. , ! Not
        
        // int a = 10;
        // int b = 10;

        // if(a == b) 
        // {
        //     string result = "같다";
  
        // }
        // else
        // {
        //     string result = "다르다";
        // }
        // Debug.Log(result); 
        //이렇게 하면 오류남 왜냐 일단 선언을 if문 안쪽이 아닌 밖에 선언을 해야됨 아니면 
        // if(a==b)
        // {
        //     string result = "같다";
        //     Debug.Log(result); 
        // } // 이렇게 해야됨

        // int a= 10;
        // int b= 10;
        // string result;
        // if(a == b){
        //     result = "같아요";
        // }
        // else{
        //     result = "달라요";
        // }
        // Debug.Log(result); 
        #endregion 
    
        #region 4챕
        // for( (안쪽에 선언해도 됨) 초기값; 조건; 증감값)

        // int sum = 0; //1부터 1000까지의 합을 출력하는 코드 작성
        // for(int i = 1; i < 1000; i++)
        // {   
        //     sum += i;
        // }
        // Debug.Log(sum);

        // int sum = 0; //1부터 100까지의 짝수만 출력 + 합 출력;
        // for(int i = 2; i < 100; i+=2) //1번 (2부터 시작해서 2씩 올리면 당연하게 짝수만나옴)
        // {
        //     Debug.Log(i);
        //     sum += i;
        // }
        // Debug.Log(sum);

        // for(int i = 1; i < 100; i++) //2번 (1부터 100까지 출력하는데 if문 사용해서 짝수일때 출력하고 더하게 함)
        // {
        //     if(i % 2 == 0)
        //     {
        //         Debug.Log(i);
        //         sum += i;
        //     }
        // }
        // Debug.Log(sum);
        #endregion
    
        #region 5챕

        //배열은 여러개의 같은 자료형의 데이터를 하나의 이름에 담는 것 
        int[] arr = new int[10]; // 4 ~ 8byte
        //10칸의 배열이 생겼는데 안에들어가는 칸을 인덱스라 한다. 
        //index는 찾아가기 쉽게 만든 챕터 같은 것
        //정수형, int형의 배열 arr을 선언한 것

        //1시간 50분 까지 함
        #endregion
    
    }
}
