module configureReporters
open canopy
open canopy.reporters
open appConfig
open commandLineArgs
open teeReporter
open logFileReporter
open excelReporter
open System

let setupReporters (cla : CommandLineArgs) (appName : string) =
    if cla.teamCity then
        let teamCityReporter = new TeamCityReporter ()
        canopy.configuration.reporter <- new TeamCityReporter()
    else if cla.logText || cla.logHtml || cla.logExcel then
        let t = new TeeReporter ()
        canopy.configuration.reporter <- t
        if cla.logHtml = false then
            t.Add (new ConsoleReporter ()) // part of LiveHTMLReporter

        let executionTime =  DateTime.Now
        let dtString = executionTime.ToString "yyyy-MM-dd-HHmm"
        let browser = match cla.browser with
                      | Firefox -> "Firefox"
                      | Chrome -> "Chrome"
                      | IE -> "IE"

        if cla.logText then
            let logFileName = config.logOutputFileTemplate.Replace("{dt}", dtString)
            let logReporter = new LogFileReporter (logFileName) :> IReporter
            t.Add logReporter
            logReporter.describe (sprintf "%s version %s" appName versionInfo.versionString)
            logReporter.describe (sprintf "tests executed on %s %s" (executionTime.ToShortDateString()) (executionTime.ToShortTimeString()))
            logReporter.describe (sprintf "browser: %s" browser)
            logReporter.describe "parameters:"
            logReporter.write ("baseyUrl: " + baseUrl)

        if cla.logExcel then
            let excelOutputFileName = config.excelOutputFileTemplate.Replace("{dt}", dtString)
            let excelReporter = new ExcelReporter (config.excelTemplate, excelOutputFileName)
            t.Add excelReporter
            excelReporter.Info appName versionInfo.versionString executionTime browser ["baseUrl"; baseUrl]

        if cla.logHtml then
            let htmlFileName = config.htmlOutputFileTemplate.Replace(".html", "").Replace("{dt}", dtString)
            let liveHtmlReporter = new LiveHtmlReporter ()
            liveHtmlReporter.reportPath <- Some(htmlFileName)
            t.Add liveHtmlReporter
        