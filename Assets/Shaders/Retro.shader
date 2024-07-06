Shader "URP/Retro"
{
    Properties
    {
        [HideInInspector] _MainTex("MainTex",2D) = "white"{}
        _Curvature ("Curvature", Float) = 1
        _Brightness ("Brightness", Float) = 1
        _ScanningLines ("ScanningLines", Float) = 8
        _ScanningLinesSpeed ("ScanningLinesSpeed", Float) = 1
        [Range(0, 1)] _ScanningLinesAmount ("ScanningLinesAmount", Float) = 0.5
        _NoiseSpeed ("NoiseSpeed", Float) = 1
        _NoiseScale ("NoiseScale", Float) = 1
        _NoiseAmount ("NoiseAmount", Float) = 0.5
    }

    SubShader
    {
        Tags{
            "RenderType" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
        }
        Cull Off
        Blend Off
        ZTest Off
        ZWrite Off

        HLSLINCLUDE
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            CBUFFER_START(UnityPerMaterial)
                float4 _Tint;
                float _Curvature;
                float _Brightness;
                float _ScanningLines;
                float _ScanningLinesSpeed;
                float _ScanningLinesAmount;
                float _NoiseSpeed;
                float _NoiseScale;
                float _NoiseAmount;
            CBUFFER_END

            TEXTURE2D(_MainTex);
            //TEXTURE2D_X(_MainTex);
            SAMPLER(sampler_MainTex);
            SamplerState my_point_clamp_sampler;


            struct a2v
            {
                float4 positionOS : POSITION;
                uint vertexID : VERTEXID_SEMANTIC;
            };
            struct v2f
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
        ENDHLSL

        pass
        {
            Name "PixelPass"
            HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                float4 Unity_Universal_SampleBuffer_BlitSource_float(float2 uv)
                {
                    uint2 pixelCoords = uint2(uv * _ScreenSize.xy);
                    return LOAD_TEXTURE2D_X_LOD(_MainTex, pixelCoords, 0);
                    //return SAMPLE_TEXTURE2D(_MainTex, my_point_clamp_sampler, pixelCoords);
                }
                v2f vert(a2v i)
                {
                    v2f o;
                    o.uv = float2(0,0);
                    o.positionCS = GetFullScreenTriangleVertexPosition(i.vertexID);
                    return o;
                }

                float2 hash22(float2 p)
                {
                  float3 p3 = frac(float3(p.xyx) * float3(.1031, .1030, .0973));
                  p3 += dot(p3, p3.yzx+33.33);
                  return frac((p3.xx+p3.yz)*p3.zy);
                }

                float remap(float x, float t1, float t2, float s1, float s2)
                {
                    return (x - t1) / (t2 - t1) * (s2 - s1) + s1;
                }

                float GetLine(float2 uv)
                {
                    int y = uv.y * 360;
                    if (y % 4 == 0)
                        return 1;
                    return 0;
                }

                half4 frag(v2f i) : SV_TARGET
                {
                    //
                    float2 uv = i.positionCS.xy / _ScreenParams.xy;
                    
                    //
                    float vignet = saturate(pow(uv.x * uv.y * (1 - uv.x) * (1 - uv.y) * 200, 2));

                    //
                    float d = distance(uv, float2(0.5, 0.5));
                    float d1 = min(distance(uv.x, 0.5), distance(uv.y, 0.5));
                    d *= lerp(1, 1.2, pow(d1, _Curvature));
                    float2 dir = normalize(uv - float2(0.5, 0.5));
                    uv = dir * d + float2(0.5, 0.5);
                    
                    //
                    if (uv.x < 0 || uv.x > 1 || uv.y < 0 || uv.y > 1)
                        return float4(0, 0, 0, 0);

                    //
                    float noise = hash22(uv * _NoiseScale + _Time.y * _NoiseSpeed).x;
                    //
                    //float offset = _Time.y * _ScanningLinesSpeed;
                    
                    //float shine = remap(sin(_SinTime.y * 15), 0, 1, 0.6, 1);
                    //float lines = step(frac(uv.y * _ScanningLines + offset), 0.23) * 0.8;
                    //lines *= shine;
                    float3 tex = SAMPLE_TEXTURE2D(_MainTex, my_point_clamp_sampler, uv);
                    float isLine = GetLine(uv);
                    float3 color = lerp(tex, tex * 0.8, isLine);
                    //color.rb *= pow(sin(uv.y * 640) + 1, 2) * _Brightness;
                    //color.g *= pow(cos(uv.y * 640) + 1, 2) * _Brightness;
                    //float4 color = lerp(tex, lines, _ScanningLinesAmount);
                    //color = lerp(color, noise, _NoiseAmount) * vignet;
                    color *= vignet;
                    return float4(color, 1);
                }

            ENDHLSL
        }
    }
}