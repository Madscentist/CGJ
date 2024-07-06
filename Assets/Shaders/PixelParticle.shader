Shader "Mmang/PixelParticle"
{

    Properties
    {
        [HideInInspector]_MainTex ("MainTex", 2D) = "white" { }

        _FireColor1 ("火焰颜色1", Color) = (1, 1, 1, 1)
        _FireColor2 ("火焰颜色2", Color) = (1, 1, 1, 1)
        _FireColor3 ("火焰颜色3", Color) = (1, 1, 1, 1)
        _FireColor4 ("火焰颜色4", Color) = (1, 1, 1, 1)
        _FireT ("火焰颜色阈值", Vector) = (1, 1, 1, 1)
        _FireColorLight ("火焰颜色亮度", Vector) = (1, 1, 1, 1)

        _SmokeColor1 ("烟雾颜色1", Color) = (1, 1, 1, 1)
        _SmokeColor2 ("烟雾颜色2", Color) = (1, 1, 1, 1)
        _SmokeColor3 ("烟雾颜色3", Color) = (1, 1, 1, 1)
        _SmokeColor4 ("烟雾颜色4", Color) = (1, 1, 1, 1)
        _SmokeT ("烟雾颜色阈值", Vector) = (1, 1, 1, 1)
        _SmokeColorLight ("烟雾颜色亮度", Vector) = (1, 1, 1, 1)

        _DustColor1 ("烟尘颜色1", Color) = (1, 1, 1, 1)
        _DustColor2 ("烟尘颜色2", Color) = (1, 1, 1, 1)
        _DustColor3 ("烟尘颜色3", Color) = (1, 1, 1, 1)
        _DustColor4 ("烟尘颜色4", Color) = (1, 1, 1, 1)
        _DustT ("烟尘颜色阈值", Vector) = (1, 1, 1, 1)
        _DustColorLight ("烟尘颜色亮度", Vector) = (1, 1, 1, 1)

        _LightningColor1 ("闪电颜色1", Color) = (1, 1, 1, 1)
        _LightningColor2 ("闪电颜色2", Color) = (1, 1, 1, 1)
        _LightningColor3 ("闪电颜色3", Color) = (1, 1, 1, 1)
        _LightningColor4 ("闪电颜色4", Color) = (1, 1, 1, 1)
        _LightningT ("闪电颜色阈值", Vector) = (1, 1, 1, 1)
        _LightningColorLight ("闪电颜色亮度", Vector) = (1, 1, 1, 1)
    }


    SubShader
    {


        Tags
        {
            "RenderType" = "Transparent" "RenderPipeline" = "UniversalPipeline"
        }


        Cull Off
        Blend Off
        ZTest On
        ZWrite On


        Pass
        {
            Name "RainyFog"


            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"

            CBUFFER_START(UnityPerMaterial)
            float4 _Tint;
            CBUFFER_END


            #define NOISE_SIMPLEX_1_DIV_289 0.00346020761245674740484429065744f
            float2 mod289(float2 x)
            {
	            return x - floor(x * NOISE_SIMPLEX_1_DIV_289) * 289.0;
            }

            float3 mod289(float3 x)
            {
	            return x - floor(x * NOISE_SIMPLEX_1_DIV_289) * 289.0;
            }

            float3 permute(float3 x)
            {
	            return mod289(x * x * 34.0 + x);
            }

            float3 taylorInvSqrt(float3 r)
            {
	            return 1.79284291400159 - 0.85373472095314 * r;
            }

            float2 hash22(float2 p)
            {
                float3 p3 = frac(float3(p.xyx) * float3(.1031, .1030, .0973));
                p3 += dot(p3, p3.yzx+33.33);
                return frac((p3.xx+p3.yz)*p3.zy);
            }

            float snoise(float2 v)
            {
    	        const float4 C = float4(0.211324865405187, // (3.0-sqrt(3.0))/6.0
    	        0.366025403784439, // 0.5*(sqrt(3.0)-1.0)
    	        - 0.577350269189626, // -1.0 + 2.0 * C.x
    	        0.024390243902439); // 1.0 / 41.0
    	        // First corner
    	        float2 i = floor(v + dot(v, C.yy));
    	        float2 x0 = v - i + dot(i, C.xx);

    	        // Other corners
    	        float2 i1;
    	        i1.x = step(x0.y, x0.x);
    	        i1.y = 1.0 - i1.x;

    	        // x1 = x0 - i1  + 1.0 * C.xx;
    	        // x2 = x0 - 1.0 + 2.0 * C.xx;
    	        float2 x1 = x0 + C.xx - i1;
    	        float2 x2 = x0 + C.zz;

    	        // Permutations
    	        i = mod289(i); // Avoid truncation effects in permutation
    	        float3 p = permute(permute(i.y + float3(0.0, i1.y, 1.0))
    	        + i.x + float3(0.0, i1.x, 1.0));

    	        float3 m = max(0.5 - float3(dot(x0, x0), dot(x1, x1), dot(x2, x2)), 0.0);
    	        m = m * m;
    	        m = m * m;

    	        // Gradients: 41 points uniformly over a line, mapped onto a diamond.
    	        // The ring size 17*17 = 289 is close to a multiple of 41 (41*7 = 287)
    	        float3 x = 2.0 * frac(p * C.www) - 1.0;
    	        float3 h = abs(x) - 0.5;
    	        float3 ox = floor(x + 0.5);
    	        float3 a0 = x - ox;

    	        // Normalise gradients implicitly by scaling m
    	        m *= taylorInvSqrt(a0 * a0 + h * h);

    	        // Compute final noise value at P
    	        float3 g;
    	        g.x = a0.x * x0.x + h.x * x0.y;
    	        g.y = a0.y * x1.x + h.y * x1.y;
    	        g.z = a0.z * x2.x + h.z * x2.y;
    	        return 130.0 * dot(m, g);
            }

            float remap(float x, float t1, float t2, float s1, float s2)
            {
                return (x - t1) / (t2 - t1) * (s2 - s1) + s1;
            }

            struct Attributes
            {
                float2 uv : TEXCOORD0;
                float3 normalOS : NORMAL;
                float3 tangentOS : TANGENT;
                uint vertexID : VERTEXID_SEMANTIC;
            };


            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv :TEXCOORD0;
            };


            Varyings vert(Attributes v)
            {
                Varyings o = (Varyings)0;
                o.positionCS = GetFullScreenTriangleVertexPosition(v.vertexID);
                return o;
            };

            //SAMPLER(sampler_CameraDepthTexture);
            TEXTURE2D_X(_MainTex);
            TEXTURE2D(_ParticleTex);
            TEXTURE2D(_ParticleTex2);
            SamplerState my_point_clamp_sampler;

            float4 _FireColor1, _FireColor2, _FireColor3, _FireColor4;
            float4 _FireT, _FireColorLight;
            float4 _SmokeColor1, _SmokeColor2, _SmokeColor3, _SmokeColor4;
            float4 _SmokeT, _SmokeColorLight;
            float4 _DustColor1, _DustColor2, _DustColor3, _DustColor4;
            float4 _DustT, _DustColorLight;

            float4 _LightningColor1, _LightningColor2, _LightningColor3, _LightningColor4;
            float4 _LightningT, _LightningColorLight;


            float _Hurt;

            float4 Unity_Universal_SampleBuffer_BlitSource_float(float2 uv)
            {
                uint2 pixelCoords = uint2(uv * _ScreenSize.xy);
                return LOAD_TEXTURE2D_X_LOD(_MainTex, pixelCoords, 0);
            }

            float3 GetMixParticle(float2 sourceUV)
            {
                float4 tex = SAMPLE_TEXTURE2D(_ParticleTex, my_point_clamp_sampler, sourceUV);
                //float4 tex2 = SAMPLE_TEXTURE2D(_ParticleTex2, my_point_clamp_sampler, sourceUV);
                float4 tex2 = float4(0, 0, 0, 0);

                int x = floor(sourceUV.x * 640);
                int y = floor(sourceUV.y * 360);
                int xMod2 = x % 2;
                int yMod2 = y % 2;
                int dither = xMod2 * yMod2 + (1 - xMod2) * (1 - yMod2);

                float3 result = float3(0, 0, 0);
                float3 result2 = float3(0, 0, 0);

                if (tex.x * 10 > _FireT.w + dither * 0.012)
                {
                    float idensity = tex.x * 10;
                    float3 lerp3 = lerp(_FireColor2 * _FireColorLight.y, _FireColor1 * _FireColorLight.x, step(_FireT.x + dither * 0.1, idensity));
                    float3 lerp2 = lerp(_FireColor3 * _FireColorLight.z, lerp3, step(_FireT.y + dither * 0.25, idensity));
                    float3 lerp1 = lerp(_FireColor4 * _FireColorLight.w, lerp2, step(_FireT.z + dither * 0.08, idensity));
                    float3 fireColor = lerp(float3(0, 0, 0), lerp1, step(_FireT.w + dither * 0.012, idensity));

                    result = fireColor;
                }
                else if (tex.y > 0)
                {
                    float idensity = tex.y * 10;
                    float3 lerp3 = lerp(_SmokeColor2 * _SmokeColorLight.y, _SmokeColor1 * _SmokeColorLight.x, step(_SmokeT.x + dither * 0.1, idensity));
                    float3 lerp2 = lerp(_SmokeColor3 * _SmokeColorLight.z, lerp3, step(_SmokeT.y + dither * 0.2, idensity));
                    float3 lerp1 = lerp(_SmokeColor4 * _SmokeColorLight.w, lerp2, step(_SmokeT.z + dither * 0.2, idensity));
                    float3 smokeColor = lerp(float3(0, 0, 0), lerp1, step(_SmokeT.w + dither * 0.2, idensity));

                    result = smokeColor;
                }
                else if (tex.z > 0)
                {
                    float idensity = tex.z * 10;
                    float3 lerp3 = lerp(_DustColor2 * _DustColorLight.y, _DustColor1 * _DustColorLight.x, step(_DustT.x + dither * 0.1, idensity));
                    float3 lerp2 = lerp(_DustColor3 * _DustColorLight.z, lerp3, step(_DustT.y + dither * 0.2, idensity));
                    float3 lerp1 = lerp(_DustColor4 * _DustColorLight.w, lerp2, step(_DustT.z + dither * 0.2, idensity));
                    float3 dustColor = lerp(float3(0, 0, 0), lerp1, step(_DustT.w + dither * 0.2, idensity));

                    result = dustColor;
                }

                if (false && tex2.x > 0)
                {
                    float idensity = tex2.x * 10;
                    float3 lerp3 = lerp(_LightningColor2 * _LightningColorLight.y, _LightningColor1 * _LightningColorLight.x, step(_LightningT.x + dither * 0.1, idensity));
                    float3 lerp2 = lerp(_LightningColor3 * _LightningColorLight.z, lerp3, step(_LightningT.y + dither * 0.25, idensity));
                    float3 lerp1 = lerp(_LightningColor4 * _LightningColorLight.w, lerp2, step(_LightningT.z + dither * 0.08, idensity));
                    float3 lightningColor = lerp(float3(0, 0, 0), lerp1, step(_LightningT.w + dither * 0.012, idensity));

                    result2 = lightningColor;
                }

                return result;
                
            }

            float4 frag(Varyings i) : SV_TARGET
            {
                float2 uv = i.positionCS.xy/_ScreenParams.xy;

                float4 tex = SAMPLE_TEXTURE2D(_MainTex, my_point_clamp_sampler, uv);
                //粒子效果
                float3 mixParticle = GetMixParticle(uv);
                //return float4(mixParticle.xyz, 1);
                float3 color = lerp(tex.xyz, mixParticle, step(0.0001, mixParticle.x));
                
                //ee 顺便把其他效果做在这里了
                //故障后处理

                //屏幕闪红效果
                color = lerp(color, float3(1, 0, 0), _Hurt);


                return float4(color.xyz, 1);
            };
            ENDHLSL
        }

    }
    Fallback "Unlit"

}