#region Header
/*	============================================
 *	Author 			    	: Strix
 *	Initial Creation Date 	: 2020-03-15
 *	Summary 		        : 
 *	�׽�Ʈ ��ħ ��ũ
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
        public void ��ť_Where����_Int()
        {
            // Arrange
            List<int> listInt = new List<int>();
            for (int i = 0; i < 10; i++)
                listInt.Add(i);



            // Action
            // Ȧ�� ���ϱ�
            var arrOddNumber = listInt.Where(p => p % 2 == 1);

            // ¦�� ���ϱ�
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
        public void ��ť_Where����_String()
        {
            // Arrange
            List<Human> listHuman = new List<Human>();
            listHuman.Add(new Human() { strName = "strix", iAge = 20 });
            listHuman.Add(new Human() { strName = "json", iAge = 5 });
            listHuman.Add(new Human() { strName = "hotbar", iAge = 30 });
            listHuman.Add(new Human() { strName = "jim", iAge = 38 });



            // Action
            // 30�� �̻�
            var arr_AgeOver_30 = listHuman.Where(p => p.iAge >= 30);

            // �̸��� 5���� �̻�
            var arr_NameLength_EqualOver_5 = listHuman.Where(p => p.strName.Length >= 5);



            // Assert
            Debug.Log("30�� ����Ʈ");
            foreach (var pHuman in arr_AgeOver_30)
                Debug.Log(pHuman.ToString());

            Debug.Log("�̸� �� �����");
            foreach (var pHuman in arr_NameLength_EqualOver_5)
                Debug.Log(pHuman.ToString());

        }

        [Test]
        public void ��ť_GroupBy_����()
        {
            // Arrange
            List<Human> listHuman = new List<Human>();
            listHuman.Add(new Human() { strName = "strix", iAge = 20 });
            listHuman.Add(new Human() { strName = "json", iAge = 5 });
            listHuman.Add(new Human() { strName = "hotbar", iAge = 30 });
            listHuman.Add(new Human() { strName = "jim", iAge = 38 });



            // Action
            // 30�� �̻��� ������� ���� ����Ʈ
            // Select = �Ŭ������ �÷����� �ִµ�,
            // �� �÷����� ������� �÷����� ���ö� ��
            var arr_AgeOver_30_Age = listHuman.Where(p => p.iAge >= 30).Select(p => p.iAge);
            var arr_AgeOver_30_Name = listHuman.Where(p => p.iAge >= 30).Select(p => p.strName);

            var arr_AgeOver_30equal_over_Group = listHuman.Where(p => p.iAge >= 30).GroupBy(p => "30");
            var arr_AgeOver_30under_Group = listHuman.Where(p => p.iAge < 30).GroupBy(p => "30under");



            // Assert
            Debug.Log("30�� ���ϴ�?");
            // IGroup<string(30 or 30under), IEnumerable<Human>>
            foreach (var pHumanGroup in arr_AgeOver_30under_Group)
            {
                Debug.Log("�׷�� : " + pHumanGroup.Key);
                foreach (var pHuman in pHumanGroup)
                    Debug.Log(pHuman.ToString());
            }
        }
    }
}