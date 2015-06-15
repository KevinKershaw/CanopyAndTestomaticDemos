[<AutoOpen>]
module testomatic.lib
open System
open canopy
open canopy.configuration
open testomatic.teeReporter

let setFieldValue (f : string) (v : string) =
    f << v

let getFieldValue (f : string) =
    read f

let assertFieldValue (f : string) (v : string) =
    f == v

let assertFieldContains (f : string) (v : string) =
    contains v (read f)

let assertUrl (u : string) =
    on u

let assertDisplayed (f : string) =
    displayed f

let assertNotDisplayed (f : string) =
    notDisplayed f

let assertEqual expected actual =
    is expected actual

let waitForAjax () =
    let fn () =
        sleep 0.01
        let ret = js "return $.active;" |> Convert.ToInt32
        ret = 0
    waitFor fn

let waitForPostback () =
    let fn () = 
        sleep 0.01
        let ret = js "return Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack();" |> Convert.ToBoolean
        ret = false
    waitFor fn

let extendTimeout (fn : unit -> unit) =
    let origCompareTimeout = configuration.compareTimeout
    try
        configuration.compareTimeout <- 60.0 
        fn ()
    finally
        configuration.compareTimeout <- origCompareTimeout

let switchToWindow window =
    browser.SwitchTo().Window(window) |> ignore

let getOtherWindow currentWindow =
    browser.WindowHandles |> Seq.find (fun w -> w <> currentWindow)

let switchToOtherWindow currentWindow =
    switchToWindow (getOtherWindow currentWindow) |> ignore

let closeOtherWindow currentWindow =
    switchToOtherWindow currentWindow
    browser.Close()

let isIE () =
    (browser :? OpenQA.Selenium.IE.InternetExplorerDriver)

let isChrome () =
    (browser :? OpenQA.Selenium.Chrome.ChromeDriver)

let isFirefox () =
    (browser :? OpenQA.Selenium.Firefox.FirefoxDriver)

let rnd = System.Random()

let getRandomNumberString (size : int) =
    // only good for size between 1 and 9
    let max = pown 10 size
    let fmt = new String ('0', size)
    (rnd.Next max).ToString(fmt)

let getRandomString (size : int) = 
    // thank you Mike and Lisa
    let alpha = [| "A"; "B"; "C"; "D"; "E"; "F"; "G"; "H"; "I"; "J"; "K"; "L"; "M"; "N"; "O"; "P"; "Q"; "R"; "S"; "T"; "U"; "V"; "W"; "X"; "Y"; "Z" |]
    let mutable ret : string = ""
    for i = 0 to size do
        ret <- ret + alpha.[rnd.Next 26]
    ret

let objective (s : string) =
    match box reporter with
    | :? IReporterEx as rx -> rx.objective s
    | _ -> ()

let precondition (s : string) =
    match box reporter with
    | :? IReporterEx as rx -> rx.precondition s
    | _ -> ()

let postcondition (s : string) =
    match box reporter with
    | :? IReporterEx as rx -> rx.postcondition s
    | _ -> ()

let fileUploadSelectFile (f : string) (fileName : string) =
    let mutable fn = fileName
    if IO.Path.IsPathRooted(fileName) = false then
        fn <- (AppDomain.CurrentDomain.BaseDirectory  + fileName)
    (element f).SendKeys(fn)

let fileUploadSelectPdf (f : string) =
    fileUploadSelectFile f "sample.pdf"
