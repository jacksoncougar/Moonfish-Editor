using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public static class Scene
    {
        public static Dictionary<string, Program> Shaders;

        public static void LoadSceneShaders()
        {
            Shaders = new Dictionary<string, Program>(4);
            var vertexShader = new Shader("data/vertex.vert", ShaderType.VertexShader);
            var fragmentShader = new Shader("data/fragment.frag", ShaderType.FragmentShader);
            var program = new Program("shaded"); OpenGL.ReportError();

            GL.BindAttribLocation(program.ID, 0, "position"); OpenGL.ReportError();
            GL.BindAttribLocation(program.ID, 1, "texcoord"); OpenGL.ReportError();
            GL.BindAttribLocation(program.ID, 2, "compressedNormal"); OpenGL.ReportError();

            program.Link(new List<Shader>(2) { vertexShader, fragmentShader }); OpenGL.ReportError();

            vertexShader = new Shader("data/viewscreen.vert", ShaderType.VertexShader);
            fragmentShader = new Shader("data/sys_fragment.frag", ShaderType.FragmentShader);
            var viewscreenProgram = new Program("viewscreen"); OpenGL.ReportError();

            GL.BindAttribLocation(viewscreenProgram.ID, 0, "position");
            GL.BindAttribLocation(viewscreenProgram.ID, 1, "diffuse_color");

            viewscreenProgram.Link(new List<Shader>(2) { vertexShader, fragmentShader }); OpenGL.ReportError();

            vertexShader = new Shader("data/sys_vertex.vert", ShaderType.VertexShader); OpenGL.ReportError();
            fragmentShader = new Shader("data/sys_fragment.frag", ShaderType.FragmentShader); OpenGL.ReportError();
            var system_program = new Program("system"); OpenGL.ReportError();

            GL.BindAttribLocation(system_program.ID, 0, "position"); OpenGL.ReportError();
            GL.BindAttribLocation(system_program.ID, 1, "diffuse_color"); OpenGL.ReportError();

            system_program.Link(new List<Shader>(2) { vertexShader, fragmentShader }); OpenGL.ReportError();

            vertexShader = new Shader("data/sprite.vert", ShaderType.VertexShader); OpenGL.ReportError();
            fragmentShader = new Shader("data/sprite.frag", ShaderType.FragmentShader); OpenGL.ReportError();
            var spriteProgram = new Program("sprite"); OpenGL.ReportError();

            GL.BindAttribLocation(system_program.ID, 0, "position"); OpenGL.ReportError();
            GL.BindAttribLocation(system_program.ID, 1, "diffuse_color"); OpenGL.ReportError();

            system_program.Link(new List<Shader>(2) { vertexShader, fragmentShader }); OpenGL.ReportError();

            Shaders[program.Name] = program;
            Shaders[system_program.Name] = system_program;
            Shaders[viewscreenProgram.Name] = viewscreenProgram;
            Shaders[spriteProgram.Name] = spriteProgram;
        }
    }


}
