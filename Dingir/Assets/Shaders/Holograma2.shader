Shader "Parcial4/Holograma2"
{
	Properties
	{
		_RimColor("RimColor", Color) = (1, 1, 1, 1)
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
		float3 _RimColor;

		struct Input
		{
			float3 viewDir;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Alpha = pow(rim, _RimPower);
			o.Emission = rim > 0.5 ? pow(rim, _RimPower) * 10 * _RimColor : 1;
		}
		ENDCG
	}
}
