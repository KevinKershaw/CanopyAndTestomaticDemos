module warmup
open canopy
open canopy.configuration
open testomatic
open appConfig


let warmupSite () =
    describe "warmupSite"
    try
        url (baseUrl + "/Home/Warmup")
        extendTimeout (fun _ ->
            waitFor (fun _ ->
                (element "#continue").Enabled = true
                )
            )
        click "Continue"
    with
    | _ -> reporter.write "warmupSite failed"