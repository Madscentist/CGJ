using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Mmang
{
    public class PixelCamera : SingletonMono<PixelCamera>
    {
        public Vector2Int Resolution = new(640, 360);
        public RTHandle ParticleTex;

        public Camera Camera { get; private set; }

        protected override void OnAwake()
        {
            base.OnAwake();

            Camera = GetComponent<Camera>();

            ParticleTex?.Release();
            ParticleTex = RTHandles.Alloc(Resolution.x, Resolution.y, 32);        
            Camera.targetTexture = ParticleTex;
            Shader.SetGlobalTexture("_ParticleTex", ParticleTex);
        }

    }
}
