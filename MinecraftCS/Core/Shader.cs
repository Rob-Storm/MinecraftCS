using OpenTK.Graphics.OpenGL4;

namespace MinecraftCS.Core
{
    public class Shader : IDisposable
    {
        public int Handle;
        private bool disposedValue = false;

        public Shader(string vertexPath, string fragmentPath)
        {
            int VertexShader, FragmentShader;

            string VertexShaderSource = File.ReadAllText(vertexPath);

            string FragmentShaderSource = File.ReadAllText(fragmentPath);

            VertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(VertexShader, VertexShaderSource);

            FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(FragmentShader, FragmentShaderSource);

            GL.CompileShader(VertexShader);

            GL.GetShader(VertexShader, ShaderParameter.CompileStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(VertexShader);
                Console.Write(infoLog);
            }

            GL.CompileShader(FragmentShader);

            GL.GetShader(FragmentShader, ShaderParameter.CompileStatus, out int successFrag);
            if (successFrag == 0)
            {
                string infoLog = GL.GetShaderInfoLog(FragmentShader);
                Console.Write(infoLog);
            }

            Handle = GL.CreateProgram();

            GL.AttachShader(Handle, VertexShader);
            GL.AttachShader(Handle, FragmentShader);

            GL.LinkProgram(Handle);

            GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out int successProgram);

            if (successProgram == 0)
            {
                string infoLog = GL.GetProgramInfoLog(Handle);
                Console.WriteLine(infoLog);
            }

            GL.DetachShader(Handle, VertexShader);
            GL.DetachShader(Handle, FragmentShader);
            GL.DeleteShader(VertexShader);
            GL.DeleteShader(FragmentShader);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                GL.DeleteProgram(Handle);

                disposedValue = true;
            }
        }

        ~Shader()
        {
            if(!disposedValue)
            {
                Console.WriteLine("GPU Resource leak! Did you forget to call Dispose()?");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}
