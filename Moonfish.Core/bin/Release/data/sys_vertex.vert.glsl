#version 330

layout(location = 0) in vec4 position;
layout(location = 1) in vec4 diffuse_color;

uniform mat4 object_matrix;
uniform mat4 view_projection_matrix;

smooth out vec4 frag_diffuse_color;

void main()
{
	vec4 normalized_position = position;
    gl_Position = object_matrix * view_projection_matrix * normalized_position;
	frag_diffuse_color = diffuse_color;
}