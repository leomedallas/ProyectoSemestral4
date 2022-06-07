Shader "Parcial4/Holograma1"
{
	Properties
	{
		_RimPower("RimPower", Range(0.5, 8.0)) = 3.0
	}
		SubShader
	{
		Tags{"Queue" = "Geometry"}
		Pass{
			ZWrite On
			ColorMask 0
		}


		CGPROGRAM

		#pragma surface surf Lambert 

		half _RimPower;

		struct Input
		{
			float3 viewDir;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = pow(rim, _RimPower) * 10;
		}
		ENDCG
	}
}
