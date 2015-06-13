module OtherTests
open canopy
open canopy.runner
open testomatic
open appConfig

let all _ =
    context "Other Tests"

    "Thank you" &&& fun _ ->
        url baseUrl
        click "Thank You"
        assertDisplayed "Hope you enjoyed the show"
