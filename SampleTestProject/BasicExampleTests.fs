module BasicExampleTests
open canopy
open runner
open testomaticLib

let all _ =
    context "Basic example"

    "Basic example with Testomatic" &&& fun _ ->
        url "http://localhost:8080/"
        click "Register"
        assertUrl "/Home/Register"
        setFieldValue "#emailAddress" "someone@somewhere.com"
        setFieldValue "#emailAddress2" "someone@somewhere.com"
        setFieldValue "#password" "Secret1"
        setFieldValue "#password2" "Secret1"
        check "#terms"
        click "Continue"
        assertUrl "/Home/ProtectedContent"
        assertDisplayed "New account created"

    "Basic example in pure Canopy" &&& fun _ ->
        url "http://localhost:8080/"
        click "Register"
        on "/Home/Register"
        "#emailAddress" << "someone@somewhere.com"
        "#emailAddress2" << "someone@somewhere.com"
        "#password" << "Secret1"
        "#password2" << "Secret1"
        check "#terms"
        click "Continue"
        on "/Home/ProtectedContent"
        displayed "New account created"
