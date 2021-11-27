
    Shader "ShaderMan/test"
	{
	Properties{
	
	}
	SubShader
	{
	Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
	Pass
	{
	ZWrite Off
	Blend SrcAlpha OneMinusSrcAlpha
	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "UnityCG.cginc"
			
    

    float4 vec4(float x,float y,float z,float w){return float4(x,y,z,w);}
    float4 vec4(float x){return float4(x,x,x,x);}
    float4 vec4(float2 x,float2 y){return float4(float2(x.x,x.y),float2(y.x,y.y));}
    float4 vec4(float3 x,float y){return float4(float3(x.x,x.y,x.z),y);}


    float3 vec3(float x,float y,float z){return float3(x,y,z);}
    float3 vec3(float x){return float3(x,x,x);}
    float3 vec3(float2 x,float y){return float3(float2(x.x,x.y),y);}

    float2 vec2(float x,float y){return float2(x,y);}
    float2 vec2(float x){return float2(x,x);}

    float vec(float x){return float(x);}
    
    

	struct VertexInput {
    float4 vertex : POSITION;
	float2 uv:TEXCOORD0;
    float4 tangent : TANGENT;
    float3 normal : NORMAL;
	//VertexInput
	};
	struct VertexOutput {
	float4 pos : SV_POSITION;
	float2 uv:TEXCOORD0;
	//VertexOutput
	};
	
	
	VertexOutput vert (VertexInput v)
	{
	VertexOutput o;
	o.pos = UnityObjectToClipPos (v.vertex);
	o.uv = v.uv;
	//VertexFactory
	return o;
	}
    
    float3 hsl2rgb( in float3 c )
{
    float3 rgb = clamp( abs(fmod(c.x*6.0+vec3(0.0,4.0,2.0),6.0)-3.0)-1.0, 0.0, 1.0 );
    return c.z + c.y * (rgb-0.5)*(1.0-abs(2.0*c.z-1.0));
}



    
    
	fixed4 frag(VertexOutput vertex_output) : SV_Target
	{
	

    float timePeriod = 20.0;
    float wavePeriod = 25.0;
    float width = 10.0;
    float2 screenCoord = vertex_output.uv - 1/2.0;
    float2 uv =  width * screenCoord / min(1, 1);


    float x = uv.x;
    float y = uv.y;
    float z = 0.0;
    z = wavePeriod * fmod(_Time.y,timePeriod)/timePeriod;
    float d = sin(x)*cos(y) + sin(y)*cos(z) + sin(z)*cos(x);
    // diamond
    //d = sin(x)*sin(y)*sin(z)+sin(x)*cos(y)*cos(z)+cos(x)*sin(y)*cos(z)+cos(x)*cos(y)*sin(z);
    //Schwartz
    //d = cos(x)+cos(y)+cos(z);
    


    float h = (d + 2.0)/4.0;
    float s = 0.5;
    float l = 0.5;

    if(0.49<h&&h<0.51){l=0.0;};

    float3 col = hsl2rgb(vec3(h,s,l));

    // Output to screen
    return vec4(col,1.0);

	}
	ENDCG
	}
  }
  }
