Shader "Custom/pow shader" {
	Properties {
		_TintColor ("Tint Color", Color) = (1,1,1,1)
		_PowMap ("Fill R, Pow G, Dots B", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Fill 	("Fill Color", Color) = (1,1,1,1)
		_Pow	("Pow Color", Color) = (1,1,1,1)
		_Dots	("Dots Color", Color) = (1,1,1,1)
//		_Cutoff ("Alpha Cutoff", Float) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _PowMap;

		struct Input {
			float2 uv_PowMap;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _TintColor;
		fixed4 _Fill;
		fixed4 _Pow;
		fixed4 _Dots;
	

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_PowMap, IN.uv_PowMap);
			fixed4 Fill = c.r * _Fill;
			fixed4 Pow = c.g * _Pow;
			fixed4 Dots = c.b * _Dots;
			// Albedo comes from a texture tinted by color
			o.Albedo = Fill+Pow+Dots;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a * _TintColor.a;
	
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
