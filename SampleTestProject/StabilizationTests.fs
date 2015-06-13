module StabilizationTests
open canopy
open canopy.runner
open testomaticLib
open appConfig

let all _ =
    context "Stabilization tests"

    "Stabilization 1" &&& fun _ ->
        url (baseUrl + "Home/Stabilization")
        click "Execute"
        assertDisplayed "Done"

    "Stabilization 2" &&& fun _ ->
        url (baseUrl + "Home/Stabilization")
        click "Execute"
        waitFor (fun _ -> (read "#statusMsg") = "Done")
        assertDisplayed "Done"

    "Stabilization Ajax 1" &&& fun _ ->
        url (baseUrl + "Home/StabilizationAjax")
        click "Execute Ajax Call"
        waitFor (fun _ -> (read "#statusMsg") = "Done")
        assertDisplayed "Done"

    "Stabilization Ajax 2" &&& fun _ ->
        url (baseUrl + "Home/StabilizationAjax")
        click "Execute Ajax Call"
        waitForAjax ()
        assertDisplayed "Done"

    "Stabilization Webforms" &&& fun _ ->
        url (baseUrl + "WebForms/Stabilization.aspx")
        click "Next"
        waitForPostback ()
        click "Next"
        waitForPostback ()
        click "Next"
        waitForPostback ()
        click "Next"
        waitForPostback ()
        check "I agree to it all"
        waitForPostback ()
        click "Accept"
        assertDisplayed "Protected Content"
        assertDisplayed "Terms accepted"
    
    "Stabilization Webforms by Id" &&& fun _ ->
        url (baseUrl + "WebForms/Stabilization.aspx")
        click "#ContentPlaceHolder1_Next"
        waitForPostback ()
        click "#ContentPlaceHolder1_Next"
        waitForPostback ()
        click "#ContentPlaceHolder1_Next"
        waitForPostback ()
        click "#ContentPlaceHolder1_Next"
        waitForPostback ()
        check "#ContentPlaceHolder1_AgreeCheckBox"
        waitForPostback ()
        click "#ContentPlaceHolder1_Accept"
        assertDisplayed "Protected Content"
        assertDisplayed "Terms accepted"

    "Stabilization ExtendTimeout" &&& fun _ ->
        url (baseUrl + "Home/StabilizationExtendTimeout")
        click "Execute"
        extendTimeout (fun _ -> 
            waitFor (fun _ -> (read "#statusMsg") = "Done")
            )
        assertDisplayed "Done"
