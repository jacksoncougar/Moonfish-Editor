#version 330

layout(location = 0) in vec4 position;
layout(location = 1) in vec4 diffuse_color;

layout(std140) uniform GlobalMatrices
{
	uniform mat4 objectExtents;
	uniform mat4 objectWorldMatrix;
	uniform mat4 viewProjectionMatrix;
};

smooth out vec4 frag_diffuse_color;

void main()
{
    gl_Position = viewProjectionMatrix  * objectWorldMatrix * position;
	frag_diffuse_color = diffuse_color;
}