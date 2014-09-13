#version 330

smooth in vec4 frag_diffuse_color;

out vec4 frag_color;

void main()
{
    frag_color = frag_diffuse_color;
}