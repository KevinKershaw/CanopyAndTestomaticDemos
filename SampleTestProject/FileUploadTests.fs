module FileUploadTests
open canopy
open canopy.runner
open appConfig
open testomatic

let all _ =
    context "File upload tests"

    "File upload" &&& fun _ ->
        url (baseUrl + "Home/FileUpload")
        fileUploadSelectPdf "#file"
        click "Submit"
        assertDisplayed "Index"
