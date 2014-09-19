#version  330

layout(location = 0) in vec4 position;
layout(location = 2) in int normal;

uniform mat4 object_extents;

uniform mat4 object_matrix;
uniform mat4 view_projection_matrix;

smooth out vec3 frag_diffuse_color;
smooth out vec3 vertexPosition;

void main()
{
    gl_Position = view_projection_matrix  * object_matrix * object_extents * position;
	vertexPosition = gl_Position.xyz;
	
	
	int normalSwapped = normal;//int(((normal>>24)&0xff) | ((normal<<8)&0xff0000) |  ((normal>>8)&0xff00) | ((normal<<24)&0xff0000));

	int x10 = (normalSwapped & 0x000007FF);
	if ((x10 & 0x00000400) == 0x00000400)
	{
		x10 = -((~x10) & 0x000007FF);
		if (x10 == 0) x10 = -1;
	}
	int y11 = (normalSwapped >> 11) & 0x000007FF;
	if ((y11 & 0x00000400) == 0x00000400)
	{
		y11 = -((~y11) & 0x000007FF);
		if (y11 == 0) y11 = -1;
	}
	int z11 = (normalSwapped >> 22) & 0x000003FF;
	if ((z11 & 0x00000200) == 0x00000200)
	{
		z11 = -((~z11) & 0x000003FF);
		if (z11 == 0) z11 = -1;
	}

	float x = float(x10) / 1023.0;
	float y = float(y11) / 1023.0;
	float z = float(z11) / 511.0;
	
	mat3 normalMatrix = mat3(view_projection_matrix);
	
	frag_diffuse_color = normalMatrix * vec3(x,y,z);
}