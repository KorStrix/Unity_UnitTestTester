#region Header
/*	============================================
 *	Author 			    	: Strix
 *	Initial Creation Date 	: 2020-03-23
 *	Summary 		        : 
 *	테스트 지침 링크
 *	https://github.com/KorStrix/Unity_DevelopmentDocs/Test
 *
 *  Template 		        : Test For Unity Editor V1
   ============================================ */
#endregion Header

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tutorial
{

    public class 델리게이트와_이벤트
    {
        #region 델리게이트

        // Void형 함수 델리게이트 선언
        delegate void DelegateTestName();
        int _iTestNumber;

        [Test]
        public void 델리게이트는_어떻게쓰는지()
        {
            // Arrange (데이터 정렬)
            DelegateTestName delegateExample = 멤버변수를_플러스1합니다;
            _iTestNumber = 0;

            // Action (기능 실행) &&  Assert (맞는지 체크)
            delegateExample();
            Assert.AreEqual(_iTestNumber, 1);

            delegateExample();
            Assert.AreEqual(_iTestNumber, 2);



            // 마이너스 익명 메소드를 델리게이트 변수에 대입
            // Arrange (데이터 정렬)
            delegateExample = () => --_iTestNumber;

            // Action (기능 실행) &&  Assert (맞는지 체크)
            delegateExample();
            Assert.AreEqual(_iTestNumber, 1);

            delegateExample();
            Assert.AreEqual(_iTestNumber, 0);


            // 델리게이트 체인 문법
            // 델리게이트 변수에 + 혹은 -를 하면 여러개의 함수를 대입할 수 있습니다
            // 이 경우는 마이너스 익명메소드와 플러스 멤버메소드를 연달아 대입했으므로, TestNumber는 변하지 않습니다
            // Arrange (데이터 정렬)
            delegateExample += 멤버변수를_플러스1합니다;

            // Action (기능 실행) &&  Assert (맞는지 체크)
            delegateExample();
            Assert.AreEqual(_iTestNumber, 0);

            delegateExample();
            Assert.AreEqual(_iTestNumber, 0);
        }


        [Test]
        public void 델리게이트가_Null일때_사용하면_Exception을뱉습니다()
        {
            // Arrange (데이터 정렬)
            DelegateTestName delegateExample = null;
            bool bIsException = false;


            // Action (기능 실행)
            try
            {
                // Null이 담긴 Delegate를 사용하면 NullException Throw
                delegateExample();
            }
            catch
            {
                bIsException = true;
            }


            // Assert (맞는지 체크)
            Assert.IsTrue(bIsException);
        }

        #endregion

        #region 이벤트


        // 이벤트는 이미 정의된 델리게이트로 선언할 수 있으며,
        // 클래스 멤버로만 사용 가능합니다.

        // 외부 클래스에서 Event는 +=(Add), -=(Remove)밖에 하지 못하며,
        // Event를 소유한 클래스는 +=, -=를 포함하여 =null (이벤트 초기화)과 Invoke(이벤트를 구독한 함수 호출)를 할 수 있습니다.
        event DelegateTestName OnVoidEvent;

        [Test]
        public void 이벤트는_어떻게쓰는지()
        {
            // Arrange (데이터 정렬)
            OnVoidEvent += 멤버변수를_플러스1합니다;
            OnVoidEvent += 멤버변수를_플러스1합니다;

            _iTestNumber = 0;

            // Action (기능 실행)
            // 이벤트는 아무도 +=를 안했을때 null이기 때문에, Exception이 납니다.
            // 따라서 Event를 사용할 때는 ? 연산자와 함께 사용합시다.
            OnVoidEvent?.Invoke();

            // Assert (맞는지 체크)
            Assert.AreEqual(_iTestNumber, 2);
        }

        #endregion

        public void 멤버변수를_플러스1합니다()
        {
            _iTestNumber++;
        }
    }
}
