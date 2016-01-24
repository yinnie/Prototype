Shader "Custom/BackgroundGradient"
{
	Properties
	{
//		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_BaseColor ("Base Color", Color) = (1,1,1,1)
		_TargetColor ("Target Color", Color) = (1,1,1,1)
		
		[Enum(UnityEngine.Rendering.CompareFunction)] _StencilComp("Stencil Comparison", Float) = 8
		[Enum(UnityEngine.Rendering.StencilOp)] _StencilOp ("Stencil Operation", Float) = 0
		_StencilValue("Stencil Value", Int) = 0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		ZTest Always
//		Blend One OneMinusSrcAlpha

		Pass
		{
			Stencil
			{
	            Ref [_StencilValue]
	            Comp [_StencilComp] 
                Pass [_StencilOp]
	        }
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				half2 texcoord  : TEXCOORD0;
			};
			
			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;

				return OUT;
			}

			fixed4 _BaseColor;
			fixed4 _TargetColor;

			fixed4 frag(v2f IN) : SV_Target
			{
//				fixed4 c = _BaseColor;
				
				return lerp(_BaseColor, _TargetColor, IN.texcoord.y);
//				c.rgb *= c.a;
//				return c;
			}
		ENDCG
		}
	}
}
