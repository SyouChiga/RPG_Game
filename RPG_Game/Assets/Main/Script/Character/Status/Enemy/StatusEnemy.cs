using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
namespace Game
{
    namespace Character
    {
        public class StatusEnemy : BaseStatus
        {
            [SerializeField]
            private int enemyID_;

            protected override void SetID(int _ID)
            {
                enemyID_ = _ID;
            }
        }
    }
}
#endif
