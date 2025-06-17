Shader "Custom/NewSurfaceShader"
{
    Properties
    {
        _MainTex ("Main Tex", 2D) = "white" {}
        _MaskTex ("Pixel Mask", 2D) = "white" {}
        _Fade ("Fade", Range(0, 1)) = 0
    }
    SubShader
    {
        Tags { "Queue"="Overlay" "RenderType"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _MaskTex;
            float _Fade;

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                float maskValue = tex2D(_MaskTex, i.uv).r;
                float alpha = step(_Fade, maskValue); // Blocks disappear when _Fade >= mask
                return fixed4(0, 0, 0, alpha);
            }
            ENDCG
        }
    }
}
