using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Mmang
{
    public class PostRenderFeature : ScriptableRendererFeature
    {
        [System.Serializable]
        public class Setting
        {
            public RenderPassEvent passEvent = RenderPassEvent.AfterRenderingTransparents;
            public Material mat;
        }

        public Setting setting = new();

        class CustomRenderPass : ScriptableRenderPass
        {
            Material mat;
            RTHandle colorRT;
            static readonly int _MainTexShaderID = Shader.PropertyToID("_MainTex");

            public CustomRenderPass(Setting setting)
            {
                mat = setting.mat;
            }

            public void Setup(in RenderingData renderingData)
            {
                RenderTextureDescriptor colorCopy = renderingData.cameraData.cameraTargetDescriptor;
                colorCopy.depthBufferBits = (int)DepthBits.None;
                RenderingUtils.ReAllocateIfNeeded(ref colorRT, colorCopy, name: "PixelPassColor");
            }

            public void Dispose()
            {
                colorRT?.Release();
            }

            public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
            {
                
            }

            public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
            {
                if (mat == null || renderingData.cameraData.isSceneViewCamera)
                    return;
                if (renderingData.cameraData.isPreviewCamera)
                    return;
                //
                CommandBuffer cmd = CommandBufferPool.Get("Post");
                CameraData cameraData = renderingData.cameraData;

                RTHandle sourceRT;

                //
                sourceRT = cameraData.renderer.cameraColorTargetHandle;
                //  
                Blitter.BlitCameraTexture(cmd, sourceRT, colorRT);
                mat.SetTexture(_MainTexShaderID, sourceRT);
                //
                CoreUtils.SetRenderTarget(cmd, cameraData.renderer.cameraColorTargetHandle);
                CoreUtils.DrawFullScreen(cmd, mat);
                //
                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();
            }

            public override void OnCameraCleanup(CommandBuffer cmd)
            {

            }
        }

        CustomRenderPass m_ScriptablePass;

        public override void Create()
        {
            m_ScriptablePass = new CustomRenderPass(setting);
            m_ScriptablePass.renderPassEvent = setting.passEvent;
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (PixelCamera.Instance == null)
                return;
            //m_ScriptablePass.Setup(renderer.cameraColorTarget);
            m_ScriptablePass.Setup(renderingData);
            renderer.EnqueuePass(m_ScriptablePass);
        }

        protected override void Dispose(bool disposing)
        {
            m_ScriptablePass.Dispose();
        }
    }

}