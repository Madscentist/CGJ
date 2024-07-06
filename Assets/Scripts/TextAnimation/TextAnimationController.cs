using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mmang;
using TMPro;

namespace Game.TextAnimation
{
    public class TextAnimationController : MonoBehaviour
    {
        public TMP_Text TMPText { get; private set; }


        
        private void Awake() => TMPText = GetComponent<TMP_Text>();

        private void Update()
        {
            Test();
        }

        private void Test()
        {
            TMPText.ForceMeshUpdate();
            var textInfo = TMPText.textInfo;
            for (int i = 0; i < textInfo.characterCount; i++)
            {
                var charInfo = textInfo.characterInfo[i];
                if (!charInfo.isVisible)
                    continue;
                
                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
                for (int v = 0; v < 4; v++)
                {
                    var origin = verts[charInfo.vertexIndex + v];
                    Vector3 offset = Vector2.up * Mathf.Sin(Time.time) * 10;
                    verts[charInfo.vertexIndex + v] = origin + offset;
                }
            }

            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                var meshInfo = textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                TMPText.UpdateGeometry(meshInfo.mesh, i);
            }
        }
    }
}