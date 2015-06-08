//namespace Testomatic
module testomaticLib
open System
open canopy

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
