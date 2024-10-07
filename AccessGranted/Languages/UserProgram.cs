using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessGranted.Languages
{
    internal interface IUserProgram
    {
        public const string programPath = "./program/";

        public static IUserProgram GetProgram(Language language)
        {
            switch (language)
            {
                case Language.CSharp:
                    {
                        return new CSharpUserProgram();
                    }
            }
        }

        public bool RunCase();

        public string? Compile();
    }
}
