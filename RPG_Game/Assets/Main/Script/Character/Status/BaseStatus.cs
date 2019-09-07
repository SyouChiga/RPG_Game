using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
namespace Game
{
    namespace Character
    {
        
        public class BaseStatus : ScriptableObject
        {
            public enum Character
            {
                Player,Enemy
            };
            [SerializeField]
            protected Character character_;
            public Character GetCharacterType
            {
                get { return character_; }
            }
            [SerializeField]
            protected int hp_ = 0;
            public int GetHP
            {
                get { return hp_; }
            }
            [SerializeField]
            protected int attack_ = 0;
            public int GetAttack
            {
                get { return attack_; }
            }
            [SerializeField]
            protected int speed_ = 0;
            public int GetSpeed
            {
                get { return speed_; }
            }
            [SerializeField]
            protected int mp_ = 0;
            public int GetMP
            {
                get { return mp_; }
            }
            [SerializeField]
            protected int startLevel_;
            public int GetLevel
            {
                get { return startLevel_; }
            }
            [SerializeField]
            protected string name_ = "\n";
            public string GetName
            {
                get { return name_; }
            }


            public void SetStatus(int _hp, int _mp, int _attack, int _speed, string _name, int _startLevel, int _ID)
            {
                hp_         = _hp;
                mp_         = _mp;
                attack_     = _attack;
                speed_      = _speed;
                name_        = _name;
                startLevel_ = _startLevel;

                SetID(_ID);
            }
            virtual protected void SetID(int _ID) { }
            static public void  CreateStatusObject<T>(BaseStatus _status) where T : BaseStatus
            {
                BaseStatus baseStatus = CreateInstance<T>();

                baseStatus = _status;

                string debug = "Assets/Main/Data/" + baseStatus.GetCharacterType.ToString() + "/" + baseStatus.GetName + ".asset";

                AssetDatabase.CreateAsset(baseStatus, "Assets/Main/Data/" + baseStatus.GetCharacterType.ToString() + "/" + baseStatus.GetName + ".asset");
                AssetDatabase.Refresh();
            }
        }
    }
}
#endif
