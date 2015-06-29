open System
open canopy
open canopy.configuration
open canopy.runner
open testomatic

start firefox

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

"Same example in pure Canopy" &&& fun _ ->
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

"Finders" &&& fun _ ->
    url "http:/localhost:8080/Home/Finders"
    describe "locate field by id"
    setFieldValue "#firstName" "Fred"
    describe "locate field by label"
    setFieldValue "Last name:" "Smith"
    describe "locate field by css"
    setFieldValue ".address1" "101 Main St."
    describe "locate field by xpath"
    setFieldValue "//*[@id='address2']" "2nd Floor"
    describe "locate field by jquery"
    setFieldValue "div.main-section input.city" "Paradise Falls"
    setFieldValue "div.main-section div:nth-of-type(6) input" "Elsewhere"
    setFieldValue ".zip-label + input" "20001"
    describe "locate field by text"
    assertDisplayed "Finders"
    describe "locate field by value"
    click "Continue"

"Stabilization 1" &&& fun _ ->
    url "http://localhost:8080/Home/Stabilization"
    click "Execute"
    assertDisplayed "Done"

"Stabilization 2" &&& fun _ ->
    url "http://localhost:8080/Home/Stabilization"
    click "Execute"
    waitFor (fun _ -> (read "#statusMsg") = "Done")
    assertDisplayed "Done"

"Stabilization Ajax 1" &&& fun _ ->
    url "http://localhost:8080/Home/StabilizationAjax"
    click "Execute Ajax Call"
    waitFor (fun _ -> (read "#statusMsg") = "Done")
    assertDisplayed "Done"

"Stabilization Ajax 2" &&& fun _ ->
    url "http://localhost:8080/Home/StabilizationAjax"
    click "Execute Ajax Call"
    waitForAjax ()
    assertDisplayed "Done"

"Stabilization Webforms" &&& fun _ ->
    url "http://localhost:8080/WebForms/Stabilization.aspx"
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
    url "http://localhost:8080/WebForms/Stabilization.aspx"
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
    url "http://localhost:8080/Home/StabilizationExtendTimeout"
    click "Execute"
    extendTimeout (fun _ -> 
        waitFor (fun _ -> (read "#statusMsg") = "Done")
        )
    assertDisplayed "Done"

run ()

System.Console.WriteLine "Press enter to continue"
System.Console.ReadLine () |> ignore

quit ()