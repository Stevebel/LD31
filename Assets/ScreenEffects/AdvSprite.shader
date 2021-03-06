﻿Shader "Sprites/Advanced"
{
	Properties
	{
		_MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Color Multiplier", Color) = (1,1,1,1)
		_Brightness ("Brightness", Float) = 0
		_Contrast("Contrast", Float) = 0
		
		_Tint ("Tint", Color) = (1,1,1,1)
		_BrightnessOffset ("Brightness Offset", Float) = 0
		_ContrastOffset("Contrast Offset", Float) = 0
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		[MaterialToggle] IgnoreTextureColor ("Ignore Texture Color", Float) = 0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile DUMMY PIXELSNAP_ON IGNORETEXTURECOLOR_ON
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				half2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;
			fixed _Brightness;
			fixed _Contrast;
			fixed4 _Tint;
			fixed _BrightnessOffset;
			fixed _ContrastOffset;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color * _Tint;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;

			fixed4 frag(v2f IN) : SV_Target
			{
				
				#ifdef IGNORETEXTURECOLOR_ON
				fixed4 c = IN.color;
				#else
				fixed4 c = tex2D(_MainTex, IN.texcoord) * IN.color;
				#endif
				c.rgb *= (_Contrast + _ContrastOffset + 1);
				fixed brightness = _Brightness + _BrightnessOffset;
				c.r += brightness;
				c.g += brightness;
				c.b += brightness;
				c.rgb *= c.a;
				c.a = tex2D(_MainTex, IN.texcoord).a;
				return c;
			}
		ENDCG
		}
	}
}
