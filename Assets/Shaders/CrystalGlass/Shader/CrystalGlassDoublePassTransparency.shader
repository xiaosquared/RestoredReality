﻿Shader "Crystal Glass/Double Pass Transparency" {
	Properties {
		_EnvTex ("Environment Texture", CUBE) = "black" {}
		_NormalTex ("Normal Texture", 2D) = "black" {}
		_IOR ("Indices Of Refract", Range(-0.95, -0.8)) = -0.9
		_IOROffset ("Indices Of Refract Offset", Range(-0.05, 0.05)) = 0.02
		_FresnelPower ("Fresnel Power", Range(0, 8)) = 1.55
		_FresnelAlpha ("Fresnel Alpha Intensity", Range(0, 2)) = 1
	}
	SubShader {
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		Pass {
			Cull Front
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ CRYSTAL_GLASS_BUMP
			#include "UnityCG.cginc"
			#include "CrystalGlass.cginc"
			ENDCG
		}
		Pass {
			Cull Back
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ CRYSTAL_GLASS_BUMP
			#include "UnityCG.cginc"
			#include "CrystalGlass.cginc"
			ENDCG
		}
	}
	FallBack Off
}
