#region Header
/*	============================================
 *	Author 			    	: Strix
 *	Initial Creation Date 	: 2020-03-15
 *	Summary 		        : 
 *	테스트 지침 링크
 *	https://github.com/KorStrix/Unity_DevelopmentDocs/Test
 *
 *  Template 		        : Test For Unity Editor V1
   ============================================ */
#endregion Header

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace Tutorial
{

    /// <summary>
    /// 
    /// </summary>
    public class Linq_Example
    {
        [Test]
        public void 링큐_Where예시_Int()
        {
            // Arrange
            List<int> listInt = new List<int>();
            for (int i = 0; i < 10; i++)
                listInt.Add(i);



            // Action
            // 홀수 구하기
            var arrOddNumber = listInt.Where(p => p % 2 == 1);

            // 짝수 구하기
            var arrPairNumber = listInt.Where(p => p % 2 == 0);



            // Assert
            foreach (var pNumber in arrOddNumber)
                Assert.IsTrue(pNumber % 2 == 1);

            foreach (var pNumber in arrPairNumber)
                Assert.IsTrue(pNumber % 2 == 0);
        }


        public class Human
        {
            public string strName;
            public int iAge;

            public override string ToString()
            {
                return $"Name : {strName} // Age : {iAge}";
            }
        }

        [Test]
        public void 링큐_Where예시_String()
        {
            // Arrange
            List<Human> listHuman = new List<Human>();
            listHuman.Add(new Human() { strName = "strix", iAge = 20 });
            listHuman.Add(new Human() { strName = "json", iAge = 5 });
            listHuman.Add(new Human() { strName = "hotbar", iAge = 30 });
            listHuman.Add(new Human() { strName = "jim", iAge = 38 });



            // Action
            // 30대 이상
            var arr_AgeOver_30 = listHuman.Where(p => p.iAge >= 30);

            // 이름이 5글자 이상
            var arr_NameLength_EqualOver_5 = listHuman.Where(p => p.strName.Length >= 5);



            // Assert
            Debug.Log("30대 리스트");
            foreach (var pHuman in arr_AgeOver_30)
                Debug.Log(pHuman.ToString());

            Debug.Log("이름 긴 사람들");
            foreach (var pHuman in arr_NameLength_EqualOver_5)
                Debug.Log(pHuman.ToString());

        }

        [Test]
        public void 링큐_GroupBy_예시()
        {
            // Arrange
            List<Human> listHuman = new List<Human>();
            listHuman.Add(new Human() { strName = "strix", iAge = 20 });
            listHuman.Add(new Human() { strName = "json", iAge = 5 });
            listHuman.Add(new Human() { strName = "hotbar", iAge = 30 });
            listHuman.Add(new Human() { strName = "jim", iAge = 38 });



            // Action
            // 30대 이상의 사람들의 나이 리스트
            // Select = 어떤클래스의 컬렉션이 있는데,
            // 이 컬렉션의 멤버변수 컬렉션을 얻어올때 씀
            var arr_AgeOver_30_Age = listHuman.Where(p => p.iAge >= 30).Select(p => p.iAge);
            var arr_AgeOver_30_Name = listHuman.Where(p => p.iAge >= 30).Select(p => p.strName);

            var arr_AgeOver_30equal_over_Group = listHuman.Where(p => p.iAge >= 30).GroupBy(p => "30");
            var arr_AgeOver_30under_Group = listHuman.Where(p => p.iAge < 30).GroupBy(p => "30under");



            // Assert
            Debug.Log("30대 이하는?");
            // IGroup<string(30 or 30under), IEnumerable<Human>>
            foreach (var pHumanGroup in arr_AgeOver_30under_Group)
            {
                Debug.Log("그룹명 : " + pHumanGroup.Key);
                foreach (var pHuman in pHumanGroup)
                    Debug.Log(pHuman.ToString());
            }
        }
    }
}