#version 330

smooth in vec4 frag_diffuse_color;
smooth in vec3 vertexPosition;

out vec4 frag_color;

void main()
{
    vec3 normal = frag_diffuse_color.xyz;
	vec3 light = vec3(1, 0.8, 0.6);
	vec3 lightNormal = normalize(light - vertexPosition);
	vec3 eyeNormal = normalize(-vertexPosition);
	vec3 reflection = normalize(-reflect(lightNormal, normal));
	
	vec4 ambient = vec4(0.25, 0.16, 0.0, 1.0);
	vec4 diffuse = vec4(.1, .1, 0.1, 1.0) * max(dot(normal, lightNormal), 0.0);
	diffuse = clamp(diffuse, 0.0, 1.0);
	
	float specularLevel = 8.;
	vec4 specular = vec4(0.8, 0.5, 0.0, 1.0)  * pow(max(dot(reflection, eyeNormal), 0.0), 0.3 * specularLevel);
	specular = clamp(specular, 0.0, 1.0);
	
	frag_color =  vec4(0, 0, 0, 1.0) + ambient + diffuse + specular;
}
