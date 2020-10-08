using System;

using Octokit;

namespace Stratum {

    public class Parser {

        public IssueFilter ISSUEFILTER(string FILTERSTRING) {
            switch(FILTERSTRING) {

                case "ALL": return IssueFilter.All;
                case "ASSIGNED": return IssueFilter.Assigned;
                case "CREATED": return IssueFilter.Created;
                case "MENTIONED": return IssueFilter.Mentioned;
                case "SUBSCRIBED": return IssueFilter.Subscribed;
            }

            return IssueFilter.All;
        }

        public RepositoryIssueRequest ISSUEREQUEST(IssueFilter ISSUEFILTER, string ISSUECREATOR, string ISSUEMENTIONED, string ISSUEASSIGNEE, string ISSUEMILESTONE) {
            
            if(ISSUECREATOR != "NONE") {

                if(ISSUEMENTIONED != "NONE") {

                    if(ISSUEASSIGNEE != "NONE") {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Mentioned = ISSUEMENTIONED,
                                Assignee = ISSUEASSIGNEE,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Mentioned = ISSUEMENTIONED,
                                Assignee = ISSUEASSIGNEE,

                            };
                        }

                    } else {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Mentioned = ISSUEMENTIONED,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Mentioned = ISSUEMENTIONED,

                            };
                        }
                    }

                } else {

                    if(ISSUEASSIGNEE != "NONE") {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Assignee = ISSUEASSIGNEE,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Assignee = ISSUEASSIGNEE,

                            };
                        }
                        
                    } else {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,

                            };
                        }
                    }
                }

            } else {

                if(ISSUEMENTIONED != "NONE") {

                    if(ISSUEASSIGNEE != "NONE") {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Mentioned = ISSUEMENTIONED,
                                Assignee = ISSUEASSIGNEE,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Mentioned = ISSUEMENTIONED,
                                Assignee = ISSUEASSIGNEE,

                            };
                        }

                    } else {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Mentioned = ISSUEMENTIONED,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Mentioned = ISSUEMENTIONED,

                            };
                        }
                    }

                } else {

                    if(ISSUEASSIGNEE != "NONE") {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Assignee = ISSUEASSIGNEE,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Assignee = ISSUEASSIGNEE,

                            };
                        }
                        
                    } else {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,

                            };
                        }
                    }
                }
            }
        }

        public CommitRequest COMMITREQUEST(DateTime DATECHECKER, DateTime UNTILDATE, DateTime SINCEDATE, string COMMITAUTHOR, string PATH, string SHA, string[] REPOSITORY) {

            if(SINCEDATE != DATECHECKER) {

                if(COMMITAUTHOR != "NONE") {

                    if(PATH != "NONE") {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Path = PATH,
                                Sha = SHA,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Path = PATH,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };
                        }

                    } else {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Sha = SHA,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };
                        }
                    }

                } else {

                    if(PATH != "NONE") {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Path = PATH,
                                Sha = SHA,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Path = PATH,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };
                        }

                    } else {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Sha = SHA,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };
                        }
                    }
                }

            } else {

                if(COMMITAUTHOR != "NONE") {

                    if(PATH != "NONE") {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Path = PATH,
                                Sha = SHA,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Path = PATH,
                                Until = UNTILDATE,
                            };
                        }

                    } else {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Sha = SHA,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Until = UNTILDATE,
                            };
                        }
                    }

                } else {

                    if(PATH != "NONE") {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Path = PATH,
                                Sha = SHA,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Path = PATH,
                                Until = UNTILDATE,
                            };
                        }

                    } else {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Sha = SHA,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Until = UNTILDATE,
                            };
                        }
                    }
                }
            }
        } 

        public Octokit.Range RANGE(string[] ARRAY) {

            int NUMBER = int.Parse(ARRAY[1]);

            switch(ARRAY[0]) {

                case ">>": return Octokit.Range.GreaterThan(NUMBER);
                case "<<": return Octokit.Range.LessThan(NUMBER);

                case ">=": return Octokit.Range.GreaterThanOrEquals(NUMBER);
                case "<=": return Octokit.Range.LessThanOrEquals(NUMBER);
            }

            return Octokit.Range.GreaterThanOrEquals(0);
        }

        public DateRange DATERANGE(string DATE) {

            DateRange DEFAULT = DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(1999, 4, 1)));

            string[] ENUMERATOR = DATE.Split(' ');
            string[] DATA = ENUMERATOR[1].Split('/');

            int MONTH = int.Parse(DATA[0]);
            int DAYS = int.Parse(DATA[1]);
            int YEAR = int.Parse(DATA[2]);

            if(MONTH > 12 || MONTH < 1) return DEFAULT;
            if(DAYS > 31 || DAYS < 1) return DEFAULT;
            if(YEAR > DateTime.Now.Year || YEAR < 1999) return DEFAULT;

            switch(ENUMERATOR[0]) {

                case ">>": return DateRange.GreaterThan(new DateTimeOffset(new DateTime(YEAR, MONTH, DAYS)));
                case "<<": return DateRange.LessThan(new DateTimeOffset(new DateTime(YEAR, MONTH, DAYS)));

                case ">=": return DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(YEAR, MONTH, DAYS)));
                case "<=": return DateRange.LessThanOrEquals(new DateTimeOffset(new DateTime(YEAR, MONTH, DAYS)));
            }

            return DEFAULT;
        }

        public Language LANGUAGE(string CONTEXT) {

            switch(CONTEXT) {

                case "ABAP": return Language.Abap;
                case "ACTIONSCRIPT": return Language.ActionScript;
                case "ADA": return Language.Ada;
                case "APACHECONF": return Language.ApacheConf;   
                case "APEX": return Language.Apex;                    
                case "APPLESCRIPT": return Language.AppleScript;                    
                case "ARC": return Language.Arc;                   
                case "ARDUINO": return Language.Arduino;                    
                case "ASP": return Language.Asp;                    
                case "ASSEMBLY": return Language.Assembly;                   
                case "AUGEAS": return Language.Augeas;                    
                case "AUTOHOTKEY": return Language.AutoHotKey;
                case "AWK": return Language.Awk;
                case "BATCHFILE": return Language.Batchfile;                    
                case "BEFUNGE": return Language.Befunge;                    
                case "BLITZMAX": return Language.BlitzMax;                    
                case "BOO": return Language.Boo;                    
                case "BRO": return Language.Bro;                   
                case "C": return Language.C;                   
                case "C2HSHASKELL": return Language.C2hsHaskell;                    
                case "CEYLON": return Language.Ceylon;                    
                case "CHUCK": return Language.Chuck;                    
                case "CLIPS": return Language.Clips;
                case "CLOJURE": return Language.Clojure;
                case "CMAKE": return Language.Cmake;
                case "COBJDUMP": return Language.CObjDump;
                case "COBOL": return Language.Cobol;                    
                case "COFFEESCRIPT": return Language.CoffeeScript;                    
                case "COLDFUSION": return Language.ColdFusion;                    
                case "COMMONLISP": return Language.CommonLisp;                    
                case "COQ": return Language.Coq;                    
                case "CPLUSPLUS": return Language.CPlusPlus;
                case "C++": return Language.CPlusPlus;
                case "CPPOBJDUMP": return Language.CppObjDump;
                case "C++OBJDUMP": return Language.CppObjDump;
                case "CSHARP": return Language.CSharp;
                case "C#": return Language.CSharp;
                case "CSS": return Language.Css;                    
                case "CUCUMBER": return Language.Cucumber;                    
                case "CYTHON": return Language.Cython;                    
                case "D": return Language.D;
                case "DARCSPATCH": return Language.DarcsPatch;                    
                case "DART": return Language.Dart;                    
                case "DCPU16ASM": return Language.Dcpu16Asm;                    
                case "DOBJDUMP": return Language.DObjDump;                    
                case "DOT": return Language.Dot;                    
                case "DYLAN": return Language.Dylan;                    
                case "EC": return Language.Ec;                    
                case "ECEREPROJECTS": return Language.EcereProjects;                    
                case "ECL": return Language.Ecl;                    
                case "EDN": return Language.Edn;                    
                case "EIFFEL": return Language.Eiffel;                   
                case "ELIXIR": return Language.Elixir;                    
                case "ELM": return Language.Elm;                    
                case "EMACSLISP": return Language.EmacsLisp;                   
                case "ERLANG": return Language.Erlang;                   
                case "FACTOR": return Language.Factor;                    
                case "FANCY": return Language.Fancy;                    
                case "FANTOM": return Language.Fantom;                    
                case "FISH": return Language.Fish;                   
                case "FORTH": return Language.Forth;                    
                case "FORTRAN": return Language.Fortran;                   
                case "FSHARP": return Language.FSharp;                    
                case "F#": return Language.FSharp;                    
                case "GAS": return Language.Gas;                    
                case "GENSHI": return Language.Genshi;                    
                case "GENTOOBUILD": return Language.GentooBuild;                    
                case "GENTOOECLASS": return Language.GentooEclass;                    
                case "GETTEXTCATALOG": return Language.GettextCatalog;                    
                case "GLSL": return Language.Glsl;                    
                case "GO": return Language.Go;                    
                case "GOSU": return Language.Gosu;                    
                case "GROFF": return Language.Groff;                    
                case "GROOVY": return Language.Groovy;                    
                case "GROOVYSERVERPAGES": return Language.GroovyServerPages;                    
                case "HAML": return Language.Haml;                    
                case "HANDLEBARS": return Language.HandleBars;                    
                case "HASKELL": return Language.Haskell;                    
                case "HAXE": return Language.Haxe;                    
                case "HTTP": return Language.Http;                    
                case "INI": return Language.Ini;                    
                case "IO": return Language.Io;                    
                case "IOKE": return Language.Ioke;                    
                case "IRCLOG": return Language.IrcLog;                    
                case "J": return Language.J;                    
                case "JAVA": return Language.Java;                    
                case "JAVASCRIPT": return Language.JavaScript;                    
                case "JS": return Language.JavaScript;                   
                case "JAVASERVERPAGES": return Language.JavaServerPages;                    
                case "JSON": return Language.Json;                    
                case "JULIA": return Language.Julia;                    
                case "JUPYTERNOTEBOOK": return Language.JupyterNotebook;                   
                case "KOTLIN": return Language.Kotlin;                    
                case "LASSO": return Language.Lasso;                   
                case "LESS": return Language.Less;                    
                case "LFE": return Language.Lfe;                    
                case "LILLYPOND": return Language.LillyPond;                    
                case "LITERATECOFFEESCRIPT": return Language.LiterateCoffeeScript;                    
                case "LITERATEHASKELL": return Language.LiterateHaskell;                    
                case "LIVESCRIPT": return Language.LiveScript;                    
                case "LLVM": return Language.Llvm;                   
                case "LOGOS": return Language.Logos;                    
                case "LOGTALK": return Language.Logtalk;                    
                case "LUA": return Language.Lua;                    
                case "M": return Language.M;                    
                case "MAKEFILE": return Language.Makefile;                    
                case "MAKO": return Language.Mako;                    
                case "MARKDOWN": return Language.Markdown;                   
                case "MD": return Language.Markdown;                    
                case "MATLAB": return Language.Matlab;                    
                case "MAX": return Language.Max;                    
                case "MINID": return Language.MiniD;                    
                case "MIRAH": return Language.Mirah;                    
                case "MONKEY": return Language.Monkey;                    
                case "MOOCODE": return Language.Moocode;                   
                case "MOONSCRIPT": return Language.Moonscript;                    
                case "MUPAD": return Language.Mupad;                    
                case "MYGHTY": return Language.Myghty;                    
                case "NEMERLE": return Language.Nemerle;                    
                case "NGINX": return Language.Nginx;                   
                case "NIMROD": return Language.Nimrod;                    
                case "NSIS": return Language.Nsis;                    
                case "NU": return Language.Nu;                    
                case "NUMPY": return Language.NumPY;                    
                case "OBJDUMP": return Language.ObjDump;                    
                case "OBJECTIVEC": return Language.ObjectiveC;                    
                case "OBJECTIVEJ": return Language.ObjectiveJ;                   
                case "OCAML": return Language.OCaml;                    
                case "OMGROLF": return Language.Omgrofl;                    
                case "OOC": return Language.Ooc;                    
                case "OPA": return Language.Opa;                     
                case "OPENCL": return Language.OpenCL;                     
                case "OPENEDGEABL": return Language.OpenEdgeAbl;                     
                case "PARROT": return Language.Parrot;                     
                case "PARROTASSEMBLY": return Language.ParrotAssembly;          
                case "PARROTINTERNALREPRESENTATION": return Language.ParrotInternalRepresentation;                    
                case "PASCAL": return Language.Pascal;                     
                case "PERL": return Language.Perl;                     
                case "PHP": return Language.Php;                     
                case "PIKE": return Language.Pike;                     
                case "POGOSCRIPT": return Language.PogoScript;                     
                case "POWERSHELL": return Language.PowerShell;                     
                case "PROCESSING": return Language.Processing;                     
                case "PROLOG": return Language.Prolog;                     
                case "PUPPET": return Language.Puppet;                     
                case "PUREDATA": return Language.PureData;                     
                case "PYTHON": return Language.Python;                    
                case "PYTHONTRACEBACK": return Language.PythonTraceback;                     
                case "R": return Language.R;   
                case "RACKET": return Language.Racket;                     
                case "RAGELINRUBYHOST": return Language.RagelInRubyHost;                     
                case "RAWTOKENDATA": return Language.RawTokenData;                    
                case "REBOL": return Language.Rebol;                     
                case "REDCODE": return Language.Redcode;                    
                case "RESTRUCTUREDTEXT": return Language.ReStructuredText;                     
                case "RHTML": return Language.Rhtml;                     
                case "ROUGE": return Language.Rouge;                     
                case "RUBY": return Language.Ruby;                     
                case "RUST": return Language.Rust;                     
                case "SAGE": return Language.Sage;                     
                case "SASS": return Language.Sass;                     
                case "SCALA": return Language.Scala;                     
                case "SCHEME": return Language.Scheme;                     
                case "SCILAB": return Language.Scilab;                    
                case "SCSS": return Language.Scss;                     
                case "SELF": return Language.Self;                    
                case "SHELL": return Language.Shell;                    
                case "SLASH": return Language.Slash;                     
                case "SMALLTALK": return Language.Smalltalk;                     
                case "SMARTY": return Language.Smarty;                     
                case "SQUIRREL": return Language.Squirrel;                     
                case "STANDARDML": return Language.StandardML;                    
                case "SUPERCOLLIDER": return Language.SuperCollider;                    
                case "TCL": return Language.Tcl;                     
                case "TCSH": return Language.Tcsh;                    
                case "TEA": return Language.Tea;                    
                case "TEX": return Language.TeX;                    
                case "TEXTILE": return Language.Textile;                     
                case "TOML": return Language.Toml;                     
                case "TURING": return Language.Turing;                     
                case "TWIG": return Language.Twig;                     
                case "TXL": return Language.Txl;                     
                case "TYPESCRIPT": return Language.TypeScript;                     
                case "UNIFIEDPARALLELC": return Language.UnifiedParallelC;                     
                case "UNKNOWN": return Language.Unknown;                       
                case "VALA": return Language.Vala;                    
                case "VERILOG": return Language.Verilog;                    
                case "VHDL": return Language.Vhdl;                    
                case "VIML": return Language.VimL;                   
                case "VISUALBASIC": return Language.VisualBasic;                    
                case "VOLT": return Language.Volt;                    
                case "WISP": return Language.Wisp;                     
                case "XC": return Language.Xc;                    
                case "XML": return Language.Xml;                    
                case "XPROC": return Language.XProc;                     
                case "XQUERY": return Language.XQuery;                     
                case "XS": return Language.Xs;                     
                case "XSLT": return Language.Xslt;                     
                case "XTEND": return Language.Xtend;                     
                case "YAML": return Language.Yaml;                   
            }

            return Language.Unknown;
        }

        public AccountSearchType ACCOUNTSEARCH(string USERTYPE) {

            switch(USERTYPE) {

                case "ORG": return AccountSearchType.Org;
                case "USER": return AccountSearchType.User;
            }

            return AccountSearchType.User;
        }

        public SearchUsersRequest USERSREQUEST(Octokit.Range FOLLOWERS, Octokit.Range REPOSITORIES, DateRange CREATIONDATE, string LOCATION, string USERNAME, string EMAIL, string FULLNAME, Language LANGUAGE, AccountSearchType USERTYPE) {

            if(LOCATION != "NONE") {

                if(EMAIL != "NONE") {

                    if(FULLNAME != "NONE") {

                        return new SearchUsersRequest(USERNAME) {

                            Followers = FOLLOWERS,
                            Created = CREATIONDATE,
                            Location = LOCATION,
                            Repositories = REPOSITORIES,
                            AccountType = USERTYPE,
                            Language = LANGUAGE,

                            In = new[] { UserInQualifier.Username, UserInQualifier.Email, UserInQualifier.Fullname },
                        };

                    } else {

                        return new SearchUsersRequest(USERNAME) {

                            Followers = FOLLOWERS,
                            Created = CREATIONDATE,
                            Location = LOCATION,
                            Repositories = REPOSITORIES,
                            AccountType = USERTYPE,
                            Language = LANGUAGE,

                            In = new[] { UserInQualifier.Username, UserInQualifier.Email },
                        };
                    }

                } else {

                    if(FULLNAME != "NONE") {

                        return new SearchUsersRequest(USERNAME) {

                            Followers = FOLLOWERS,
                            Created = CREATIONDATE,
                            Location = LOCATION,
                            Repositories = REPOSITORIES,
                            AccountType = USERTYPE,
                            Language = LANGUAGE,

                            In = new[] { UserInQualifier.Username, UserInQualifier.Fullname },
                        };

                    } else {

                        return new SearchUsersRequest(USERNAME) {

                            Followers = FOLLOWERS,
                            Created = CREATIONDATE,
                            Location = LOCATION,
                            Repositories = REPOSITORIES,
                            AccountType = USERTYPE,
                            Language = LANGUAGE,

                            In = new[] { UserInQualifier.Username },
                        };
                    }   
                }

            } else {

                if(EMAIL != "NONE") {

                    if(FULLNAME != "NONE") {

                        return new SearchUsersRequest(USERNAME) {

                            Followers = FOLLOWERS,
                            Created = CREATIONDATE,
                            Repositories = REPOSITORIES,
                            AccountType = USERTYPE,
                            Language = LANGUAGE,

                            In = new[] { UserInQualifier.Username, UserInQualifier.Email, UserInQualifier.Fullname },
                        };

                    } else {

                        return new SearchUsersRequest(USERNAME) {

                            Followers = FOLLOWERS,
                            Created = CREATIONDATE,
                            Repositories = REPOSITORIES,
                            AccountType = USERTYPE,
                            Language = LANGUAGE,

                            In = new[] { UserInQualifier.Username, UserInQualifier.Email },
                        };
                    }

                } else {

                    if(FULLNAME != "NONE") {

                        return new SearchUsersRequest(USERNAME) {

                            Followers = FOLLOWERS,
                            Created = CREATIONDATE,
                            Repositories = REPOSITORIES,
                            AccountType = USERTYPE,
                            Language = LANGUAGE,

                            In = new[] { UserInQualifier.Username, UserInQualifier.Fullname },
                        };

                    } else {

                        return new SearchUsersRequest(USERNAME) {

                            Followers = FOLLOWERS,
                            Created = CREATIONDATE,
                            Repositories = REPOSITORIES,
                            AccountType = USERTYPE,
                            Language = LANGUAGE,

                            In = new[] { UserInQualifier.Username },
                        };
                    }   
                }
            }
        }

        public ForkQualifier FORKQUALIFIER(string ENUMERABLE) {

            switch(ENUMERABLE) {

                case "TRUE": return ForkQualifier.OnlyForks;
                case "FALSE": return ForkQualifier.IncludeForks;
            }

            return ForkQualifier.IncludeForks;
        }

        public DateRange DATEBETWEEN(string STRING) {

            DateTimeOffset DEFAULT = new DateTimeOffset(new DateTime(1999, 4, 1));
            DateRange DATERANGE = DateRange.Between(DEFAULT, DateTime.Now);

            string[] UPDATEARRAY = STRING.Split(' ');

            string[] FIRSTDATE = UPDATEARRAY[0].Split('/');
            string[] AFTERDATE = UPDATEARRAY[1].Split('/');

            int FIRSTMONTH = int.Parse(FIRSTDATE[0]);
            int FIRSTDAYS = int.Parse(FIRSTDATE[1]);
            int FIRSTYEAR = int.Parse(FIRSTDATE[2]);

            int AFTERMONTH = int.Parse(AFTERDATE[0]);
            int AFTERDAYS = int.Parse(AFTERDATE[1]);
            int AFTERYEAR = int.Parse(AFTERDATE[2]);

            if(FIRSTMONTH > 12 || FIRSTMONTH < 1) return DATERANGE;
            if(FIRSTDAYS > 31 || FIRSTDAYS < 1) return DATERANGE;
            if(FIRSTYEAR > DateTime.Now.Year || FIRSTYEAR < 1999) return DATERANGE;

            if(AFTERMONTH > 12 || AFTERMONTH < 1) return DATERANGE;
            if(AFTERDAYS > 31 || AFTERDAYS < 1) return DATERANGE;
            if(AFTERYEAR > DateTime.Now.Year || AFTERYEAR < 1999) return DATERANGE;

            DateTimeOffset FIRSTOFFSET = new DateTimeOffset(new DateTime(FIRSTYEAR, FIRSTMONTH, FIRSTDAYS));
            DateTimeOffset AFTEROFFSET = new DateTimeOffset(new DateTime(AFTERYEAR, AFTERMONTH, AFTERDAYS));

            return DateRange.Between(FIRSTOFFSET, AFTEROFFSET);
        }

        public SearchRepositoriesRequest REPOSITORIESREQUEST(Octokit.Range STARS, Octokit.Range SIZE, Octokit.Range FORKS, ForkQualifier INCLUDEFORKS, Language LANGUAGE, DateTime DATECHECKER, DateRange CREATIONDATE, DateRange UPDATEDATE, string NAME, string OWNER, bool README, bool DESC) {

            if(README != false) {

                if(DESC != false) {

                    if(OWNER != "NONE") {
                        
                        return new SearchRepositoriesRequest(NAME) {

                            Stars = STARS,
                            Size = SIZE,
                            Forks = FORKS,
                            Fork = INCLUDEFORKS,
                            Language = LANGUAGE,

                            In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },

                            Created = CREATIONDATE,
                            Updated = UPDATEDATE,

                            User = OWNER,
                        };

                    } else {

                        return new SearchRepositoriesRequest(NAME) {

                            Stars = STARS,
                            Size = SIZE,
                            Forks = FORKS,
                            Fork = INCLUDEFORKS,
                            Language = LANGUAGE,

                            In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },

                            Created = CREATIONDATE,
                            Updated = UPDATEDATE,
                        };
                    }

                } else {

                    if(OWNER != "NONE") {
                        
                        return new SearchRepositoriesRequest(NAME) {

                            Stars = STARS,
                            Size = SIZE,
                            Forks = FORKS,
                            Fork = INCLUDEFORKS,
                            Language = LANGUAGE,

                            In = new[] { InQualifier.Readme, InQualifier.Name },

                            Created = CREATIONDATE,
                            Updated = UPDATEDATE,

                            User = OWNER,
                        };

                    } else {

                        return new SearchRepositoriesRequest(NAME) {

                            Stars = STARS,
                            Size = SIZE,
                            Forks = FORKS,
                            Fork = INCLUDEFORKS,
                            Language = LANGUAGE,

                            In = new[] { InQualifier.Readme, InQualifier.Name },

                            Created = CREATIONDATE,
                            Updated = UPDATEDATE,
                        };
                    }
                }

            } else {

                if(DESC != false) {

                    if(OWNER != "NONE") {
                        
                        return new SearchRepositoriesRequest(NAME) {

                            Stars = STARS,
                            Size = SIZE,
                            Forks = FORKS,
                            Fork = INCLUDEFORKS,
                            Language = LANGUAGE,

                            In = new[] { InQualifier.Description, InQualifier.Name },

                            Created = CREATIONDATE,
                            Updated = UPDATEDATE,

                            User = OWNER,
                        };

                    } else {

                        return new SearchRepositoriesRequest(NAME) {

                            Stars = STARS,
                            Size = SIZE,
                            Forks = FORKS,
                            Fork = INCLUDEFORKS,
                            Language = LANGUAGE,

                            In = new[] { InQualifier.Description, InQualifier.Name },

                            Created = CREATIONDATE,
                            Updated = UPDATEDATE,
                        };
                    }

                } else {

                    if(OWNER != "NONE") {
                        
                        return new SearchRepositoriesRequest(NAME) {

                            Stars = STARS,
                            Size = SIZE,
                            Forks = FORKS,
                            Fork = INCLUDEFORKS,
                            Language = LANGUAGE,

                            In = new[] { InQualifier.Name },

                            Created = CREATIONDATE,
                            Updated = UPDATEDATE,

                            User = OWNER,
                        };

                    } else {

                        return new SearchRepositoriesRequest(NAME) {

                            Stars = STARS,
                            Size = SIZE,
                            Forks = FORKS,
                            Fork = INCLUDEFORKS,
                            Language = LANGUAGE,

                            In = new[] { InQualifier.Name },

                            Created = CREATIONDATE,
                            Updated = UPDATEDATE,
                        };
                    }
                }
            }
        }

        public SearchCodeRequest CODEREQUEST(string FILENAME, string PATH, Language LANGUAGE, bool FORKS, Octokit.Range SIZE, string USER, string AUTHOR, string NAME) {

            if(FILENAME != "NONE") {

                if(PATH != "NONE") {

                    return new SearchCodeRequest("auth", AUTHOR, NAME) {

                        In = new[] { CodeInQualifier.File, CodeInQualifier.Path },
                            
                        Language = LANGUAGE,
                        Forks = FORKS,
                        Size = SIZE,
                        Path = PATH,
                        FileName = FILENAME,
                        User = USER,
                    };

                } else {

                    return new SearchCodeRequest("auth", AUTHOR, NAME) {

                        In = new[] { CodeInQualifier.File },
                            
                        Language = LANGUAGE,
                        Forks = FORKS,
                        Size = SIZE,
                        FileName = FILENAME,
                        User = USER,
                    };
                }

            } else {

                if(PATH != "NONE") {

                    return new SearchCodeRequest("auth", AUTHOR, NAME) {

                        In = new[] { CodeInQualifier.File, CodeInQualifier.Path },
                            
                        Language = LANGUAGE,
                        Forks = FORKS,
                        Size = SIZE,
                        Path = PATH,
                        User = USER,
                    };

                } else {

                    return new SearchCodeRequest("auth", AUTHOR, NAME) {

                        In = new[] { CodeInQualifier.File },
                            
                        Language = LANGUAGE,
                        Forks = FORKS,
                        Size = SIZE,
                        User = USER,
                    };
                }
            }
        }
    }
}