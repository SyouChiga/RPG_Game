using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Game.Character;

#if UNITY_EDITOR
namespace Game
{
    namespace Editor
    {
        public class CreateStatus : EditorWindow
        {
            private int hp_ = 0;
            private int attack_ = 0;
            private int speed_ = 0;
            private int mp_ = 0;
            private int startLevel_ = 0;
            private string name_ = "\n";
            private int ID_ = 0;
            private BaseStatus.Character character_ = BaseStatus.Character.Player;

            [MenuItem("Editor/Create/Status")]
            static public void Create()
            {
                GetWindow<CreateStatus>("CreateStatus");
            }

            private void OnGUI()
            {
                GUIUpdate();
                GUIDraw();
            }

            private void GUIUpdate()
            {
                StatusSlider(ref hp_,     "HP");
                StatusSlider(ref mp_,     "MP");
                StatusSlider(ref attack_, "ATTACK");
                StatusSlider(ref speed_,  "SPEED");

                name_ = EditorGUILayout.TextField("NAME", name_);
                ID_   = EditorGUILayout.IntField("ID",    ID_);

                character_ = (BaseStatus.Character)EditorGUILayout.EnumPopup("CHARACTER",character_);
                if (GUILayout.Button("Create"))
                {
                    CreateCharacterStatus(character_);
                }

            }

            private void StatusSlider(ref int _sliderInt,string _sliderName)
            {
                _sliderInt = EditorGUILayout.IntSlider(_sliderName,_sliderInt, 0, 255);
            }
            
            private void CreateCharacterStatus(BaseStatus.Character _character)
            {
                BaseStatus status;
                switch (_character)
                {
                    case BaseStatus.Character.Player:
                        status = new StatusPlayer();
                        status.SetStatus(hp_, mp_, attack_, speed_, name_, startLevel_, ID_);
                        BaseStatus.CreateStatusObject<StatusPlayer>(status);
                        break;
                    case BaseStatus.Character.Enemy:
                        status = new StatusEnemy();
                        status.SetStatus(hp_, mp_, attack_, speed_, name_, startLevel_, ID_);
                        BaseStatus.CreateStatusObject<StatusEnemy>(status);
                        break;
                    default:
                        status = new BaseStatus();
                        break;
                }
            }


            private void GUIDraw()
            {

            }
        }
    }
}

#endif
