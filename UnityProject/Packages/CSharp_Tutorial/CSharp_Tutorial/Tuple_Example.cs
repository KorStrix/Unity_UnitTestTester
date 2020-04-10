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
        /// �̰��� �ｺ �����Դϴ�
        /// </summary>
        public class HelathInfo
        {
            public string CharacterName = "�������༮";
            public int iHPCurrent = 666;

            public void DoAddHP(int iHP)
            {
                iHPCurrent += iHP;
            }
        }


        /// <summary>
        /// ������ Ʃ���� ���빰�� ���� �����Ҽ�����.
        /// 
        /// Ʃ���� ��ü�� �ƴ϶� ������ �׷�? (�ӽ�)
        /// </summary>
        [Test]
        public void Ʃ����_��뿹��()
        {
            // ���ϴ� ���� ���� ��������?



            // 1. Class�� �����ؼ� Class�� ��� ���ϴ� �� ���
            HelathInfo pHealth = ü���������();



            // 2. Out�� �̿��ؼ� ���ϴ� �� ���
            int iHP;
            string strCharacterName;
            ü���������_�ٵ�_Ŭ���������ϱ��_������(out strCharacterName, out iHP);

            Assert.AreEqual(pHealth.CharacterName, strCharacterName);
            Assert.AreEqual(pHealth.iHPCurrent, iHP);


            int iHP_Origin = iHP;
            ü����_�����غ���(ref iHP, 10);
            Assert.AreEqual(iHP, iHP_Origin + 10);



            // ��ư.. �߾Ⱦ�.. (�������� ���鶧����)

            // 3-1. Tuple�� �̿��ؼ� ���ϴ� �� ���
            var pHealth_Tuple = ü���������_Ʃ�ù���();
            Assert.AreEqual(pHealth_Tuple.strCharacterName_Tuple, strCharacterName);
            Assert.AreEqual(pHealth_Tuple.iHPCurrent_Tuple, iHP);

            // 3-2. Tuple�� �̿��ؼ� ���ϴ� �� ���
            var pHealth_Tuple_UnFriendly = ü���������_Ʃ�ù���_��ģ������();
            Assert.AreEqual(pHealth_Tuple_UnFriendly.Item1, strCharacterName);
            Assert.AreEqual(pHealth_Tuple_UnFriendly.Item2, iHP);
        }


        HelathInfo ü���������()
        {
            return new HelathInfo();
        }


        /// <summary>
        /// �ۼ��� ���忡���� 
        /// Out Ű����� �Լ� ������ �ݵ�� �Ҵ��� �ؾ� ������ ������ �ȶ�
        /// 
        /// ����� ���忡����
        /// �� �Լ��� ȣ���ϴ� ���� ������ �Ҵ��� ���������
        /// </summary>
        void ü���������_�ٵ�_Ŭ���������ϱ��_������(out string CharacterName, out int iHPCurrent)
        {
            HelathInfo pHP = ü���������();
            CharacterName = pHP.CharacterName;
            iHPCurrent = pHP.iHPCurrent;
        }

        /// <summary>
        /// ref�� ���� struct�� �Լ� �ٱ��� ���͵� �����
        /// </summary>
        void ü����_�����غ���(ref int iHPCurrent, int iAddHP)
        {
            iHPCurrent += iAddHP;
        }

        /// <summary>
        /// Ʃ���� �����ϴ� ��
        /// �����ϴ� ���� () �ϰ� ���� Ÿ�� �� �������� ������ �˴ϴ�.
        /// </summary>
        /// <returns></returns>
        (string strCharacterName_Tuple, int iHPCurrent_Tuple) ü���������_Ʃ�ù���()
        {
            HelathInfo pHP = ü���������();
            return (pHP.CharacterName, pHP.iHPCurrent);
        }

        /// <summary>
        /// ���� Ÿ�Ը� ��� ������ �� (��ģ�� ����)
        /// 
        /// �̷��� �ڵ����� Item1, Item2 ������ �Ҵ�˴ϴ�.
        /// </summary>
        /// <returns></returns>
        (string, int) ü���������_Ʃ�ù���_��ģ������()
        {
            HelathInfo pHP = ü���������();
            return (pHP.CharacterName, pHP.iHPCurrent);
        }
    }
}
