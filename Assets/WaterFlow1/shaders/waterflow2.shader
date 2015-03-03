Shader "Custom/waterflow2" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
	_Shininess ("Shininess", Range (0.03, 1)) = 0.078125
	_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	
	_WaterSpeed ("WaterSpeed", Range (-10, 10)) = 0.1	
	
	_PerlinTex ("Perlin (RGB)", 2D) = "white" {}
	_Speed("Speed", Float) = 0.15 // cloud speed
	_Scale("Scale", Float) = 0.5 // cloud scale
	_Brightness("Brightness", Float) = 4 // cloud brightness	
	
	
}
SubShader { 
	//Tags { "RenderType"="Opaque" }
	Tags { "RenderType"="Opaque"  }
	Tags { "Queue" = "Geometry+1" }
	LOD 400
	
CGPROGRAM
#pragma target 3.0
#pragma surface surf BlinnPhong alpha 
//#pragma surface surf Lambert vertex:vert alpha

sampler2D _MainTex;
sampler2D _BumpMap;
sampler2D _PerlinTex;

fixed4 _Color;
half _Shininess;
half _WaterSpeed;
half _Speed;
half _Scale;
half _Brightness;

struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap;
	float2 uv_PerlinTex;	
//	float3 worldPos;
//	float3 worldNormal;
//	INTERNAL_DATA
};

/*
 void vert (inout appdata_full v, out Input o) {
	
 }*/

void surf (Input IN, inout SurfaceOutput o) 
{

	half4 perturbValue;
	half4 cloudColor;
	
	// sliding uv
	half translation = _Time.x*_Speed; 
	
	// Sample the texture value from the perturb texture using the translated texture coordinates.
	//perturbValue = tex2D (_PerlinTex, half2(IN.uv_PerlinTex.x,IN.uv_PerlinTex.y+translation));
	perturbValue = tex2D (_PerlinTex, half2(IN.uv_PerlinTex.x,IN.uv_PerlinTex.y+translation));
	// Multiply the perturb value by the perturb scale.
	perturbValue = perturbValue * _Scale;
	// Add the texture coordinates as well as the translation value to get the perturbed texture coordinate sampling location.
	//perturbValue.xy = perturbValue.xy + IN.uv_MainTex.xy +translation;
	perturbValue.x = perturbValue.x + (IN.uv_MainTex.x +translation);
//	perturbValue.y = perturbValue.y + IN.uv_MainTex.y +translation;
	// Now sample the color from the cloud texture using the perturbed sampling coordinates.
	//cloudColor = tex2D (_MainTex, perturbValue.xy);
	// Reduce the color cloud by the brightness value.
	//cloudColor = cloudColor * _Brightness;		

//	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);

	fixed slide = _Time.x*_WaterSpeed;
	//fixed slide = _Time.x*((-IN.worldNormal.z)*40);
	fixed4 tex = tex2D(_MainTex, half2(IN.uv_MainTex.x,IN.uv_MainTex.y+slide));

	//half4 bum = tex2D(_BumpMap, half2(IN.uv_BumpMap.x,IN.uv_BumpMap.y+slide));
	half4 bum = tex2D(_BumpMap, half2(IN.uv_BumpMap.x*0.1,(IN.uv_BumpMap.y+perturbValue.y*0.2)*0.2));
	//half4 bum = tex2D(_BumpMap, perturbValue.xy);


	o.Albedo = tex.rgb * _Color.rgb;
	//o.Albedo = _Color.rgb;
	half g = (tex.r+bum.r);
	//o.Gloss = tex.r*10;//g*4;
	o.Gloss = tex.r*10;//g*4;
	//o.Alpha = tex.a * _Color.a;
	o.Alpha = g*tex.g*2; //tex.r*bum.;
	//o.Specular = _Shininess;
	o.Specular = tex.r*bum.g;
	//o.Specular = bum*0.5;
	//o.Specular = bum*0.5;
	//o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
//	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	o.Normal = UnpackNormal(bum);
}
ENDCG
}

FallBack "Specular"
}
