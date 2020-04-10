using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Tuple_Example
    {
        /// <summary>
        /// 이것은 헬스 정보입니다
        /// </summary>
        public class HelathInfo
        {
            public string CharacterName = "귀찮은녀석";
            public int iHPCurrent = 666;

            public void DoAddHP(int iHP)
            {
                iHPCurrent += iHP;
            }
        }


        /// <summary>
        /// 웹언어에서 튜플은 내용물을 절대 변경할수없다.
        /// 
        /// 튜플은 객체가 아니라 데이터 그룹? (임시)
        /// </summary>
        [Test]
        public void 튜플의_사용예시()
        {
            // 원하는 값을 리턴 얻으려면?



            // 1. Class를 정의해서 Class에 담아 원하는 값 얻기
            HelathInfo pHealth = 체력을얻고파();



            // 2. Out을 이용해서 원하는 값 얻기
            int iHP;
            string strCharacterName;
            체력을얻고파_근데_클래스정의하기는_귀찮다(out strCharacterName, out iHP);

            Assert.AreEqual(pHealth.CharacterName, strCharacterName);
            Assert.AreEqual(pHealth.iHPCurrent, iHP);


            int iHP_Origin = iHP;
            체력을_변경해보자(ref iHP, 10);
            Assert.AreEqual(iHP, iHP_Origin + 10);



            // 암튼.. 잘안씀.. (유지보수 측면때문에)

            // 3-1. Tuple을 이용해서 원하는 값 얻기
            var pHealth_Tuple = 체력을얻고파_튜플버전();
            Assert.AreEqual(pHealth_Tuple.strCharacterName_Tuple, strCharacterName);
            Assert.AreEqual(pHealth_Tuple.iHPCurrent_Tuple, iHP);

            // 3-2. Tuple을 이용해서 원하는 값 얻기
            var pHealth_Tuple_UnFriendly = 체력을얻고파_튜플버전_불친절버전();
            Assert.AreEqual(pHealth_Tuple_UnFriendly.Item1, strCharacterName);
            Assert.AreEqual(pHealth_Tuple_UnFriendly.Item2, iHP);
        }


        HelathInfo 체력을얻고파()
        {
            return new HelathInfo();
        }


        /// <summary>
        /// 작성자 입장에서는 
        /// Out 키워드는 함수 내에서 반드시 할당을 해야 컴파일 에러가 안뜸
        /// 
        /// 사용자 입장에서는
        /// 이 함수를 호출하는 순간 무조건 할당이 보장되있음
        /// </summary>
        void 체력을얻고파_근데_클래스정의하기는_귀찮다(out string CharacterName, out int iHPCurrent)
        {
            HelathInfo pHP = 체력을얻고파();
            CharacterName = pHP.CharacterName;
            iHPCurrent = pHP.iHPCurrent;
        }

        /// <summary>
        /// ref를 쓰면 struct도 함수 바깥에 나와도 적용됨
        /// </summary>
        void 체력을_변경해보자(ref int iHPCurrent, int iAddHP)
        {
            iHPCurrent += iAddHP;
        }

        /// <summary>
        /// 튜플을 정의하는 법
        /// 리턴하는 곳에 () 하고 변수 타입 및 변수명을 적으면 됩니다.
        /// </summary>
        /// <returns></returns>
        (string strCharacterName_Tuple, int iHPCurrent_Tuple) 체력을얻고파_튜플버전()
        {
            HelathInfo pHP = 체력을얻고파();
            return (pHP.CharacterName, pHP.iHPCurrent);
        }

        /// <summary>
        /// 변수 타입만 적어도 동작은 함 (불친절 버전)
        /// 
        /// 이러면 자동으로 Item1, Item2 등으로 할당됩니다.
        /// </summary>
        /// <returns></returns>
        (string, int) 체력을얻고파_튜플버전_불친절버전()
        {
            HelathInfo pHP = 체력을얻고파();
            return (pHP.CharacterName, pHP.iHPCurrent);
        }
    }
}
