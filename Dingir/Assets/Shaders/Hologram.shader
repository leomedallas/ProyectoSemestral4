Shader "Custom/Hologram"
{
	Properties
	{
		_RimPower("RimPower", Range(0.6, 8.0)) = 3.0
	}
		SubShader
	{
		Tags{"Queue" = "Transparent"}
		Pass{
			ZWrite On
			ColorMask 0
		}


		CGPROGRAM

		#pragma surface surf Lambert alpha:fade

		float _RimPower;

		struct Input
		{
			float3 viewDir;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = pow(rim, _RimPower) * float3(0, 0, 1);
			o.Alpha = pow(rim, _RimPower);
		}
		ENDCG
	}
}
