using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AG_API;
using Microsoft.CSharp;


namespace AccessGranted.Languages
{
    internal class CSharpUserProgram : IUserProgram
    {
        private CSharpCodeProvider provider;
        private CompilerParameters parameters;
        private MethodInfo method;

        public CSharpUserProgram()
        {
            provider = new();
            parameters = new()
            {
                GenerateInMemory = true,
                TreatWarningsAsErrors = false,
                WarningLevel = 4
            };
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add(typeof(Machine).Assembly.Location);
        }

        public string? Compile()
        {
            var results = provider.CompileAssemblyFromFile(parameters, Directory.EnumerateFiles(IUserProgram.programPath, "*.cs").ToArray());

            if (results.Errors.Count > 0)
            {
                return string.Join(Environment.NewLine, results.Errors.Cast<CompilerError>().Select(e => e.ErrorText));
            }

            var candidates = 
                from t in results.CompiledAssembly.GetTypes()
                from m in t.GetMethods()
                where m.IsPublic
                where m.IsStatic
                where m.ReturnType == typeof(void)
                where m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(AG_API.Case)
                select m;

            int c = candidates.Count();
            if (c < 1) return "Could not find any entrance method (public static void method with single parameter of type Case)";
            else if (c == 1) method = candidates.First();
            else
            {
                var reduced = candidates.Where(m => m.IsDefined(typeof(EntranceMethodAttribute)));
                if (reduced.Count() != 1) return "Could not identify single entrance method (public static void method with single parameter of type Case with EntranceMethod atttribute)";
                method = reduced.First();
            }
            return null;
        }

        public bool RunCase()
{
            Case c = new(); // TODO: Replace with proper generation
            _ = method.Invoke(null, [c]);
            return CaseHandler.Evaluate(c);
        }
    }
}
