using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "LetterConfig", menuName = "Config/LetterConfig")]
    class LetterConfig : ScriptableObject
    {
        [SerializeField]
        internal List<GameObject> Letters;
    }   
}