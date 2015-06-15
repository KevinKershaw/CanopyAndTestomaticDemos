module SecondaryWindowTests
open canopy
open canopy.runner
open testomatic
open appConfig

let all _ =
    context "Other windows / tabs"

    "Open secondary window, assert contents, and close" &&& fun _ ->
        url (baseUrl + "Home/OtherWindows")
        let origWindow = browser.CurrentWindowHandle
        click "More info on testomatic"
        switchToOtherWindow origWindow
        assertDisplayed "Index"
        closeOtherWindow origWindow
        switchToWindow origWindow
        assertDisplayed "More info on testomatic"