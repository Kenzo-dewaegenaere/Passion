
    Shader "test1"
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
    
    // Fork of "Truchet Hills" by gls9102. https://shadertoy.com/view/wslcz2
// 2021-11-25 05:14:08

// v1.0.1

#define PI 3.1415
#define ITERATIONS 25.

float ran21(float2 uv) {
    return frac(cos(dot(cos(uv.x*uv.y)-32.2,tan(uv.x/uv.y)-23.5)*1322.24)*432122.62);
}


    
    
	fixed4 frag(VertexOutput vertex_output) : SV_Target
	{
	
    float2 uv = (vertex_output.uv-.5*1)/1;
    float2 uvb = uv;

    float3 col = vec3(0);
    [unroll(100)]
for(float i=1.;i<=ITERATIONS;i++) {
        float cur = i/ITERATIONS;
        uv = uvb;
        uv *= (25.*ITERATIONS/(ITERATIONS+i))-(cur*1.)/(length(uvb/uv));
        uv.y += _Time.y*0.6;
    
        float2 gv = frac(uv)-.5;
        float2 id = floor(uv);
    
        gv.x *= (ran21(id)>.5) ? -1. : 1.;
        float2 ruv = gv-sign(gv.x+gv.y+.001)*.5;
        float tile = smoothstep(.01,-.01,abs(length(ruv)-.5)-.1);
        float rot = atan2(ruv.y,ruv.x)/PI;
    
        float mul = fmod(id.x+id.y,2.)==1. ? -1. : ITERATIONS/i;
        float h = smoothstep((ITERATIONS/cur+.1)/gv.x,cur,sin(abs(rot*cur*mul+_Time.y)*PI)*.25+.75);
        
        col.b -= (h*tile*cur)/(h/i);
        col.b *= .85-((h/i)/(h*tile*cur));
        col.gb *= .95-((col.r + col.g )/(h*i));
        
        col = max(col,h*tile*cur);
    }
    
    return vec4(col,1.0);

	}
	ENDCG
	}
  }
  }
