#region Header
/*	============================================
 *	Author 			        : Strix
 *	Initial Creation Date 	: 2020-01-31
 *	Summary 		        : 
 *  Template 		        : For Unity Editor V1
   ============================================ */
#endregion Header

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity_Pattern
{
    /// <summary>
    /// 트렌스폼의 값을 동기화 시켜주는 객체
    /// </summary>
    public class TransformFollower : CObjectBase
    {
        /* const & readonly declaration             */

        /* enum & struct declaration                */

        /* public - Field declaration               */


        /// <summary>
        /// 내 트렌스폼
        /// </summary>
        public Transform pTransform { get; private set; }

        /// <summary>
        /// 따라갈 대상 트렌스폼
        /// </summary>

        [Header("따라갈 대상 트렌스폼")]
        public Transform pTransformTarget;

        [Header("포지션 동기화 유무")]
        public bool bIsFollow_PosX = true;
        public bool bIsFollow_PosY = true;
        public bool bIsFollow_PosZ = true;

        /// <summary>
        /// 따라가지만 얼마나 간격을 두고 따라갈지
        /// 예를들어 1, 0, 0으로 하면 항상 1, 0, 0 만큼 간격을 벌리고 따라갑니다.
        /// </summary>
        public Vector3 vecPosOffset;

        [Header("회전값 동기화 유무")]
        public bool bIsFollow_RotX = true;
        public bool bIsFollow_RotY = true;
        public bool bIsFollow_RotZ = true;

        public Vector3 vecRotOffset;

        /* protected & private - Field declaration  */


        // ========================================================================== //

        /* public - [Do~Something] Function 	        */

        // ========================================================================== //

        /* protected - [Override & Unity API]       */

        protected override void OnAwake()
        {
            base.OnAwake();

            pTransform = transform;
        }

        private void Update()
        {
            if (pTransformTarget == null)
                return;

            Sync_Position();
            Sync_Rotation();
        }

        /// <summary>
        /// 위치를 동기화합니다.
        /// </summary>
        private void Sync_Position()
        {
            Vector3 vecCurrentPos = transform.position;
            Vector3 vecTargetPos = pTransformTarget.position + vecPosOffset;
            if (bIsFollow_PosX)
                vecCurrentPos.x = vecTargetPos.x;

            if (bIsFollow_PosY)
                vecCurrentPos.y = vecTargetPos.y;

            if (bIsFollow_PosZ)
                vecCurrentPos.z = vecTargetPos.z;

            transform.position = vecCurrentPos;
        }

        /// <summary>
        /// 회전값을 동기화합니다.
        /// </summary>
        private void Sync_Rotation()
        {
            Vector3 vecCurrentRot = transform.rotation.eulerAngles;
            Vector3 vecTargetRot = pTransformTarget.rotation.eulerAngles + vecRotOffset;
            if (bIsFollow_RotX)
                vecCurrentRot.x = vecTargetRot.x;

            if (bIsFollow_RotY)
                vecCurrentRot.y = vecTargetRot.y;

            if (bIsFollow_RotZ)
                vecCurrentRot.z = vecTargetRot.z;

            transform.rotation = Quaternion.Euler(vecCurrentRot);
        }
        /* protected - [abstract & virtual]         */


        // ========================================================================== //

        #region Private

        #endregion Private
    }

#if UNITY_EDITOR
    public class TransformFollower_Inspector : Editor
    {

    }
#endif
}