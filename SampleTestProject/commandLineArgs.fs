module commandLineArgs

type Browser =
    | Firefox
    | Chrome
    | IE

type CommandLineArgs () = class
    member val isValid : bool = true with get, set
    member val browser : Browser = Firefox with get, set
    member val warmup : bool = true with get, set
    member val logText : bool = true with get, set
    member val logHtml : bool = false with get, set
    member val logExcel : bool = false with get, set
    member val teamCity : bool = false with get, set
    member val pressEnter : bool = false with get, set
    member val versionOnly : bool = false with get, set
    member val showUsage : bool = false with get, set
end

let parseCommandLine (args: string[]) =
    let cla = new CommandLineArgs()
    for item in args do
        match item.ToLower() with
            | "-firefox" -> cla.browser <- Firefox
            | "-chrome" -> cla.browser <- Chrome
            | "-ie" -> cla.browser <- IE
            | "-warmup" -> cla.warmup <- true
            | "-nowarmup" -> cla.warmup <- false
            | "-logtext" -> cla.logText <- true
            | "-nologtext" -> cla.logText <- false
            | "-loghtml" -> cla.logHtml <- true
            | "-logexcel" -> cla.logExcel <- true
            | "-teamcity" -> cla.teamCity <- true
            | "-pressenter" -> cla.pressEnter <- true
            | "-version" -> cla.versionOnly <- true
            | "-help" | "-?" -> cla.showUsage <- true
            | other -> cla.isValid <- false
    cla

let usage = "usage: {appName} [args]\n" +
            "where args is optional and can be a combination of the following:\n" +
            "    -Firefox (use Firefox browser*)\n" +
            "    -Chrome (use Chrome browser)\n" +
            "    -IE (use Internet Explorer browser)\n" +
            "    -Warmup (run warmup to prepare website for testing*)\n" +
            "    -NoWarmup (do NOT run warmup to prepare website for testing)\n" +
            "    -LogText (create log file of results, use logOutputFileTemplate entry in config.yaml to specify file name*)\n" +
            "    -NoLogText (do NOT create log file of results)\n" +
            "    -LogExcel (create excel repport of results, use excelOutputFileTemplate entry in config.yaml to specify file name)\n" +
            "    -LogHtml (create html file of results, use htmlOutputFileTemplate entry in config.yaml to specify file name)\n" +
            "    -TeamCity (create output for Team City, all other reporting output is OFF)\n" +
            "    -PressEnter (require entering return key at end of tests)\n" +
            "    -Help or -? (display this usage text and run no tests)\n" +
            "parameters are not case sensitive\n" +
            "* default\n" +
            "running without specifying any args is equivalent to \"-Firefox -WarmUp -LogText\"\n" +
            "test case parameters are specified in the \"config.yaml\" file\n" +
            "this file can be edited with notepad or any other text editor"

let showUsage (appName : string) =
    printfn "%s" (usage.Replace("{appName}", appName))
