module FindersTests
open canopy
open runner
open testomaticLib
open appConfig

let all _ =
    context "Finders tests"

    "Finders" &&& fun _ ->
        url (baseUrl + "Home/Finders")
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
