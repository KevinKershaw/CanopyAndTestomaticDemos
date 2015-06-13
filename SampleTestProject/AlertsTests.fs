module AlertsTests
open canopy
open canopy.runner
open testomaticLib
open appConfig

let all _ =
    context "Javascript calls to alert, confirm, and prompt"

    "Alert -- getting popup text and accepting" &&& fun _ ->
        url (baseUrl + "Home/Alert")
        click "Call Alert"
        alert () == "Alert Popup"
        acceptAlert ()

    "Alert -- getting popup text and dismissing (hitting escape)" &&& fun _ ->
        url (baseUrl + "Home/Alert")
        click "Call Alert"
        alert () == "Alert Popup"
        dismissAlert ()

    "Confirm -- getting popup text and accepting" &&& fun _ ->
        url (baseUrl + "Home/Alert")
        click "Call Confirm"
        alert () == "Confirm Popup"
        acceptAlert ()
        assertFieldValue "#statusMsg" "true"

    "Confirm -- getting popup text and dismissing (cancel)" &&& fun _ ->
        url (baseUrl + "Home/Alert")
        click "Call Confirm"
        alert () == "Confirm Popup"
        dismissAlert ()
        assertFieldValue "#statusMsg" "false"

    "Prompt -- getting popup text and accepting" &&& fun _ ->
        url (baseUrl + "Home/Alert")
        click "Call Prompt"
        alert () == "Prompt Popup"
        browser.SwitchTo().Alert().SendKeys "new text"
        acceptAlert ()
        assertFieldValue "#statusMsg2" "new text"

    "Prompt -- getting popup text and canceling" &&& fun _ ->
        url (baseUrl + "Home/Alert")
        click "Call Prompt"
        alert () == "Prompt Popup"
        browser.SwitchTo().Alert().SendKeys "new text"
        dismissAlert ()
        assertFieldValue "#statusMsg2" "Pending"
