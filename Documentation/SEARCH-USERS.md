## Filters

Special symbol-separator for all filters (need to be typed before first filter and after last): **⇒**.

| Filter name | Parameter | Information | Usage |
| :----------: | :-------: | :----------: | :----: |
| Follower Count | ``FOLLOWERS: </> integer`` | This type of filter is checking number of user's followers. | ``FOLLOWERS: << 32``
| Creation Date | ``CREATIONDATE: </> datetime`` | This type of filter is checking creation date of user's account. | ``CREATIONDATE: >> 6/19/2015`` |
| Location | ``LOCATION: string`` | This type of filter is checking user's location. | ``LOCATION: Mars`` |
| Repositories Count | ``REPOSITORIES: </> integer`` | This type of filter is checking user's repositories count. | ``REPOSITORIES: >= 1000``
| Language (Programming) | ``LANGUAGE: string`` | This type of filter checking user's repositories and find one with specified language (user just need one repository with specified language to shown up). | ``LANGUAGE: JAVASCRIPT``
| Username | ``USERNAME: string`` | This type of filter checking user's nickname (username). | ``USERNAME: Falcion`` |
| Email | ``EMAIL: string`` | This type of filter checking user's email (public). | ``EMAIL: example@gmail.com`` |
| Fullname | ``FULLNAME: string`` | This type of filter checking user's fullname. | ``FULLNAME: Falcion`` |
| Account Type | ``USERTYPE: string`` | This type of filter checking account's type. | ``USERTYPE: ORG`` |

### Account Dictionary:

| Account Type | Code |
| :-------: | :--: |
| Organization | ``ORG`` |
| User | ``USER`` |

### Equals Dictionary:

| Parameter | Code |
| :-------: | :--: |
| Less | ``<<`` |
| Greater | ``>>`` |
| Less or Equals | ``<=`` |
| Greater or Equals | ``>=`` |

### Languages Dictionary:

