using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using System.IO;
using System.Windows.Forms;
using OpenTK;

namespace Moonfish.Graphics
{
    public class Program : IDisposable
    {
        int program_id;

        public readonly string Name;

        Dictionary<string, int> uniforms;
        Dictionary<string, Stack<Object>> uniformStack;

        public int ID { get { return program_id; } }

        public Program(List<Shader> shader_list, string name)
        {
            this.Name = name;

            uniforms = new Dictionary<string, int>();
            uniformStack = new Dictionary<string, Stack<object>>();

            program_id = GL.CreateProgram();

            foreach (Shader shader in shader_list)
            {
                GL.AttachShader(program_id, shader.ID);
            }

            GL.LinkProgram(program_id);

            int status;
            GL.GetProgram(program_id, GetProgramParameterName.LinkStatus, out status);
            if (status == 0)
            {
                string program_log = GL.GetProgramInfoLog(program_id);
                MessageBox.Show(String.Format("Linker failure: {0}\n", program_log));
            }

            foreach (Shader shader in shader_list)
            {
                GL.DetachShader(program_id, shader.ID);
            }
            Initialize();
        }

        private void Initialize()
        {
            GL.BindFragDataLocation(ID, 0, "frag_color");
        }

        public IDisposable Using(string uniformName, object value)
        {
            uniformStack[uniformName].Push(value);
            this[uniformName] = uniformStack[uniformName].Pop();
            return new UniformHandle(uniformStack[uniformName].Peek(), GetUniformID(uniformName));
        }

        private class UniformHandle : IDisposable
        {
            Object previous_uniform_value;
            int uniform_id;

            public UniformHandle(Object previousUniformValue, int uniformID)
            {
                previous_uniform_value = previousUniformValue;
                uniform_id = uniformID;
            }

            public void Dispose()
            {
                Program.SetUniform(previous_uniform_value, uniform_id);
            }
        }

        public object this[string uniform_name]
        {
            set
            {
                Use();
                int uid;
                uid = GetUniformID(uniform_name);
                if (!uniformStack.ContainsKey(uniform_name))
                {
                    uniformStack[uniform_name] = new Stack<object>();
                    uniformStack[uniform_name].Push(value);
                }
                SetUniform(value, uid);
            }
        }

        private int GetUniformID(string uniform_name)
        {
            int uid;
            if (uniforms.ContainsKey(uniform_name))
                uid = uniforms[uniform_name];
            else
            {
                uid = uniforms[uniform_name] = GL.GetUniformLocation(ID, uniform_name);
            }
            return uid;
        }

        private static void SetUniform(object value, int uid)
        {
            Type t = value.GetType();
            if (t == typeof(Matrix4))
            {
                var temp = (Matrix4)value;
                GL.UniformMatrix4(uid, false, ref temp);
            }
            else if (t == typeof(Matrix3))
            {
                var temp = (Matrix3)value;
                GL.UniformMatrix3(uid, false, ref temp);
            }
            else if (t == typeof(Vector3))
            {
                GL.Uniform3(uid, (Vector3)value);
            }
            else if (t == typeof(float))
            {
                var temp = (float)value;
                GL.Uniform1(uid, temp);
            }
            else throw new InvalidDataException();
        }

        public IDisposable Use()
        {
            GL.UseProgram(this.ID);
            return new Handle(0);
        }

        private class Handle : IDisposable
        {
            int previous_program_id;

            public Handle(int prev)
            {
                previous_program_id = prev;
            }

            public void Dispose()
            {
                GL.UseProgram(previous_program_id);
            }
        }

        public void Dispose()
        {
            GL.DeleteProgram(this.ID);
            GL.UseProgram(0);
        }
    }
}
