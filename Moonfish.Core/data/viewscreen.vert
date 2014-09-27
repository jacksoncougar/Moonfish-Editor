 #version 130

in vec4 position;
in vec4 diffuse_color;

	uniform mat4 objectExtents;
	uniform mat4 objectWorldMatrix;
	uniform mat4 viewProjectionMatrix;

smooth out vec4 frag_diffuse_color;

void main()
{
    vec4 viewPosition = viewProjectionMatrix  * objectWorldMatrix * position;
	
	gl_Position = viewPosition;
	frag_diffuse_color = diffuse_color;
}