Press **Ctrl+F** and find your language! But, not all languages are supported at the moment because of [Octokit.net](https://octokitnet.readthedocs.io/en/latest/).

| Language (GitHub) | Filter's ID |
| :---------------: | :---------: |
| Abap | ``ABAP``|
| ActionScript | ``ACTIONSCRIPT``|
| Ada | ``ada`` |
| ApacheConf | ``APACHECONF`` |
| Apex | ``APEX`` |
| AppleScript | ``APPLESCRIPT`` |
| Arc | ``ARC`` |
| Arduino | ``ARDUINO`` |
| Asp | ``ASP`` |
| Assembly | ``ASSEMBLY`` |
| Augeas | ``AUGEAS`` |
| AutoHotKey | ``AUTOHOTKEY`` |
| Awk | ``AWK`` |
| Batchfile | ``BATCHFILE`` |
| Befunge | ``BEFUNGE`` |
| BlitzMax | ``BLITZMAX`` |
| Boo | ``BOO`` |
| Bro | ``BRO`` |
| C | ``C`` |
| C2hsHaskell | ``C2HSHASKELL`` |
| Ceylon | ``CEYLON`` |
| Chuck | ``CHUCK`` |
| Clips | ``CLIPS`` |
| Clojure | ``CLOJURE`` |
| Cmake | ``CMAKE`` |
| CObjDump | ``COBJDUMP`` |
| Cobol | ``COBOL`` |
| CoffeeScript | ``COFFEESCRIPT`` |
| ColdFusion | ``COLDFUSION`` |
| CommonLisp | ``COMMONLISP`` |
| Coq | ``COQ`` |
| C++ | ``CPLUSPLUS`` or ``C++`` |
| CppObjDump | ``CPPOBJDUMP`` or ``C++OBJDUMP`` |
| C# | ``CSHARP`` or ``C#``|
| Css | ``CSS`` |
| Cucumber | ``CUCUMBER`` |
| Cython | ``CYTHON`` |
| D | ``D`` |
| DarcsPatch | ``DARCSPATCH`` |
| Dart | ``DART`` |
| Dcpu16Asm | ``DCPU16ASM`` |
| DObjDump | ``DOBJDUMP`` |
| Dot | ``DOT`` |
| Dylan | ``DYLAN`` |
| Ec | ``EC`` |
| EcereProjects | ``ECEREPROJECTS`` |
| Ecl | ``ECL`` |
| Edn | ``EDN`` |
| Eiffel | ``EIFFEL`` |
| Elixir | ``ELIXIR`` |
| Elm | ``ELM`` |
| EmacsLisp | ``EMACSLISP`` |
| Erlang | ``ERLANG`` |
| Factor | ``FACTOR`` |
| Fancy | ``FANCY`` |
| Fantom | ``FANTOM`` |
| Fish | ``FISH`` |
| Forth | ``FORTH`` |
| Fortran | ``FORTRAN`` |
| F# | ``FSHARP`` or ``F#``|
| Gas | ``GAS`` |
| Genshi | ``GENSHI`` |
| GentooBuild | ``GENTOOBUILD`` |
| GentooEclass | ``GENTOOECLASS`` |
| GettextCatalog | ``GETTEXTCATALOG`` |
| Glsl | ``GLSL`` |
| Go | ``GO`` |
| Gosu | ``GROFF`` |
| Groff | ``groff`` |
| Groovy | ``GROOVY`` |
| GroovyServerPages | ``GROOVYSERVERPAGES`` |
| Haml | ``HAML`` |
| HandleBars | ``HANDLEBARS`` |
| Haskell | ``HASKELL`` |
| Haxe | ``HAXE`` |
| Http | ``HTTP`` |
| Ini | ``INI`` |
| Io | ``IO`` |
| Ioke | ``IOKE`` |
| IrcLog | ``IRCLOG`` |
| J | ``J`` |
| Java | ``JAVA`` |
| JavaScript | ``JAVASCRIPT`` or ``JS`` |
| JavaServerPages | ``JAVASERVERPAGES`` |
| Json | ``JSON`` |
| Julia | ``JULIA`` |
| JupyterNotebook | ``JUPYTERNOTEBOOK`` |
| Kotlin | ``KOTLIN`` |
| Lasso | ``LASSO`` |
| Less | ``LESS`` |
| Lfe | ``LFE`` |
| LillyPond | ``LILLYPOND`` |
| LiterateCoffeeScript | ``LITERATECOFFEESCRIPT`` |
| LiterateHaskell | ``LITERATEHASKELL`` |
| LiveScript | ``LIVESCRIPT`` |
| Llvm | ``LLVM`` |
| Logos | ``LOGOS`` |
| Logtalk | ``LOGTALK`` |
| Lua | ``LUA`` |
| M | ``M`` |
| Mako | ``MAKO`` |
| Markdown | ``MARKDOWN`` |
| Matlab | ``MATLAB`` |
| Max | ``MAX`` |
| MiniD | ``MINID`` |
| Mirah | ``MIRAH`` |
| Monkey | ``MONKEY`` |
| Moocode | ``MOOCODE`` |
| Moonscript | ``MOONSCRIPT`` |
| Mupad | ``MUPAD`` |
| Myghty | ``MYGHTY`` |
| Nemerle | ``NEMERLE`` |
| Nginx | ``NGINX`` |
| Nimrod | ``NIMROD`` |
| Nsis | ``NSIS`` |
| Nu | ``NU`` |
| NumPY | ``NUMPY`` |
| ObjDump | ``OBJDUMP`` |
| ObjectiveC | ``OBJECTIVEC`` |
| ObjectiveJ | ``OBJECTIVEJ`` |
| OCaml | ``OCAML`` |
| Omgrofl | ``OMGROLF`` |
| Ooc | ``OOC`` |
| Opa | ``OPA`` |
| OpenCL | ``OPENCL`` |
| OpenEdgeAbl | ``OPENEDGEABL`` |
| Parrot | ``PARROT`` |
| ParrotAssembly | ``PARROTASSEMBLY`` |
| ParrotInternalRepresentation | ``PARROTINTERNALREPRESENTATION`` |
| Pascal | ``PASCAL`` |
| Perl | ``PERL`` |
| Php | ``PHP`` |
| Pike | ``PIKE`` |
| PogoScript | ``POGOSCRIPT`` |
| PowerShell | ``POWERSHELL`` |
| Processing | ``PROCESSING`` |
| Prolog | ``PROLOG`` |
| Puppet | ``PUPPET`` |
| PureData | ``PUREDATA`` |
| Python | ``PYTHON`` |
| PythonTraceback | ``PYTHONTRACEBACK`` |
| R | ``R`` |
| Racket | ``RACKET`` |
| RagelInRubyHost | ``RAGELINRUBYHOST`` |
| RawTokenData | ``RAWTOKENDATA`` |
| Rebol | ``REBOL`` |
| Redcode | ``REDCODE`` |
| ReStructuredText | ``RESTRUCTUREDTEXT`` |
| Rhtml | ``RHTML`` |
| Rouge | ``ROUGE`` |
| Ruby | ``RUBY`` |
| Rust | ``RUST`` |
| Sage | ``SAGE`` |
| Sass | ``SASS`` |
| Scala | ``SCALA`` |
| Scheme | ``SCHEME`` |
| Scilab | ``SCILAB`` |
| Scss | ``SCSS`` |
| Self | ``SELF`` |
| Shell | ``SHELF`` |
| Slash | ``SLASH`` |
| Smalltalk | ``SMALLTALK`` |
| Smarty | ``SMARTY`` |
| Squirrel | ``SQUIRREL`` |
| StandardML | ``STANDARDML`` |
| SuperCollider | ``SUPERCOLLIDER`` |
| Tcl | ``TCL`` |
| Tcsh | ``TCSH`` |
| Tea | ``TEA`` |
| TeX | ``TEX`` |
| Textile | ``TEXTILE`` |
| Toml | ``TOML`` |
| Turing | ``TURING`` |
| Twig | ``TWIG`` |
| Txl | ``TXL`` |
| TypeScript | ``TYPESCRIPT`` |
| UnifiedParallelC | ``UNIFIEDPARALLELC`` |
| Unknown | ``UNKNOWN`` |
| Vala | ``VALA`` |
| Verilog | ``VERILOG`` |
| Vhdl | ``VHDL`` |
| Viml | ``VIML`` |
| VisualBasic | ``VISUALBASIC`` |
| Volt | ``VOLT`` |
| Wisp | ``WISP`` |
| Xc | ``XC`` |
| Xml | ``XML`` |
| XProc | ``XPROC`` |
| XQuery | ``XQUERY`` |
| Xs | ``XS`` |
| Xslt | ``XSLT`` |
| Xtend | ``XTEND`` |
| Yaml | ``YAML`` |
