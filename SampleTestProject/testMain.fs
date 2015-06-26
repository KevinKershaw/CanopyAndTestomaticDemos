module testMain
open canopy
open canopy.runner
open System
open commandLineArgs
open configureReporters

let appName = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "")

let setupTests (cla : CommandLineArgs) =
    BasicExampleTests.all ()
    FindersTests.all ()
    if cla.noSlow = false then
        StabilizationTests.all ()
    AlertsTests.all ()
    SecondaryWindowTests.all ()
    FileUploadTests.all ()
    ExampleTestFixture.all ()
    OtherTests.all ()

[<EntryPoint>]
let main argv = 
    let cla = parseCommandLine argv
    if cla.versionOnly then
        printfn "%s" versionInfo.versionString
        0
    else if cla.showUsage || not cla.isValid then
        showUsage appName
        -1
    else
        printfn "%s version %s" appName versionInfo.versionString

        setupTests cla

        setupReporters cla appName

        match cla.browser with
            | Firefox -> start firefox
            | Chrome -> start chrome
            | IE -> start ie

        if cla.warmup && cla.noSlow = false then
            warmup.warmupSite ()

        run ()

        if cla.pressEnter then
            printfn "press [enter] to exit"
            System.Console.ReadLine() |> ignore

        quit ()
        0
