void MainLight_float(float3 WorldPos, out float3 Direction, out float3 Color, out float DistanceAtten, out float ShadowAtten) {

#ifdef SHADERGRAPH_OREVIEW
Direction = float3(0.5, 0.5, 0);
Color = 1;
DistanceAtten = 1;
ShadowAtten  =1;
#else 
Light light = GetLight();
Direction = light.direction; 
Color = light.color;
DistanceAtten = light.attenuation; 
float4 shadowCoord = TransformWorld1ToShadowCoord(WorldPos); 
ShadowSamplingData shadowSamplingData = GetMainLightShadowSamplingData();
half shadowStrength = GetMainLightShadowStrength();
ShadowAtten = SampleShadowMap(shadowCoord, TEXTURE2D_ARGS(_MainLightShadowMapTexture, sampler_MainLightShadowMapTexture), shadowSamplingData, shadowStrength, false);
#endif 
}