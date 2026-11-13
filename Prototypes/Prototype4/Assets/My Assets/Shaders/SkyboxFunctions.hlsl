

float3 RotateY(float3 pos, float angle)
{
    float cosAngle = cos(angle);
    float sinAngle = sin(angle);
    float3x3 rot = float3x3(
        cosAngle, 0.0, -sinAngle,
        0.0,      1.0,  0.0,
        sinAngle, 0.0,  cosAngle
    );

    return mul(rot, pos);
}

void sinusoid_float(float3 inPos, float frequency, float amplitude, float waveRotate, float time, float rotateSpeed, out float3 outPos) {

    float3 pos = inPos;    
    float angle = time * rotateSpeed;
    pos = RotateY(pos, angle);

    float radius = length(pos);                          
    float latitudeAngle = atan2(pos.z, pos.x);                 
    float longitudeAngle = atan2(pos.y, length(float2(pos.x, pos.z))); 
    
    float sine_wave = sin(latitudeAngle * frequency + waveRotate) * amplitude;   
    radius += sine_wave;
    
    pos.x = radius * cos(longitudeAngle) * cos(latitudeAngle);    
    pos.z = radius * cos(longitudeAngle) * sin(latitudeAngle);
    outPos = pos;    
  
}