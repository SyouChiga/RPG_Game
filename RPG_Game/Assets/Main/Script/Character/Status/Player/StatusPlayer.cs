using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
namespace Game
{
    namespace Character
    {
        public class StatusPlayer : BaseStatus
        {
            [SerializeField]
            private int playerID_;

            protected override void SetID(int _ID)
            {
                playerID_ = _ID;
            }
        }
    }
}
#endif