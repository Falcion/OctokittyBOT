## Command Syntax

``search-users`` - is a command that joins in special "Searching commands" group. Commands of this group has some unique syntax for using them. Below you can see all of information, filters list and etc.

| Filter name | Parameter | Information | Usage |
| :----------: | :-------: | :----------: | :----: |
| Follower Count | ``followers: </> integer`` | This type of filter is checking number of user's followers. | ``followers: < 32``
| Creation Date | ``creation-date: </> datetime`` | This type of filter is checking date of user. | ``creation-date: > 2015:1:1`` |
| Location | ``location: string`` | This type of filter is checking user's location. | ``location: Mars`` |
| Repositories Count | ``repositories: </> integer`` | This type of filter is checking user's repositories coint. | ``repositories: > 1000``
| Language (Programming) | ``language: string`` | This type of filter checking user's repositories and find one with specified language. | ``language: javascript``
| Username | ``username: string`` | This type of filter checking user's nickname (username). | ``username: Falcion`` |
| Email | ``email: string`` | This type of filter checking user's email. | ``email: example@gmail.com`` |
| Fullname | ``fullname: string`` | This type of filter checking user's fullname | ``fullname: Falcion`` |

### Languages Dictionary:

Press **Ctrl+F** and find your language! But, not all languages are supported at the moment because of [Octokit.net](https://octokitnet.readthedocs.io/en/latest/).

** **

| Language (GitHub) | Filter's ID |
| :---------------: | :---------: |
| Abap | ``abap``|
| ActionScript | ``actionscript``|
| Ada | ``ada`` |
| ApacheConf | ``apacheconf`` |
| Apex | ``apex`` |
| AppleScript | ``applescript`` |
| Arc | ``arc`` |
| Arduino | ``arduino`` |
| Asp | ``asp`` |
| Assembly | ``assembly`` |
| Augeas | ``augeas`` |
| AutoHotKey | ``autohotkey`` |
| Awk | ``awk`` |
| Batchfile | ``batchfile`` |
| Befunge | ``befunge`` |
| BlitzMax | ``blitzmax`` |
| Boo | ``boo`` |
| Bro | ``bro`` |
| C | ``c`` |
| C2hsHaskell | ``c2hshaskell`` |
| Ceylon | ``ceylon`` |
| Chuck | ``chuck`` |
| Clips | ``clips`` |
| Clojure | ``clojure`` |
| Cmake | ``cmake`` |
| CObjDump | ``cobjdump`` |
| Cobol | ``cobol`` |
| CoffeeScript | ``coffeescript`` |
| ColdFusion | ``coldfusion`` |
| CommonLisp | ``commonlisp`` |
| Coq | ``coq`` |
| C++ | ``cplusplus`` |
| CppObjDump | ``cppobjdump`` |
| C# | ``csharp`` |
| Css | ``css`` |
| Cucumber | ``cucumber`` |
| Cython | ``cython`` |
| D | ``d`` |
| DarcsPatch | ``darcspatch`` |
| Dart | ``dart`` |
| Dcpu16Asm | ``dcpu16asm`` |
| DObjDump | ``dobjdump`` |
| Dot | ``dot`` |
| Dylan | ``dylan`` |
| Ec | ``ec`` |
| EcereProjects | ``ecereprojects`` |
| Ecl | ``ecl`` |
| Edn | ``edn`` |
| Eiffel | ``eiffel`` |
| Elixir | ``elixir`` |
| Elm | ``elm`` |
| EmacsLisp | ``emacslisp`` |
| Erlang | ``erlang`` |
| Factor | ``factor`` |
| Fancy | ``fancy`` |
| Fantom | ``fantom`` |
| Fish | ``fish`` |
| Forth | ``forth`` |
| Fortran | ``fortran`` |
| F# | ``fsharp`` |
| Gas | ``gas`` |
| Genshi | ``genshi`` |
| GentooBuild | ``gentoobuild`` |
| GentooEclass | ``gentooeclass`` |
| GettextCatalog | ``gettextcatalog`` |
| Glsl | ``glsl`` |
| Go | ``go`` |
| Gosu | ``gosu`` |
| Groff | ``groff`` |
| Groovy | ``groovy`` |
| GroovyServerPages | ``groovyserverpages`` |
| Haml | ``haml`` |
| HandleBars | ``handlebars`` |
| Haskell | ``haskell`` |
| Haxe | ``haxe`` |
| Http | ``http`` |
| Ini | ``ini`` |
| Io | ``io`` |
| Ioke | ``ioke`` |
| IrcLog | ``irclog`` |
| J | ``j`` |
| Java | ``java`` |
| JavaScript | ``javascript`` |
| JavaServerPages | ``javaserverpages`` |
| Json | ``json`` |
| Julia | ``julia`` |
| JupyterNotebook | ``jupyternotebook`` |
| Kotlin | ``kotlin`` |
| Lasso | ``lasso`` |
| Less | ``less`` |
| Lfe | ``lfe`` |
| LillyPond | ``lillypond`` |
| LiterateCoffeeScript | ``literatecoffeescript`` |
| LiterateHaskell | ``literatehaskell`` |
| LiveScript | ``livescript`` |
| Llvm | ``llvm`` |
| Logos | ``logos`` |
| Logtalk | ``logtalk`` |
| Lua | ``lua`` |
| M | ``m`` |
| Mako | ``mako`` |
| Markdown | ``markdown`` |
| Matlab | ``matlab`` |
| Max | ``max`` |
| MiniD | ``minid`` |
| Mirah | ``mirah`` |
| Monkey | ``monkey`` |
| Moocode | ``moocode`` |
| Moonscript | ``moonscript`` |
| Mupad | ``mupad`` |
| Myghty | ``myghty`` |
| Nemerle | ``nemerle`` |
| Nginx | ``nginx`` |
| Nimrod | ``nimrod`` |
| Nsis | ``nsis`` |
| Nu | ``nu`` |
| NumPY | ``numpy`` |
| ObjDump | ``objdump`` |
| ObjectiveC | ``objectivec`` |
| ObjectiveJ | ``objectivej`` |
| OCaml | ``ocaml`` |
| Omgrofl | ``omgrofl`` |
| Ooc | ``ooc`` |
| Opa | ``opa`` |
| OpenCL | ``opencl`` |
| OpenEdgeAbl | ``openedgeabl`` |
| Parrot | ``parrot`` |
| ParrotAssembly | ``parrotassembly`` |
| ParrotInternalRepresentation | ``parrotinternalrepresentation`` |
| Pascal | ``pascal`` |
| Perl | ``perl`` |
| Php | ``php`` |
| Pike | ``pike`` |
| PogoScript | ``pogoscript`` |
| PowerShell | ``powershell`` |
| Processing | ``processing`` |
| Prolog | ``prolog`` |
| Puppet | ``puppet`` |
| PureData | ``puredata`` |
| Python | ``python`` |
| PythonTraceback | ``pythontraceback`` |
| R | ``r`` |
| Racket | ``racket`` |
| RagelInRubyHost | ``ragelinrubyhost`` |
| RawTokenData | ``rawtokendata`` |
| Rebol | ``rebol`` |
| Redcode | ``redcode`` |
| ReStructuredText | ``restructuredtext`` |
| Rhtml | ``rhtml`` |
| Rouge | ``rouge`` |
| Ruby | ``ruby`` |
| Rust | ``rust`` |
| Sage | ``sage`` |
| Sass | ``sass`` |
| Scala | ``scala`` |
| Scheme | ``scheme`` |
| Scilab | ``scilab`` |
| Scss | ``scss`` |
| Self | ``self`` |
| Shell | ``shell`` |
| Slash | ``slash`` |
| Smalltalk | ``smalltalk`` |
| Smarty | ``smarty`` |
| Squirrel | ``squirrel`` |
| StandardML | ``standardml`` |
| SuperCollider | ``supercollider`` |
| Tcl | ``tcl`` |
| Tcsh | ``tcsh`` |
| Tea | ``tea`` |
| TeX | ``tex`` |
| Textile | ``textile`` |
| Toml | ``toml`` |
| Turing | ``turing`` |
| Twig | ``twig`` |
| Txl | ``txl`` |
| TypeScript | ``typescript`` |
| UnifiedParallelC | ``unifiedparallelc`` |
| Unknown | ``unknown`` |
| Vala | ``vala`` |
| Verilog | ``verilog`` |
| Vhdl | ``vhdl`` |
| Viml | ``viml`` |
| VisualBasic | ``visualbasic`` |
| Volt | ``volt`` |
| Wisp | ``wisp`` |
| Xc | ``xc`` |
| Xml | ``xml`` |
| XProc | ``xproc`` |
| XQuery | ``xquery`` |
| Xs | ``xs`` |
| Xslt | ``xslt`` |
| Xtend | ``xtend`` |
| Yaml | ``yaml`` |

** **