#version 330

layout(location = 0) in vec4 position;
layout(location = 2) in vec4 normaltanbi;

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
    gl_Position = view_projection_matrix  * object_matrix * object_extents*  normalized_position;
	vec4 normal = normaltanbi;
	normal = normalize(normal);
	float cosineAngleIncident = dot(normal, vec4(0.0, 0.0, 1.0, 1.0));
	cosineAngleIncident = clamp(cosineAngleIncident, .8, 1);
	frag_diffuse_color = vec4(.88, .88, .88, 1.0) * cosineAngleIncident;
}