module OtherTests
open canopy
open runner
open testomaticLib
open appConfig

let all _ =
    context "Other Tests"

    "Thank you" &&& fun _ ->
        url baseUrl
        click "Thank You"
        assertDisplayed "Hope you enjoyed the show"
