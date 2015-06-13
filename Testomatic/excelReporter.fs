module testomatic.excelReporter
open canopy.reporters
open testomatic.teeReporter
open System
open System.Collections.Generic
open TestomaticSupport

type ExcelReporter (templateFile : string, outputFile : string) =
    let mutable currentContextItem : ExcelReportItem = null
    let mutable currentTestItem : ExcelReportItem = null
    let reportItems = new List<ExcelReportItem>()
    let reportInfo = new ExcelReportInfo()

    member this.Info (appName : string) (version : string) (executionTime : DateTime) (browser : string) (param : string list ) =
        reportInfo.TestApplicationName <- appName
        reportInfo.Version <- version
        reportInfo.ExecutionTime <- System.Nullable executionTime
        reportInfo.Browser <- browser
        reportInfo.Parameters.AddRange param

    interface IReporter with
        member this.contextStart c =
            currentContextItem <- new ExcelReportItem "Context"
            reportItems.Add currentContextItem
            currentContextItem.Name <- c
            currentContextItem.BeginTime <- System.Nullable DateTime.Now
        member this.contextEnd c =
            currentContextItem.EndTime <- System.Nullable DateTime.Now

        member this.testStart id =
            currentTestItem <- new ExcelReportItem "Test"
            reportItems.Add currentTestItem
            currentTestItem.Name <- id
            currentTestItem.BeginTime <- System.Nullable DateTime.Now
        member this.pass () =
            currentTestItem.Pass <- System.Nullable true
        member this.fail ex id ss =
            currentTestItem.Pass <- System.Nullable false
        member this.testEnd id = 
            currentTestItem.EndTime <- System.Nullable DateTime.Now

        member this.suiteBegin () = ()
        member this.suiteEnd () = 
            use erf = new ExcelReportFormatter()
            erf.Init templateFile
            erf.FormatReport (reportInfo, reportItems)
            erf.Save outputFile

        member this.summary minutes seconds passed failed =
            reportInfo.DurationMinutes <- minutes
            reportInfo.DurationSeconds <- seconds
            reportInfo.PassCount <- passed
            reportInfo.FailCount <- failed

        member this.describe d = ()
        member this.write w = ()
        member this.suggestSelectors selector suggestions = ()
        member this.quit () = ()
        member this.coverage url ss = ()
        member this.todo () = ()
        member this.skip () = ()

    interface IReporterEx with
        member this.objective s =
            currentTestItem.Objective <- s
        member this.precondition s =
            currentTestItem.Precondition <- s
        member this.postcondition s =
            currentTestItem.Postcondition <- s


