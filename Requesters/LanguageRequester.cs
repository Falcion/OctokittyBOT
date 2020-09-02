using Octokit;

public class LanguageRequester {

        public Language LanguageRegister(string filterString) {

            filterString 
                    = filterString.Remove(0, 11);

            switch(filterString) {

                case "abap": 
                    return Language.Abap;

                case "actionscript": 
                    return Language.ActionScript;

                case "ada": 
                    return Language.Ada;

                case "apacheconf": 
                    return Language.ApacheConf;

                case "apex": 
                    return Language.Apex;

                case "applescript": 
                    return Language.AppleScript;

                case "arc": 
                    return Language.Arc;

                case "arduino": 
                    return Language.Arduino;

                case "asp": 
                    return Language.Asp;

                case "assembly":
                    return Language.Assembly;

                case "augeas":
                    return Language.Augeas;

                case "autohotkey":
                    return Language.AutoHotKey;

                case "awk":
                    return Language.Awk;

                case "batchfile":
                    return Language.Batchfile;

                case "befunge":
                    return Language.Befunge;

                case "blitzmax":
                    return Language.BlitzMax;

                case "boo":
                    return Language.Boo;

                case "bro":
                    return Language.Bro;

                case "c":
                    return Language.C;

                case "c2hshaskell":
                    return Language.C2hsHaskell;

                case "ceylon":
                    return Language.Ceylon;

                case "chuck":
                    return Language.Chuck;

                case "clips":
                    return Language.Clips;

                case "clojure":
                    return Language.Clojure;

                case "cmake":
                    return Language.Cmake;

                case "cobjdump":
                    return Language.CObjDump;

                case "cobol":
                    return Language.Cobol;

                case "coffeescript":
                    return Language.CoffeeScript;

                case "coldfusion":
                    return Language.ColdFusion;

                case "commonlisp":
                    return Language.CommonLisp;

                case "coq":
                    return Language.Coq;

                case "cplusplus":
                    return Language.CPlusPlus;

                case "cppobjdump":
                    return Language.CppObjDump;

                case "csharp":
                    return Language.CSharp;

                case "css":
                    return Language.Css;

                case "cucumber":
                    return Language.Cucumber;

                case "cython":
                    return Language.Cython;

                case "d":
                    return Language.D;

                case "darcspatch":
                    return Language.DarcsPatch;

                case "dart":
                    return Language.Dart;

                case "dcpu16asm":
                    return Language.Dcpu16Asm;

                case "dobjdump":
                    return Language.DObjDump;

                case "dot":
                    return Language.Dot;

                case "dylan":
                    return Language.Dylan;

                case "ec":
                    return Language.Ec;

                case "ecereprojects":
                    return Language.EcereProjects;

                case "ecl":
                    return Language.Ecl;

                case "edn":
                    return Language.Edn;

                case "eiffel":
                    return Language.Eiffel;

                case "elixir":
                    return Language.Elixir;

                case "elm":
                    return Language.Elm;

                case "emacslisp":
                    return Language.EmacsLisp;

                case "erlang":
                    return Language.Erlang;

                case "factor":
                    return Language.Factor;

                case "fancy":
                    return Language.Fancy;

                case "fantom":
                    return Language.Fantom;

                case "fish":
                    return Language.Fish;

                case "forth":
                    return Language.Forth;

                case "fortran":
                    return Language.Fortran;

                case "fsharp":
                    return Language.FSharp;

                case "gas":
                    return Language.Gas;

                case "genshi":
                    return Language.Genshi;

                case "gentoobuild":
                    return Language.GentooBuild;

                case "gentooeclass":
                    return Language.GentooEclass;

                case "gettextcatalog":
                    return Language.GettextCatalog;

                case "glsl":
                    return Language.Glsl;

                case "go":
                    return Language.Go;

                case "gosu":
                    return Language.Gosu;

                case "groff":
                    return Language.Groff;

                case "groovy":
                    return Language.Groovy;

                case "groovyserverpages":
                    return Language.GroovyServerPages;

                case "haml":
                    return Language.Haml;

                case "handlebars":
                    return Language.HandleBars;

                case "haskell":
                    return Language.Haskell;

                case "haxe":
                    return Language.Haxe;

                case "http":
                    return Language.Http;

                case "ini":
                    return Language.Ini;

                case "io":
                    return Language.Io;

                case "ioke":
                    return Language.Ioke;

                case "irclog":
                    return Language.IrcLog;

                case "j":
                    return Language.J;

                case "java":
                    return Language.Java;

                case "javascript":
                    return Language.JavaScript;

                case "javaserverpages":
                    return Language.JavaServerPages;

                case "json":
                    return Language.Json;

                case "julia":
                    return Language.Julia;

                case "jupyternotebook":
                    return Language.JupyterNotebook;

                case "kotlin":
                    return Language.Kotlin;

                case "lasso":
                    return Language.Lasso;

                case "less":
                    return Language.Less;

                case "lfe":
                    return Language.Lfe;

                case "lillypond":
                    return Language.LillyPond;

                case "literatecoffeescript":
                    return Language.LiterateCoffeeScript;

                case "literatehaskell":
                    return Language.LiterateHaskell;

                case "livescript":
                    return Language.LiveScript;

                case "llvm":
                    return Language.Llvm;

                case "logos":
                    return Language.Logos;

                case "logtalk":
                    return Language.Logtalk;

                case "lua":
                    return Language.Lua;

                case "m":
                    return Language.M;

                case "makefile":
                    return Language.Makefile;

                case "mako":
                    return Language.Mako;

                case "markdown":
                    return Language.Markdown;

                case "matlab":
                    return Language.Matlab;

                case "max":
                    return Language.Max;

                case "minid":
                    return Language.MiniD;

                case "mirah":
                    return Language.Mirah;

                case "monkey":
                    return Language.Monkey;

                case "moocode":
                    return Language.Moocode;

                case "moonscript":
                    return Language.Moonscript;

                case "mupad":
                    return Language.Mupad;

                case "myghty":
                    return Language.Myghty;

                case "nemerle":
                    return Language.Nemerle;

                case "nginx":
                    return Language.Nginx;

                case "nimrod":
                    return Language.Nimrod;

                case "nsis":
                    return Language.Nsis;

                case "nu":
                    return Language.Nu;

                case "numpy":
                    return Language.NumPY;

                case "objdump":
                    return Language.ObjDump;

                case "objectivec":
                    return Language.ObjectiveC;

                case "objectivej":
                    return Language.ObjectiveJ;

                case "ocaml":
                    return Language.OCaml;

                case "omgrofl":
                    return Language.Omgrofl;

                case "ooc":
                    return Language.Ooc;

                case "opa":
                    return Language.Opa; 

                case "opencl":
                    return Language.OpenCL; 

                case "openedgeabl":
                    return Language.OpenEdgeAbl; 

                case "parrot":
                    return Language.Parrot; 

                case "parrotassembly":
                    return Language.ParrotAssembly; 

                case "parrotinternalrepresentation":
                    return Language.ParrotInternalRepresentation; 

                case "pascal":
                    return Language.Pascal; 

                case "perl":
                    return Language.Perl; 

                case "php":
                    return Language.Php; 

                case "pike":
                    return Language.Pike; 

                case "pogoscript":
                    return Language.PogoScript; 

                case "powershell":
                    return Language.PowerShell; 

                case "processing":
                    return Language.Processing; 

                case "prolog":
                    return Language.Prolog; 

                case "puppet":
                    return Language.Puppet; 

                case "puredata":
                    return Language.PureData; 

                case "python":
                    return Language.Python; 

                case "pythontraceback":
                    return Language.PythonTraceback; 

                case "r":
                    return Language.R; 

                case "racket":
                    return Language.Racket; 

                case "ragelinrubyhost":
                    return Language.RagelInRubyHost; 

                case "rawtokendata":
                    return Language.RawTokenData; 

                case "rebol":
                    return Language.Rebol; 

                case "redcode":
                    return Language.Redcode; 

                case "restructuredtext":
                    return Language.ReStructuredText; 

                case "rhtml":
                    return Language.Rhtml; 

                case "rouge":
                    return Language.Rouge; 

                case "ruby":
                    return Language.Ruby; 

                case "rust":
                    return Language.Rust; 

                case "sage":
                    return Language.Sage; 

                case "sass":
                    return Language.Sass; 

                case "scala":
                    return Language.Scala; 

                case "scheme":
                    return Language.Scheme; 

                case "scilab":
                    return Language.Scilab; 

                case "scss":
                    return Language.Scss; 

                case "self":
                    return Language.Self; 

                case "shell":
                    return Language.Shell; 

                case "slash":
                    return Language.Slash; 

                case "smalltalk":
                    return Language.Smalltalk; 

                case "smarty":
                    return Language.Smarty; 

                case "squirrel":
                    return Language.Squirrel; 

                case "standardml":
                    return Language.StandardML; 

                case "supercollider":
                    return Language.SuperCollider; 

                case "tcl":
                    return Language.Tcl; 

                case "tcsh":
                    return Language.Tcsh; 

                case "tea":
                    return Language.Tea; 

                case "tex":
                    return Language.TeX; 

                case "textile":
                    return Language.Textile; 

                case "toml":
                    return Language.Toml; 

                case "turing":
                    return Language.Turing; 

                case "twig":
                    return Language.Twig; 

                case "txl":
                    return Language.Txl; 

                case "typescript":
                    return Language.TypeScript; 

                case "unifiedparallelc":
                    return Language.UnifiedParallelC; 

                case "unknown":
                    return Language.Unknown;   

                case "vala":
                    return Language.Vala;

                case "verilog":
                    return Language.Verilog;

                case "vhdl":
                    return Language.Vhdl;

                case "viml":
                    return Language.VimL;

                case "visualbasic":
                    return Language.VisualBasic;

                case "volt":
                    return Language.Volt;

                case "wisp":
                    return Language.Wisp; 

                case "xc":
                    return Language.Xc; 

                case "xml":
                    return Language.Xml; 

                case "xproc":
                    return Language.XProc; 

                case "xquery":
                    return Language.XQuery; 

                case "xs":
                    return Language.Xs; 

                case "xslt":
                    return Language.Xslt; 

                case "xtend":
                    return Language.Xtend; 

                case "yaml":
                    return Language.Yaml; 
            }
            
            return Language.Unknown;
        }
    }