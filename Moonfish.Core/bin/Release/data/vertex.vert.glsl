#version 330

layout(location = 0) in vec4 position;
layout(location = 1) in vec2 diffuse_color;
layout(location = 2) in int normal;

uniform vec3 direction_to_light;
uniform float light_intensity;

uniform mat3 normal_view_matrix;

uniform mat4 object_extents;

uniform mat4 object_matrix;
uniform mat4 view_projection_matrix;

smooth out vec4 frag_diffuse_color;


void inflate (inout vec4 value)
{
	value = object_extents * value;
}

void main()
{
	vec4 normalized_position = position;
	inflate(normalized_position);
    gl_Position = object_matrix * view_projection_matrix * normalized_position;
	vec3 d = vec3(position);
	vec3 normal_in_view_space = normalize(d);
	float incidence_angle_cosine = dot(normal_in_view_space, direction_to_light);
	incidence_angle_cosine = clamp(incidence_angle_cosine, 0, 1);

	frag_diffuse_color = light_intensity * vec4(1.0, 0, 0, 1.0) * 1;
}